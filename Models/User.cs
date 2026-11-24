namespace RegistrationApp.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public int Age { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string? CreditCardLastFour { get; set; }
    public string? Website { get; set; }
    public bool TermsOfService { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
