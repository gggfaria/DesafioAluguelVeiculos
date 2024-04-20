using DesafioBackEnd.Domain.Entities.Motorcycles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations.Motorcycles;

public class MotorcycleConfig : EntityBaseConfig<Motorcycle>
{
    public override void ConfigureFields(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.ToTable("motorcycles");
        
        builder.Property(p => p.Model)
            .IsRequired()
            .HasColumnType($"varchar");

        builder.Property(p => p.Year)
            .IsRequired();
        
        builder.Property(p => p.LicencePlate)
            .IsRequired()
            .HasColumnType($"varchar(20)");
        
        builder.HasIndex(p => p.LicencePlate)
            .IsUnique();
    }
}