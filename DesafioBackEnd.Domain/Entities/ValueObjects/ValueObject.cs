using FluentValidation.Results;

namespace DesafioBackEnd.Domain.Entities.ValueObjects;

public abstract class ValueObject
{
    protected ValueObject()
    {
        ValidationResultData = new ValidationResult();
    }

    public ValidationResult ValidationResultData { get; protected set; }

    public abstract bool IsValid();
}