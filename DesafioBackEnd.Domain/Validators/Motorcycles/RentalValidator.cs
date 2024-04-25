using DesafioBackEnd.Domain.Entities.Motorcycles;
using FluentValidation;

namespace DesafioBackEnd.Domain.Validators.Motorcycles;

public class RentalValidator :  AbstractValidator<Rental>
{
    public RentalValidator()
    {
        RuleFor(p => p.StartDate)
            .NotEmpty();
        
        RuleFor(p => p.EndDate)
            .GreaterThanOrEqualTo(p => p.StartDate)
            .When(p => p.EndDate is not null);

        RuleFor(p => p.EstimatedDate)
            .GreaterThan(p => p.StartDate);

        RuleFor(p => p.GetAmountDaysEstimated())
            .GreaterThan(0)
            .WithMessage("Amount of days is less than 1");
        
        RuleFor(p => p.MotorcycleId)
            .NotEmpty();
        
        RuleFor(p => p.DriverId)
            .NotEmpty();
        
        RuleFor(p => p.PlanId)
            .NotEmpty();
    }
    
    
}