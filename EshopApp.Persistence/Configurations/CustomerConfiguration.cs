using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EshopApp.Domain.ValueObjects;


namespace EshopApp.Persistence.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="Customer"/> entity.
/// </summary>
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    /// <summary>
    /// Configures the <see cref="Customer"/> entity and its relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FullName)
               .IsRequired()
               .HasMaxLength(100);

        builder.OwnsOne(c => c.PhoneNumber, phone =>
        {
            phone.Property(p => p.Value)
                 .HasColumnName("PhoneNumber")
                 .HasMaxLength(20)
                 .IsRequired();
        });

        builder.Property(c => c.Email)
               .HasConversion(
                    v => v == null ? null : v.Value,
                    v => v == null ? null : new EmailAddress(v)
               );

        builder.HasMany(c => c.Invoices)
               .WithOne(i => i.Customer)
               .HasForeignKey(i => i.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
