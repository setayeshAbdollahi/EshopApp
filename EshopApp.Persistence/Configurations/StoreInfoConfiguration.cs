using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopApp.Persistence.Configurations;

/// <summary>
/// Entity Framework configuration for the <see cref="StoreInfo"/> entity.
/// </summary>
public class StoreInfoConfiguration : IEntityTypeConfiguration<StoreInfo>
{
    /// <summary>
    /// Configures the <see cref="StoreInfo"/> entity and its properties.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<StoreInfo> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.StoreName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(s => s.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);
    }
}
