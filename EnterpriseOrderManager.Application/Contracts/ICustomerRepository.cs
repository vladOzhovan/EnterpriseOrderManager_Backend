using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Application.Contracts
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<CustomerDomain>> GetAllAsync(CustomerQuery query, CancellationToken ct = default);
        Task<CustomerDomain?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<CustomerDomain> AddAsync(CustomerDomain domain, CancellationToken ct = default);
    }
}
