using DesafioBackEnd.Infra.Configurations.Motorcycles;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Context;

public class DesafioContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<FluentValidation.Results.ValidationFailure>();
        modelBuilder.Ignore<FluentValidation.Results.ValidationResult>();

        modelBuilder.ApplyConfiguration(new MotorcycleConfig());
    }
}