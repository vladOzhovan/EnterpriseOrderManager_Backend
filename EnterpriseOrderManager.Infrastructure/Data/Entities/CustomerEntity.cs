using Microsoft.EntityFrameworkCore;

namespace EnterpriseOrderManager.Infrastructure.Data.Entities
{
    [Index(nameof(CustomerNumber), IsUnique = true)]
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AddressEntity Address { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
