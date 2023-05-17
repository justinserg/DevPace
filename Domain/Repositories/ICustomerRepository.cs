using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Pagging> GetCustomers(int page, Customer customer, CancellationToken cancellationToken = default);
        Task<Customer> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        void Insert(Customer customer);
        void Remove(Customer customer);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
