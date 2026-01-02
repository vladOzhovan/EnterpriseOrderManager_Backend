using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Infrastructure.Data.Entities;

namespace EnterpriseOrderManager.Infrastructure.Mappers
{
    public static class OrderEntityMapper
    {
        public static OrderDomain ToDomain(this OrderEntity entity)
        {
            return new OrderDomain
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                Title = entity.Title,
                Description = entity.Description,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt
            };
        }

        public static OrderEntity ToEntity(this OrderDomain domain)
        {
            return new OrderEntity
            {
                Id = domain.Id,
                CustomerId = domain.Id,
                CustomerNumber = domain.CustomerNumber,
                Title = domain.Title,
                Description = domain.Description,
                Status = domain.Status,
                CreatedAt = domain.CreatedAt
            };
        }
    }
}
