using DesafioBackEnd.Domain.Entities.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackEnd.Infra.Configurations.People;

public class PersonConfig : EntityBaseConfig<Person>
{
    public override void ConfigureFields(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("people");
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar");
        
        builder.Property(p => p.UserName)
            .IsRequired()
            .HasColumnType("varchar");
        
        builder.HasIndex(p => p.UserName)
            .IsUnique();
        
        builder.Property(p => p.Password)
            .IsRequired()
            .HasColumnType("varchar");
    
    }
}