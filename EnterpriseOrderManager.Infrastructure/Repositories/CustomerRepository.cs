using EnterpriseOrderManager.Application.Contracts;
using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Infrastructure.Data;
using EnterpriseOrderManager.Infrastructure.Extensions;
using EnterpriseOrderManager.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseOrderManager.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<CustomerDomain>> GetAllAsync(CustomerQuery query, CancellationToken ct = default)
        {
            var queryBase = _context.Customers
                .AsNoTracking()
                .Include(c => c.Orders)
                .Include(c => c.Address)
                .AsQueryable();

            queryBase = queryBase.ApplySearch(query.Search);
            queryBase = queryBase.ApplySorting(query.SortBy, query.IsDescending);

            var entities = await queryBase.ToListAsync(ct);
            var customersDomain = entities.Select(e => e.ToDomain()).ToList();

            return customersDomain;
        }

        public async Task<CustomerDomain?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _context.Customers
                .AsNoTracking()
                .Include(c => c.Orders)
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id, ct);

            return entity?.ToDomain();
        }

        public async Task<CustomerDomain> AddAsync(CustomerDomain domain, CancellationToken ct = default)
        {
            var newCustomerEntity = domain.ToEntity();
            await _context.AddAsync(newCustomerEntity, ct);
            await _context.SaveChangesAsync(ct);
            return domain;
        }
    }
}
