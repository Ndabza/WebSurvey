using System.ComponentModel.DataAnnotations;

namespace WebSurvey.Models;

public class AllowedAgesAttribute : ValidationAttribute
{
    private int _minAge;
    private int _maxAge;
    public AllowedAgesAttribute(int minimumAge, int maximumAge)
    {
        _minAge = minimumAge;
        _maxAge = maximumAge;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime date = (DateTime)value!;

        int diff = DateTime.Now.Year - date.Year;

        if (diff >= _minAge && diff <= _maxAge)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage = $"Age must be between 5 and 120");
    }
}

