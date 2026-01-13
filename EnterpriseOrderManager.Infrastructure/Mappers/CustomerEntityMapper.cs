using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Infrastructure.Data.Entities;

namespace EnterpriseOrderManager.Infrastructure.Mappers
{
    public static class CustomerEntityMapper
    {
        public static CustomerDomain ToDomain(this CustomerEntity entity)
        {
            var domain = new CustomerDomain
            {
                Id = entity.Id,
                CustomerNumber = entity.CustomerNumber,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                CreatedAt = entity.CreatedAt,
                Address = entity.Address.ToDomain(),
            };

            var ordersDomain = entity.Orders.Select(o => o.ToDomain()).ToList();
            domain.LoadOrders(ordersDomain);
            return domain;
        }

        public static CustomerEntity ToEntity(this CustomerDomain domain)
        {
            return new CustomerEntity
            {
                Id = domain.Id,
                CustomerNumber = domain.CustomerNumber,
                FirstName = domain.FirstName,
                SecondName = domain.SecondName,
                Email = domain.Email,
                PhoneNumber = domain.PhoneNumber,
                Address = domain.Address.ToEntity(),
                Orders = domain.Orders.Select(o => o.ToEntity()).ToList(),
                CreatedAt = domain.CreatedAt,
            };
        }
    }
}
