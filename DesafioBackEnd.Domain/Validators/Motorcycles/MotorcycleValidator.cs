using DesafioBackEnd.Domain.Entities.Motorcycles;
using FluentValidation;

namespace DesafioBackEnd.Domain.Validators.Motorcycles;

public class MotorcycleValidator: AbstractValidator<Motorcycle>
{
    public MotorcycleValidator()
    {
        ValidRequiredDatas();
    }
    
    private void ValidRequiredDatas()
    {
        RuleFor(p => p.Model)
            .NotEmpty();
        RuleFor(p => p.Year)
            .NotEmpty();
        RuleFor(p => p.LicencePlate)
            .NotEmpty();
    }

    
}