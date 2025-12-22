namespace EnterpriseOrderManager.Domain.Entities
{
    public class AddressDomain
    {
        public int? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Apartnent { get; set; }
        public string? HouseNumber { get; set; }
    }
}
