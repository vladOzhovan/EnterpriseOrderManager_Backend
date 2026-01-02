namespace EnterpriseOrderManager.Api.Dtos
{
    public record CustomerCreateRequest(
        string FirstName,
        string SecondName,
        string? PhoneNumber,
        string? Email
    );
}
