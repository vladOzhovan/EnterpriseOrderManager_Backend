namespace EnterpriseOrderManager.Application.Queries
{
    public class CustomerQuery
    {
        public string? Search { get; set; }
        public bool IsDescending { get; set; } = false;
        public CustomerSortField SortBy { get; set; } = CustomerSortField.CreatedAt;
    }
}
