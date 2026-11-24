# Registration App

ASP.NET Core MVC registration form with server-side and client-side validation.

## Validation

- ValidateNever
- CreditCard
- Compare
- EmailAddress
- PhoneNumber custom attribute
- Range
- RegularExpression
- Required
- StringLength
- URL
- Remote username uniqueness check

Valid users are stored in SQLite through Entity Framework Core. Passwords are hashed and only the last four credit card digits are stored.

## Run

```bash
dotnet restore
dotnet run
```

The SQLite database is created automatically on the first start.
