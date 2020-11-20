using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Data.Entities;

namespace WebApplication.Data.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Price).HasColumnName("Price").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description");
        }
        
    }
}