using EnterpriseOrderManager.Domain.Enums;

namespace EnterpriseOrderManager.Api.Dtos
{
    public record OrderResponseDto(
        int? CustomerNumber,
        string? Title,
        string? Description,
        OrderStatus Status,
        DateTime CreatedAt
    );
}
