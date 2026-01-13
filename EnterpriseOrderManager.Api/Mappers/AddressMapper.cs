using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class AddressMapper
    {
        public static AddressResponseDto? ToResponseDto(this AddressDomain? address)
        {
            if (address is null) return null;

            return new AddressResponseDto(
                ZipCode: address.ZipCode,
                Country: address.Country,
                City: address.City,
                Street: address.Street,
                Apartment: address.Apartment,
                HouseNumber: address.HouseNumber
            );
        }
    }
}
