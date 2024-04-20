using DesafioBackEnd.Domain.Entities.Motorcycles;
using FluentValidation;

namespace DesafioBackEnd.Domain.Validators.Motorcycles;

public class PlanValidator : AbstractValidator<Plan>
{
    public PlanValidator()
    {
        RuleFor(p => p.Days)
            .NotEmpty();
        RuleFor(p => p.Price)
            .NotEmpty();
    }
}