using DesafioBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations;

public abstract class EntityBaseConfig<TEntity> : IEntityTypeConfiguration<TEntity>
where TEntity : EntityBase
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureBase(builder);
    }

    public abstract void ConfigureFields(EntityTypeBuilder<TEntity> builder);
    private void ConfigureBase(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(p => p.CreationDate)
            .HasDefaultValue(DateTime.UtcNow);

        builder.HasIndex(p => p.IsActive)
            .IsUnique(false);
    }
}