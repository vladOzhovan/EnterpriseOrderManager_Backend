namespace EnterpriseOrderManager.Domain.Factories
{
    public record CustomerCreationData(
        string firstName,
        string secondName,
        int customerNumber,
        string? phoneNumber,
        string? email
    );
}
