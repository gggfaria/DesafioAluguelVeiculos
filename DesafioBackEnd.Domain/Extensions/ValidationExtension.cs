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

    public static void AddError(this ValidationResult validationResult, ValidationFailure error)
    {
        validationResult.Errors.Add(error);
    }

    public static ICollection<InvalidDataResult> GetErrorsResult(this ValidationResult validationResult)
    {
        var errorsResult = new List<InvalidDataResult>();

        foreach (var error in validationResult.Errors)
        {
            errorsResult.Add(new InvalidDataResult(error.PropertyName, error.ErrorMessage));
        }

        return errorsResult;
    }
}