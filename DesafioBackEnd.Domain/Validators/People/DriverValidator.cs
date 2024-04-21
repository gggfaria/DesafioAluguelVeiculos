using DesafioBackEnd.Domain.Entities.People;
using FluentValidation;

namespace DesafioBackEnd.Domain.Validators.People;

public class DriverValidator : AbstractValidator<Driver>
{
    public DriverValidator()
    {
        RuleFor(p => p.CnhType)
            .NotEmpty()
            .IsInEnum();
        RuleFor(p => p.CnhImage)
            .NotEmpty();
        RuleFor(p => p.CnhNumber)
            .NotEmpty();
    }
}