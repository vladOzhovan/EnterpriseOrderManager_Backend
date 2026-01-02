using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseOrderManager.Infrastructure.Extensions
{
    public static class CustomerExtensions
    {
        public static IQueryable<CustomerEntity> ApplySearch(this IQueryable<CustomerEntity> query, string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return query;

            search = search.Trim();

            return query.Where(c =>
                EF.Functions.Like(c.CustomerNumber.ToString(), $"%{search}%") ||
                EF.Functions.Like(c.FirstName, $"%{search}%") ||
                EF.Functions.Like(c.SecondName, $"%{search}%")
            );
        }

        public static IQueryable<CustomerEntity> ApplySorting(this IQueryable<CustomerEntity> query,
                                                              CustomerSortField sortBy, bool isDescending = false)
        {
            return sortBy switch
            {
                CustomerSortField.FirstName => isDescending
                    ? query.OrderByDescending(c => c.FirstName)
                    : query.OrderBy(c => c.FirstName),

                CustomerSortField.SecondName => isDescending
                    ? query.OrderByDescending(c => c.SecondName)
                    : query.OrderBy(c => c.SecondName),

                CustomerSortField.CustomerNumber => isDescending
                    ? query.OrderByDescending(c => c.CustomerNumber)
                    : query.OrderBy(c => c.CustomerNumber),

                CustomerSortField.Email => isDescending
                    ? query.OrderByDescending(c => c.Email)
                    : query.OrderBy(c => c.Email),

                CustomerSortField.Phonenumber => isDescending
                    ? query.OrderByDescending(c => c.PhoneNumber)
                    : query.OrderBy(c => c.PhoneNumber),

                CustomerSortField.CreatedAt => isDescending
                    ? query.OrderByDescending(c => c.CreatedAt)
                    : query.OrderBy(c => c.CreatedAt),

                _ => isDescending
                    ? query.OrderByDescending(c => c.CreatedAt)
                    : query.OrderBy(c => c.CreatedAt)
            };
        }
    }
}
