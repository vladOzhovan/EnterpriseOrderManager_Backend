using EnterpriseOrderManager.Application.Contracts;
using EnterpriseOrderManager.Application.Dtos;
using EnterpriseOrderManager.Application.Queries;
using EnterpriseOrderManager.Domain.Entities;
using EnterpriseOrderManager.Domain.Factories;
using Microsoft.Extensions.Logging;

namespace EnterpriseOrderManager.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _repository;
        private readonly ICustomerNumberGenerator _numberGenerator;
        public CustomerService(ILogger<CustomerService> logger, ICustomerRepository repository, ICustomerNumberGenerator numberGenerator)
        {
            _logger = logger;
            _repository = repository;
            _numberGenerator = numberGenerator;
        }

        public async Task<IReadOnlyList<CustomerDomain>> GetAllAsync(CustomerQuery query, CancellationToken ct = default)
        {
            var customers = await _repository.GetAllAsync(query, ct);
            return customers;
        }

        public async Task<CustomerDomain> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Customer id is empty.", nameof(id));

            var customer = await _repository.GetByIdAsync(id, ct);

            if (customer is null)
                throw new KeyNotFoundException($"Customer '{id}' not found.");

            return customer;
        }

        public async Task<CustomerDomain> AddAsync(CustomerCreateModel model, CancellationToken ct = default)
        {
            var number = await _numberGenerator.GetNextAsync(ct);

            var creationData = new CustomerCreationData
            (
                customerNumber: number,
                firstName: model.FirstName,
                secondName: model.SecondName,
                phoneNumber: model.PhoneNumber ?? string.Empty,
                email: model.Email ?? string.Empty
            );

            var domain = CustomerFactory.Create(creationData);
            await _repository.AddAsync(domain, ct);
            return domain;
        }
    }
}
