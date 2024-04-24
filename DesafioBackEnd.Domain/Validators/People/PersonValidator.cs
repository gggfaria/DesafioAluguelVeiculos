using DesafioBackEnd.Domain.Entities.People;
using FluentValidation;

namespace DesafioBackEnd.Domain.Validators.People;

public class PersonValidator : AbstractValidator<Person>
{

    public PersonValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty();
        RuleFor(p => p.UserName)
            .NotEmpty();
        RuleFor(p => p.Password)
            .NotEmpty();
        RuleFor(p => p.Permission)
            .NotEmpty();
        
    }
    
}