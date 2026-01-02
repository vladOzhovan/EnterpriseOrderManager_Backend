namespace EnterpriseOrderManager.Application.Contracts
{
    public interface ICustomerNumberGenerator
    {
        Task<int> GetNextAsync(CancellationToken ct = default);
    }
}
