using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Infrastructure.Data.Entities;

namespace EnterpriseOrderManager.Infrastructure.Mappers
{
    public static class AddressEntityMapper
    {
        public static AddressDomain ToDomain(this AddressEntity entity)
        {
            return new AddressDomain
            {
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                City = entity.City,
                Street = entity.Street,
                Apartment = entity.Apartment,
                HouseNumber = entity.HouseNumber
            };
        }

        public static AddressEntity ToEntity(this AddressDomain domain)
        {
            return new AddressEntity
            {
                ZipCode = domain.ZipCode,
                Country = domain.Country,
                City = domain.City,
                Street = domain.Street,
                Apartment = domain.Apartment,
                HouseNumber = domain.HouseNumber
            };
        }
    }
}
