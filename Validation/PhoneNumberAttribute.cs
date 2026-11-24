using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegistrationApp.Validation;

public class PhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var phone = value.ToString()!;
        var isValid = Regex.IsMatch(phone, @"^\+?[0-9\s()\-]{7,20}$");

        return isValid
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage ?? "Enter a valid phone number.");
    }
}
