

using BlazorAndFluxorCrud.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Map;

internal class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {

        builder.HasKey(i => i.Id);

        builder.OwnsOne(e => e.Name, name =>
        {
            name.Property(n => n.Value)
                .HasColumnName("Name")
                .IsRequired();
        });

        // Configure the Description value object as an owned type
        builder.OwnsOne(e => e.Description, description =>
        {
            description.Property(d => d.Value)
                .HasColumnName("Description")
                .IsRequired(false);
        });
    }
}
