using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class CustomerResponseMapper
    {
        public static CustomerResponseDto ToResponseDto(this CustomerDomain customer)
        {
            return new CustomerResponseDto
            {
                CustomerNumber = customer.CustomerNumber,
                FirstName = customer.FirstName,
                SecondName = customer.SecondName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                Status = customer.Status,
                CreatedAt = customer.CreatedAt,
                Orders = customer.Orders.Select(o => o.ToResponseDto()).ToList()
            };
        }
    }
}
