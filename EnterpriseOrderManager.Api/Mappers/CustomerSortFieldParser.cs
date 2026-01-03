using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Helpers;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class CustomerSortFieldParser
    {
        private static readonly Dictionary<string, CustomerSortField> Map = 
            Enum.GetValues<CustomerSortField>().ToDictionary(
                value => value.ToString().ToLower(),
                vavue => vavue
            );
        
        //new(StringComparer.OrdinalIgnoreCase)
        //{
        //    ["firstname"] = CustomerSortField.FirstName,
        //    ["secondname"] = CustomerSortField.SecondName,
        //    ["customernumber"] = CustomerSortField.CustomerNumber,
        //    ["phonenumber"] = CustomerSortField.Phonenumber,
        //    ["email"] = CustomerSortField.Email,
        //    ["createdat"] = CustomerSortField.CreatedAt,
        //};

        public static Result<CustomerSortField> Parse(string? sortBy)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return Result<CustomerSortField>.Success(CustomerSortField.CreatedAt);

            string normalized = sortBy.Trim().ToLower();

            bool result = Map.TryGetValue(normalized, out CustomerSortField f);

            return Map.TryGetValue(normalized, out var field) 
                ? Result<CustomerSortField>.Success(field)
                : Result<CustomerSortField>.Fail($"Field '{sortBy}' is not supported for sorting.");
        }
    }
}
