using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Domain.Enums;

namespace EnterpriseOrderManager.Api.Dtos
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string CustomerNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string FullName => $"{FirstName ?? string.Empty} {SecondName ?? string.Empty}".Trim();
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AddressResponseDto? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public CustomerStatus Status { get; set; }
        public List<OrderResponseDto> Orders { get; set; } = new List<OrderResponseDto>();
    }
}
