using DesafioBackEnd.Domain.Entities.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations.People;

public class DriverConfig : EntityBaseConfig<Driver>
{
    public override void ConfigureFields(EntityTypeBuilder<Driver> builder)
    {
        builder.Property(p => p.CnhImage)
            .IsRequired()
            .HasColumnType($"varchar");

        builder.Property(p => p.CnhType)
            .IsRequired();

        builder.Property(p => p.CnhNumber)
            .IsRequired()
            .HasColumnType($"varchar(20)");

        builder.Property(p => p.DateOfBirth)
            .IsRequired();

        builder.OwnsOne(p => p.Cnpj)
            .Property(p => p.Number)
            .HasColumnType("varchar(20)")
            .IsRequired();
    }
}