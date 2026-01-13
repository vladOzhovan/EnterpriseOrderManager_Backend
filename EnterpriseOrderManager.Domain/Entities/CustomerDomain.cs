using EnterpriseOrderManager.Domain.Abstractions;
using EnterpriseOrderManager.Domain.Enums;
using EnterpriseOrderManager.Domain.Events.Customers;

namespace EnterpriseOrderManager.Domain.Entities
{
    public class CustomerDomain : AggregateRoot
    {
        private readonly List<OrderDomain> _orders = new();
        public IReadOnlyCollection<OrderDomain> Orders => _orders;

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
                if (_orders.Count == 0)
                    return CustomerStatus.NoOrders;

                if (_orders.All(o => o.Status == OrderStatus.Completed))
                    return CustomerStatus.Completed;

                if (_orders.All(o => o.Status == OrderStatus.Canceled))
                    return CustomerStatus.Canceled;

                if (_orders.Any(o => o.Status == OrderStatus.InProgress))
                    return CustomerStatus.InProgress;

                if (_orders.All(o => o.Status == OrderStatus.Pending))
                    return CustomerStatus.Pending;

                return CustomerStatus.Pending;
            }
        }
        
        public void AddOrder(OrderDomain order)
        {
            if (order is null) throw new ArgumentNullException(nameof(order));

            if (order.CustomerId != Id)
                throw new InvalidOperationException("Order.CustomerId must match Customer.Id");

            _orders.Add(order);
        }

        public void LoadOrders(IEnumerable<OrderDomain> orders)
        {
            if (orders is null) throw new ArgumentNullException(nameof(orders));

            _orders.Clear();

            foreach (var order in orders)
                AddOrder(order);
        }

        public void RemoveOrder(Guid id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order is null) throw new KeyNotFoundException(nameof(order));
            _orders.Remove(order);
        }

        public void RaiseCreatedEvent()
        {
            this.AddDomainEvent(new CustomerCreatedDomainEvent(Id, CustomerNumber));
        }
    }
}
