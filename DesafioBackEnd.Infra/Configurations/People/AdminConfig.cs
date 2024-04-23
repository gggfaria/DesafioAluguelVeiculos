using DesafioBackEnd.Domain.Entities.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations.People;

public class AdminConfig : EntityBaseConfig<Admin>
{
    public override void ConfigureFields(EntityTypeBuilder<Admin> builder)
    {
     
    }

    public override void ConfigureBase(EntityTypeBuilder<Admin> builder)
    {
        // Entity base person
    }
}