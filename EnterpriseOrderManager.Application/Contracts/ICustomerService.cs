using EnterpriseOrderManager.Application.Dtos;
using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Application.Contracts
{
    public interface ICustomerService
    {
        Task<IReadOnlyList<CustomerDomain>> GetAllAsync(CustomerQuery query, CancellationToken ct = default);
        Task<CustomerDomain> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<CustomerDomain> AddAsync(CustomerCreateModel model, CancellationToken ct = default);
    }
}
