namespace EnterpriseOrderManager.Application.Queries
{
    public record CustomerQuery
    (
        string? Search,
        bool IsDescending = false,
        CustomerSortField SortBy = CustomerSortField.CreatedAt
    );
}
