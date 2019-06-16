using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Data.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Models.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("customer_id").HasDefaultValueSql("newId()");

            builder.Property(b => b.Name).HasColumnName("customer_name").HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Age).HasColumnName("age").IsRequired();

            builder.Property(b => b.Address).HasColumnName("address").HasMaxLength(255).IsRequired();

            builder.Property(b => b.Email).HasColumnName("email").HasMaxLength(255).IsRequired();

            builder.Property(e => e.PhoneNumber).HasColumnName("phone_number").HasMaxLength(20).IsRequired();

            builder.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired();

            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at").IsRequired();
        }
    }
}