using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Domain.Entities.People;
using DesafioBackEnd.Infra.Configurations.Motorcycles;
using DesafioBackEnd.Infra.Configurations.People;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Context;

public class DesafioContext : DbContext
{
    public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<ValidationFailure>();
        modelBuilder.Ignore<ValidationResult>();

        modelBuilder.ApplyConfiguration(new MotorcycleConfig());
        modelBuilder.ApplyConfiguration(new PlanConfig());
        modelBuilder.ApplyConfiguration(new PersonConfig());
        modelBuilder.ApplyConfiguration(new DriverConfig());
        modelBuilder.ApplyConfiguration(new RentalConfig());
        modelBuilder.ApplyConfiguration(new AdminConfig());

        
        
        SeedPlans(modelBuilder);
        SeedAdmin(modelBuilder);
        
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            if (!relationship.IsOwnership) // !VO
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }

    private static void SeedPlans(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plan>().HasData(
            new Plan(7, 30),
            new Plan(15, 30),
            new Plan(30, 30),
            new Plan(45, 30),
            new Plan(50, 30)
        );
    }
    
    private static void SeedAdmin(ModelBuilder modelBuilder)
    {
        //mellon_42
        modelBuilder.Entity<Admin>().HasData(
            new Admin("Galdalf","mithrandir", "eNi+nWQF12V2REazPSwJHgEIF8econx1akPJlg+wzYY=")
        );
    }
}