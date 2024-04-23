using DesafioBackEnd.Domain.Entities.Motorcycles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations.Motorcycles;

public class PlanConfig : EntityBaseConfig<Plan>
{
    public override void ConfigureFields(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("plans");

        builder.Property(p => p.Days)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();
        
        builder.HasMany(p => p.Rentals);

        
    }
}