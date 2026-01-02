using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Application.Contracts
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<CustomerDomain>> GetAllAsync(CustomerQuery query);
        Task<CustomerDomain> AddAsync(CustomerDomain domain);
    }
}
