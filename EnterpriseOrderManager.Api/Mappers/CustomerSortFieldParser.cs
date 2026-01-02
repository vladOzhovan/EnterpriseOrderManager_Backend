using EnterpriseOrderManager.Application.Queries;

namespace EnterpriseOrderManager.Api.Helpers
{
    public static class CustomerSortFieldParser
    {
        private static readonly Dictionary<string, CustomerSortField> Map = new(StringComparer.OrdinalIgnoreCase)
        {
            ["firstname"] = CustomerSortField.FirstName,
            ["secondname"] = CustomerSortField.SecondName,
            ["customernumber"] = CustomerSortField.CustomerNumber,
            ["phonenumber"] = CustomerSortField.Phonenumber,
            ["email"] = CustomerSortField.Email,
            ["createdat"] = CustomerSortField.CreatedAt,
        };

        public static CustomerSortField Parse(string? sortBy)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return CustomerSortField.CreatedAt;

            return Map.TryGetValue(sortBy.Trim(), out var field) 
                ? field 
                : CustomerSortField.CreatedAt;
        }
    }
}
