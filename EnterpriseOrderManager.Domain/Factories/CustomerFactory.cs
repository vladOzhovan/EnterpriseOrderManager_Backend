using EnterpriseOrderManager.Domain.Entities;

namespace EnterpriseOrderManager.Domain.Factories
{
    public static class CustomerFactory
    {
        public static CustomerDomain Create(CustomerCreationData data)
        {
            var firstName = string.IsNullOrWhiteSpace(data.firstName) ? "Unknown" : data.firstName.Trim();
            var secondName = string.IsNullOrWhiteSpace(data.secondName) ? "Unknown" : data.secondName.Trim();

            var newCustomer = new CustomerDomain
            {
                Id = Guid.NewGuid(),
                CustomerNumber = data.customerNumber,
                FirstName = firstName,
                SecondName = secondName,
                PhoneNumber = data.phoneNumber ?? string.Empty,
                Email = data.email ?? string.Empty,
                CreatedAt = DateTime.UtcNow
            };

            newCustomer.RaiseCreatedEvent();
            return newCustomer;
        }
    }
}
