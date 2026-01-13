namespace EnterpriseOrderManager.Api.Dtos
{
    public record AddressResponseDto(
        int? ZipCode, 
        string? Country, 
        string? City,
        string? Street,
        string? Apartment,  
        string? HouseNumber
    );
}
