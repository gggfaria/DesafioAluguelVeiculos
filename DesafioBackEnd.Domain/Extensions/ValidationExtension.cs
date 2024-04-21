using FluentValidation.Results;

namespace DesafioBackEnd.Domain.Entities.Extensions;

public static class ValidationExtension
{
    public static void AddErrors(this ValidationResult validationResult, ValidationResult otherValidationResult)
    {
        foreach (var error in otherValidationResult.Errors)
        {
            validationResult.Errors.Add(error);
        }
    }

}