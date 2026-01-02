using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class OrderResponseMapper
    {
        public static OrderResponseDto ToResponseDto(this OrderDomain order)
        {
            return new OrderResponseDto
            (
                order.CustomerNumber,
                order.Title,
                order.Description,
                order.Status,
                order.CreatedAt                
            );
        }
    }
}
