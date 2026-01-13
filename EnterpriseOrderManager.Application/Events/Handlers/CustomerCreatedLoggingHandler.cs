using EnterpriseOrderManager.Application.Events.Abstractions;
using EnterpriseOrderManager.Domain.Events.Customers;
using Microsoft.Extensions.Logging;

namespace EnterpriseOrderManager.Application.Events.Handlers
{
    public sealed class CustomerCreatedLoggingHandler : IDomainEventHandler<CustomerCreatedDomainEvent>
    {
        private readonly ILogger<CustomerCreatedLoggingHandler> _logger;

        public CustomerCreatedLoggingHandler(ILogger<CustomerCreatedLoggingHandler> logger)
            => _logger = logger;

        public Task HandleAsync(CustomerCreatedDomainEvent e, CancellationToken ct)
        {
            _logger.LogInformation("Customer created: {CustomerId}, #{CustomerNumber}, {EventId}, {OccurredAt}",
                                                      e.CustomerId, e.CustomerNumber, e.EventId, e.OccurredAtUtc);
            return Task.CompletedTask;
        }
    }
}
