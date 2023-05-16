using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services
{
    public class CustomerService : IService
    {
        private readonly ICustomerRepository _customerRespository;

        public CustomerService(ICustomerRepository customerRepository) => _customerRespository = customerRepository;

        public async Task<IEnumerable<Customer>> GetCustomers(CancellationToken cancellationToken = default)
        {
            var customers = await _customerRespository.GetCustomers(cancellationToken);
            return customers;
        }

        public async Task<Customer> CreateAsync(Customer customerDto, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRespository.GetByNameAsync(customerDto.Name, cancellationToken);
            if (customer != null) {
                throw new CustomerAlreadyExistsException($"Customer {customerDto.Name} already exists");
            }

            _customerRespository.Insert(customerDto);
            await _customerRespository.SaveChangesAsync(cancellationToken);
            return customerDto;
        }

        public async Task DeleteAsync(string name, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRespository.GetByNameAsync(name, cancellationToken);
            if (customer == null)
            {
                throw new NotFoundException($"Customer {name} not found");
            }
            _customerRespository.Remove(customer);
            await _customerRespository.SaveChangesAsync(cancellationToken);
        }

        public async Task<Customer> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            var customer = await _customerRespository.GetByNameAsync(name, cancellationToken);
            if (customer == null)
            {
                throw new NotFoundException($"Customer {name} not found");
            }
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customerDto, CancellationToken cancellationToken = default)
        {
            var customer = await _customerRespository.GetByNameAsync(customerDto.Name, cancellationToken);
            if (customer == null)
            {
                throw new NotFoundException($"Customer {customerDto.Name} not found");
            }
            customer.Name = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.Phone = customerDto.Phone;
            customer.CompanyName = customerDto.CompanyName;

            await _customerRespository.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
