using EnterpriseOrderManager.Domain.Enums;

namespace EnterpriseOrderManager.Infrastructure.Data.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid CustomerId { get; set; } = Guid.Empty;
        public int OrderNumber { get; set; }
        public int CustomerNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
