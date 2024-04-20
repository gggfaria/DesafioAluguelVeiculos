using DesafioBackEnd.Domain.Entities.Motorcycles;
using FluentValidation;

namespace DesafioBackEnd.Domain.Validators.Motorcycles;

public class RentalValidator :  AbstractValidator<Rental>
{
    public RentalValidator()
    {
        RuleFor(p => p.StartDate)
            .NotEmpty();
        RuleFor(p => DateOnly.FromDateTime(p.EndDate))
            .GreaterThanOrEqualTo(p => p.StartDate);
        RuleFor(p => p.EstimatedDate)
            .NotEmpty();
    }
    
    
}