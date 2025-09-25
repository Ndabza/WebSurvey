using System.ComponentModel.DataAnnotations;
using WebSurvey.Data;

namespace WebSurvey.Models
{
    public class IsEmailInUseAttribute: ValidationAttribute
    {
        private SurveyContext _context;

        public IsEmailInUseAttribute(SurveyContext context)
        {
            _context = context;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = (string)value!;

            if (_context.Person.Any(x => x.Email != email))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage = $"This email has already submited a response");
        }
    }
}
