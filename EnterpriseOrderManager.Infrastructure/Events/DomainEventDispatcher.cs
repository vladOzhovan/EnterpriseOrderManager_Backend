using EnterpriseOrderManager.Application.Events.Abstractions;
using EnterpriseOrderManager.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Reflection;

namespace EnterpriseOrderManager.Infrastructure.Events
{
    public sealed class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _sp;
        private static readonly ConcurrentDictionary<Type, (Type HandlerType, MethodInfo HandleMethod)> _cache = new();

        public DomainEventDispatcher(IServiceProvider sp) => _sp = sp;

        public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken ct = default)
        {
            // Cache handler interface type and HandlerAsync MethodInfo per event type
            // to avoid repeted reflection during event dispatching
            foreach (var ev in domainEvents)
            {
                var eventType = ev.GetType();

                var cached = _cache.GetOrAdd(eventType, t =>
                {
                    var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(t);

                    // method on interface: Task HandleAsync(TEvent domainEvent, CancellationToken ct)
                    var method = handlerType.GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                        ?? throw new InvalidOperationException(
                            $"HandleAsync method not found on {handlerType.Name}.");

                    return (handlerType, method);
                });

                // Resolve all handlers for this event type
                var handlers = _sp.GetServices(cached.HandlerType);

                foreach (var handler in handlers)
                {
                    // Invoke Task HandleAsync(...)
                    var taskObj = cached.HandleMethod.Invoke(handler, [ev, ct]);

                    if (taskObj is Task task)
                        await task.ConfigureAwait(false);
                    else
                        throw new InvalidOperationException("HandleAsync did not return a Task.");
                }
            }
        }
    }
}
