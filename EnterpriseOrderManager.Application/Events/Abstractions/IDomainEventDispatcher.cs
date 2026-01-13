using EnterpriseOrderManager.Domain.Interfaces;

namespace EnterpriseOrderManager.Application.Events.Abstractions
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(IEnumerable<IDomainEvent> domainEvent, CancellationToken ct = default);
    }
}
