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
        RuleFor(p => p.CnhNumber)
            .NotEmpty();
        
        RuleFor(p => p.ImageSize)
            .Must(i => i <= Driver.MAX_SIZE_IMG_BYTES)
            .When(p => p.ImageSize is not null)
            .WithMessage("Max size image is 10mb");
        
        RuleFor(p => p.ImageType)
            .Must(i => Driver.ALLOWED_TYPES_IMG.Contains(i))
            .When(p => !string.IsNullOrEmpty(p.ImageType))
            .WithMessage("Allowed type: png or bpm");
        
    }
}