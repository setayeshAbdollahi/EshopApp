using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopApp.Persistence.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="Invoice"/> entity.
/// </summary>
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    /// <summary>
    /// Configures the <see cref="Invoice"/> entity and its relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.IssuedDate)
               .IsRequired();

        builder.HasOne(i => i.Customer)
               .WithMany(c => c.Invoices)
               .HasForeignKey(i => i.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(i => i.TotalAmount);

        builder.HasMany(i => i.Items)
               .WithOne(item => item.Invoice)
               .HasForeignKey(item => item.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
