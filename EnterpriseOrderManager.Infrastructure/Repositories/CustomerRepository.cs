using EnterpriseOrderManager.Application.Contracts;
using EnterpriseOrderManager.Application.Dtos;
using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Infrastructure.Data;
using EnterpriseOrderManager.Infrastructure.Data.Entities;
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

        public async Task<IReadOnlyList<CustomerDomain>> GetAllAsync(CustomerQuery query)
        {
            var queryBase = _context.Customers
                .AsNoTracking()
                .Include(c => c.Orders)
                .Include(c => c.Address)
                .AsQueryable();

            queryBase = queryBase.ApplySearch(query.Search);
            queryBase = queryBase.ApplySorting(query.SortBy, query.IsDescending);
            var entities = await queryBase.ToListAsync();
            var customersDomain = entities.Select(e => e.ToDomain()).ToList();
            return customersDomain;
        }

        public async Task<CustomerDomain> AddAsync(CustomerDomain domain)
        {
            var newCustomerEntity = domain.ToEntity();
            await _context.AddAsync(newCustomerEntity);
            await _context.SaveChangesAsync();
            return domain;
        }

        private int AssignNumber()
        {
            return 11111; // this method will be refined
        }
    }
}
