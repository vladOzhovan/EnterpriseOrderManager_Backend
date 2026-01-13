using EnterpriseOrderManager.Domain.Abstractions;

namespace EnterpriseOrderManager.Domain.Events.Customers
{
    public sealed record CustomerCreatedDomainEvent(Guid CustomerId, int CustomerNumber) : DomainEvent;
}
