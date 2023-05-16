﻿using Domain.Entities;

namespace Services.Abstractions
{
    public interface IService
    {
        Task<IEnumerable<Customer>> GetCustomers(CancellationToken cancellationToken = default);
        Task<Customer> GetByNameAsync(string name, CancellationToken cancellationToken);

        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default);

        Task DeleteAsync(string name, CancellationToken cancellationToken = default);

        Task<Customer> UpdateAsync(Customer customerDto, CancellationToken cancellationToken = default);
    }
}
