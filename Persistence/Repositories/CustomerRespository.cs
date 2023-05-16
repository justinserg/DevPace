using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class CustomerRespository : ICustomerRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public CustomerRespository(RepositoryDbContext dbContext) =>
            _dbContext = dbContext;
        

        public async Task<Customer> GetByNameAsync(string name, CancellationToken cancellationToken = default) =>
            await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Name == name, cancellationToken);
        

        public async Task<IEnumerable<Customer>> GetCustomers(CancellationToken cancellationToken = default) =>
            await _dbContext.Customers.ToListAsync(cancellationToken);


        public void Insert(Customer customer) =>
             _dbContext.Customers.Add(customer);

        public void Remove(Customer customer) =>
            _dbContext.Customers.Remove(customer);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
