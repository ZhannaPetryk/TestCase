using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Data.Entities;

namespace WebApplication.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(t => t.Product)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(x => x.ProductId);

            builder.Property(c => c.ProductCount).HasColumnName("ProductCount").IsRequired();
        }
    }
}