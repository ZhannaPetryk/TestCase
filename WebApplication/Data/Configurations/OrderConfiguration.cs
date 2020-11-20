using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Data.Entities;

namespace WebApplication.Data.Configurations
{
    public class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(c => c.Date).HasColumnName("Date").IsRequired();
            builder.Property(c => c.Status).HasColumnName("Status").IsRequired();
        }
    }
}