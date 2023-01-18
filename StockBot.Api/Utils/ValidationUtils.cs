using FluentValidation.Results;
using StockBot.Application.Common.Exceptions;

namespace StockBot.Api.Utils;

public static class ValidationUtils
{
    public static void OnAfterValidation(bool validationFailed, List<ValidationFailure> validationFailures)
    {
        if (!validationFailed) return;

        var errorsDictionary = new Dictionary<string, object?>();
        var errorsPerProperty = new Dictionary<string, List<string>>();

        foreach (var error in validationFailures)
        {
            if (!errorsPerProperty.ContainsKey(error.PropertyName))
                errorsPerProperty.Add(error.PropertyName, new List<string>());

            errorsPerProperty[error.PropertyName].Add(error.ErrorMessage);
        }

        errorsDictionary.Add("errors", errorsPerProperty);

        throw new ValidatorException(errorsDictionary);
    }
}