using DesafioBackEnd.Domain.Entities.Motorcycles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations.People;

public class RentalConfig : EntityBaseConfig<Rental>
{
    public override void ConfigureFields(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("rental");

        builder.Property(p => p.MotorcycleId)
            .IsRequired();
        
        builder.Property(p => p.DriverId)
            .IsRequired();

        builder.Property(p => p.PlanId)
            .IsRequired();
        
        builder.Property(p => p.StartDate)
            .IsRequired();
        
        builder.Property(p => p.EstimatedDate)
            .IsRequired();

        builder.Property(p => p.EndDate)
            .IsRequired(false);
        
        
        builder.HasOne(p => p.Motorcycle)
            .WithMany(p => p.Rentals)
            .HasForeignKey(p => p.MotorcycleId);

        builder.HasOne(p => p.Plan)
            .WithMany(p => p.Rentals)
            .HasForeignKey(p => p.PlanId);;
        
        builder.HasOne(p => p.Driver)
            .WithMany(p => p.Rentals)
            .HasForeignKey(p => p.DriverId);;



    }  
}