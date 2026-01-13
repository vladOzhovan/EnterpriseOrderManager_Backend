using EnterpriseOrderManager.Domain.Interfaces;

namespace EnterpriseOrderManager.Domain.Abstractions
{
    public abstract record DomainEvent : IDomainEvent
    {
        public Guid EventId { get; } = Guid.NewGuid();
        public DateTime OccurredAtUtc { get; } = DateTime.UtcNow;
    }
}
