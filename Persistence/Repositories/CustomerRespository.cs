using Domain.Entities;
using Domain.Repositories;
using Microsoft.Data.SqlClient;
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
        

        public async Task<Pagging> GetCustomers(int page, Customer customer, CancellationToken cancellationToken = default)
        {
            var name = new SqlParameter("Name", customer.Name);
            var company = new SqlParameter("Company", customer.CompanyName);
            var email = new SqlParameter("Email", customer.Email);
            var phone = new SqlParameter("Phone", customer.Phone);

            FormattableString sql = $"exec SelectUser '{customer.CompanyName}'";
            var customers = await _dbContext.Customers.FromSqlInterpolated($"EXECUTE dbo.SelectUser {company}, {name}, {phone}, {email}")
                .ToListAsync();
            var response = new Pagging
            {
                Number = page,
                Count = customers.Count / 10 + 1,
                Customers = customers.Skip(page * 10 - 10).Take(10)
            };

            return response;
        }
            


        public void Insert(Customer customer) =>
             _dbContext.Customers.Add(customer);

        public void Remove(Customer customer) =>
            _dbContext.Customers.Remove(customer);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
