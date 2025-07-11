using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopApp.Persistence.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="InvoiceItem"/> entity.
/// </summary>
public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    /// <summary>
    /// Configures the <see cref="InvoiceItem"/> entity and its relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.ToTable("InvoiceItems");

        builder.HasKey(ii => ii.Id);

        builder.Property(ii => ii.Quantity)
               .IsRequired();

        builder.Property(ii => ii.UnitPrice)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.HasOne(ii => ii.Product)
               .WithMany(p => p.InvoiceItems)
               .HasForeignKey(ii => ii.ProductId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ii => ii.Invoice)
               .WithMany(i => i.Items)
               .HasForeignKey(ii => ii.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
