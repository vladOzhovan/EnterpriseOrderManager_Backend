using EnterpriseOrderManager.Api.Dtos;
using EnterpriseOrderManager.Application.Dtos;

namespace EnterpriseOrderManager.Api.Mappers
{
    public static class CustomerCreateMapper
    {
        public static CustomerCreateModel ToModel(this CustomerCreateRequest request)
        {
            return new CustomerCreateModel
            (
                request.FirstName,
                request.SecondName,
                request.PhoneNumber,
                request.Email
            );
        }
    }
}
