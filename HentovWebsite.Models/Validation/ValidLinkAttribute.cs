using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using HentovWebsite.Utility;

namespace HentovWebsite.Models.Validation
{
    public class UrlLinkAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = Consts.UrlRegex;
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (value != null)
            {
                if (reg.IsMatch((string)value))
                    return ValidationResult.Success;
            }

            return new ValidationResult(Consts.UrlValidationError);

        }
    }
}
