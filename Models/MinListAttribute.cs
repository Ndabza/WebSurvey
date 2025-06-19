using System.ComponentModel.DataAnnotations;

namespace WebSurvey.Models;

public class MinListAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var list = value as List<string>;
        if(list!.Count() > 1)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage = $"Select at least 1 option.");
    }
}
