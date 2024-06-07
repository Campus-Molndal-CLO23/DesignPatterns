using System;

// Definierar ett gränssnitt för alla validatorer
public interface IValidator
{
    // Metod för att sätta nästa validator i kedjan
    IValidator SetNext(IValidator nextValidator);

    // Metod för att validera användarens indata
    bool Validate(UserInput input);
}

// Klass för att representera användarens indata
public class UserInput
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

// Abstrakt klass som implementerar grundläggande funktionalitet för validatorer
public abstract class AbstractValidator : IValidator
{
    private IValidator _nextValidator;

    // Sätter nästa validator i kedjan
    public IValidator SetNext(IValidator nextValidator)
    {
        _nextValidator = nextValidator;
        return nextValidator;
    }

    // Validerar användarens indata och skickar den vidare i kedjan om nödvändigt
    public bool Validate(UserInput input)
    {
        if (!HandleValidation(input))
        {
            return false; // Validering misslyckades
        }
        if (_nextValidator != null)
        {
            return _nextValidator.Validate(input); // Fortsätt validering
        }
        return true; // Validering lyckades
    }

    // Abstrakt metod som varje konkret validator måste implementera
    protected abstract bool HandleValidation(UserInput input);
}

// Konkreta klasser för olika valideringar

public class UsernameValidator : AbstractValidator
{
    protected override bool HandleValidation(UserInput input)
    {
        if (string.IsNullOrEmpty(input.Username))
        {
            Console.WriteLine("Username is required.");
            return false; // Validering misslyckades
        }
        return true; // Validering lyckades
    }
}

public class PasswordValidator : AbstractValidator
{
    protected override bool HandleValidation(UserInput input)
    {
        if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 6)
        {
            Console.WriteLine("Password must be at least 6 characters long.");
            return false; // Validering misslyckades
        }
        return true; // Validering lyckades
    }
}

public class EmailValidator : AbstractValidator
{
    protected override bool HandleValidation(UserInput input)
    {
        if (string.IsNullOrEmpty(input.Email) || !input.Email.Contains("@"))
        {
            Console.WriteLine("Invalid email address.");
            return false; // Validering misslyckades
        }
        return true; // Validering lyckades
    }
}

public class RegExValidator : AbstractValidator
{
    protected override bool HandleValidation(UserInput input)
    {
        // Implementera validering med reguljära uttryck här
        const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        if (string.IsNullOrEmpty(input.Email) || !Regex.IsMatch(input.Email, emailPattern))
        {
            Console.WriteLine("Invalid email address.");
            return false; // Validering misslyckades
        }
        return true; // Validering lyckades
    }
}

public class NoSwedishCharsValidator : AbstractValidator
{
    protected override bool HandleValidation(UserInput input)
    {
        if (string.IsNullOrEmpty(input.Username) || !input.containsSwedishChars())
        {
            Console.WriteLine("Username must not contain any Swedish characters.");
            return false; // Validering misslyckades
        }
        return true; // Validering lyckades
    }

    private bool containsSwedishChars(string input)
    {
        return input.Any(c => "åäö".Contains(c));
    }
}


// Programklass för att demonstrera valideringskedjan
class Program
{
    static void Main()
    {
        // Skapar valideringskedjan
        IValidator validatorChain = new UsernameValidator();
        validatorChain
            .SetNext(new PasswordValidator())
            .SetNext(new EmailValidator())
            .SetNext(new NoSwedishCharsValidator())
            .SetNext(new RegExValidator())
            ;

        // Skapar en UserInput-objekt
        UserInput input = new UserInput
        {
            Username = "testuser",
            Password = "password",
            Email = "test@example.com"
        };

        // Validerar användarens indata
        bool isValid = validatorChain.Validate(input);
        Console.WriteLine($"Validation result: {isValid}");
    }
}
