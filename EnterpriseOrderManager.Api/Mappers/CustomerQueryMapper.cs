using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Api.Helpers;
using EnterpriseOrderManager.Application.Queries;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class CustomerQueryMapper
    {
        public static CustomerQuery ToQuery (this CustomerQueryDto dto, CustomerSortField sortBy)
        {
            var query = new CustomerQuery(
                Search: dto.Search, 
                IsDescending: dto.IsDescending, 
                SortBy: sortBy
            );
            return query;
        }
    }
}
