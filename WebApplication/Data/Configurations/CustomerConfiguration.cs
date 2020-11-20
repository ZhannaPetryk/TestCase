using WebApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Data.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName).HasColumnName("FullName").IsRequired();
            builder.Property(c => c.Country).HasColumnName("Country").IsRequired();
        }
    }
}