using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationApp.Data;
using RegistrationApp.Models;

namespace RegistrationApp.Controllers;

public class AccountController(AppDbContext context, IPasswordHasher<User> passwordHasher) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (await context.Users.AnyAsync(x => x.Username == model.Username))
        {
            ModelState.AddModelError(nameof(model.Username), "This username is already used.");
        }

        if (await context.Users.AnyAsync(x => x.Email == model.Email))
        {
            ModelState.AddModelError(nameof(model.Email), "This email is already registered.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Age = model.Age,
            Website = model.Website,
            TermsOfService = model.TermsOfService,
            CreditCardLastFour = GetLastFour(model.CreditCardNumber)
        };

        user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(Success));
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> CheckUsername(string username)
    {
        var exists = await context.Users.AnyAsync(x => x.Username == username);
        return Json(exists ? "This username is already used." : true);
    }

    public IActionResult Success()
    {
        return View();
    }

    private static string? GetLastFour(string? number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            return null;
        }

        var digits = new string(number.Where(char.IsDigit).ToArray());
        return digits.Length >= 4 ? digits[^4..] : digits;
    }
}
