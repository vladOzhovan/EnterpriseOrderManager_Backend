namespace EnterpriseOrderManager.Api.Dtos
{
    public class CustomerQueryDto
    {
        public string? Search { get; set; }
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}
