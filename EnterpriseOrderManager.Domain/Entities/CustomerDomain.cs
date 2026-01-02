using EnterpriseOrderManager.Domain.Enums;

namespace EnterpriseOrderManager.Domain.Entities
{
    public class CustomerDomain
    {
        public Guid Id { get; set; }
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string FullName => $"{FirstName ?? string.Empty} {SecondName ?? string.Empty}".Trim();
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AddressDomain Address { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public CustomerStatus Status
        {
            get
            {
                if (Orders.Count == 0)
                    return CustomerStatus.NoOrders;

                if (Orders.All(o => o.Status == OrderStatus.Completed))
                    return CustomerStatus.Completed;

                if (Orders.All(o => o.Status == OrderStatus.Canceled))
                    return CustomerStatus.Canceled;

                if (Orders.Any(o => o.Status == OrderStatus.InProgress))
                    return CustomerStatus.InProgress;

                if (Orders.All(o => o.Status == OrderStatus.Pending))
                    return CustomerStatus.Pending;

                return CustomerStatus.Pending;
            }
        }
        public List<OrderDomain> Orders { get; set; } = new List<OrderDomain>();
    }
}
