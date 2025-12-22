using EnterpriseOrderManager.Domain.Enums;

namespace EnterpriseOrderManager.Domain.Entities
{
    public class CustomerDomain
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string FullName => $"{FirstName ?? string.Empty} {SecondName ?? string.Empty}".Trim();
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AddressDomain? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus OverallStatus
        {
            get
            {
                if (Orders.Count == 0)
                    return OrderStatus.NoOrders;

                if (Orders.All(o => o.Status == OrderStatus.Completed))
                    return OrderStatus.Completed;

                if (Orders.All(o => o.Status == OrderStatus.Canceled))
                    return OrderStatus.Canceled;

                if (Orders.Any(o => o.Status == OrderStatus.InProgress))
                    return OrderStatus.InProgress;

                if (Orders.All(o => o.Status == OrderStatus.Pending))
                    return OrderStatus.Pending;

                return OrderStatus.Pending;
            }
        }
        public List<OrderDomain> Orders { get; set; } = new List<OrderDomain>();
    }
}
