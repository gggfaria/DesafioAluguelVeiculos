using DesafioBackEnd.Domain.Entities;
using DesafioBackEnd.Domain.Entities.Motorcycles;
using DesafioBackEnd.Infra.Configurations.Motorcycles;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Context;

public class DesafioContext : DbContext
{
    private readonly string _connection;
    public DesafioContext(InjectionStrings connection)
    {
        _connection = connection.DbConnection;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connection);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<ValidationFailure>();
        modelBuilder.Ignore<ValidationResult>();

        modelBuilder.ApplyConfiguration(new MotorcycleConfig());
        modelBuilder.ApplyConfiguration(new PlanConfig());

        SeedPlans(modelBuilder);

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
}