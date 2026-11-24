using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RegistrationApp.Validation;

namespace RegistrationApp.Models;

public class RegisterViewModel
{
    [Required, StringLength(50)]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(50)]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[A-Za-z0-9_]+$", ErrorMessage = "Use only letters, numbers and underscores.")]
    [Remote("CheckUsername", "Account", ErrorMessage = "This username is already used.")]
    public string Username { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [PhoneNumber]
    [Display(Name = "Phone number")]
    public string? PhoneNumber { get; set; }

    [Range(18, 100)]
    public int Age { get; set; }

    [Required, StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 8)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [CreditCard]
    [Display(Name = "Credit card number")]
    public string? CreditCardNumber { get; set; }

    [Url]
    public string? Website { get; set; }

    [ValidateNever]
    [Display(Name = "I accept the terms of service")]
    public bool TermsOfService { get; set; }
}
