using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(customer => customer.Name);
            builder.Property(customer => customer.Email).HasMaxLength(320);
            builder.Property(customer => customer.Name).HasMaxLength(50);
            builder.Property(customer => customer.CompanyName).HasMaxLength(50);
            builder.Property(customer => customer.Phone).HasMaxLength(15);
        }
    }
}
