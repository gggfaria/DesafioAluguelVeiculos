using DesafioBackEnd.Infra.Configurations.Motorcycles;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Context;

public class DesafioContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<ValidationFailure>();
        modelBuilder.Ignore<ValidationResult>();

        modelBuilder.ApplyConfiguration(new MotorcycleConfig());
        modelBuilder.ApplyConfiguration(new PlanConfig());

    }
}