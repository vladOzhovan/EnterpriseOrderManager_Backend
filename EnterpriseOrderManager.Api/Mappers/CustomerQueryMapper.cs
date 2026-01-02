using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Api.Helpers;
using EnterpriseOrderManager.Application.Queries;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class CustomerQueryMapper
    {
        public static CustomerQuery ToQuery (this CustomerQueryDto dto)
        {
            var query = new CustomerQuery
            {
                IsDescending = dto.IsDescending,
                Search = dto.Search
            };

            query.SortBy = CustomerSortFieldParser.Parse(dto.SortBy);
            return query;
        }
    }
}
