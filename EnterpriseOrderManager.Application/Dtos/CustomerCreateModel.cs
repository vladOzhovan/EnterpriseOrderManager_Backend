using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Domain.Enums;

namespace EnterpriseOrderManager.Application.Dtos
{
    public record CustomerCreateModel(
        string FirstName,
        string SecondName,
        string? PhoneNumber,
        string? Email
    );    
}
