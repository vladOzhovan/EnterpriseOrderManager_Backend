namespace EnterpriseOrderManager.Infrastructure.Data.Entities
{
    public class AddressEntity
    {
        public int? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Apartment { get; set; }
        public string? HouseNumber { get; set; }
    }
}
