using System;

// Gränssnitt för tillstånd
public interface IUserState
{
    void Handle(UserContext context);
}

// Klass som representerar användarkontexten där tillstånden växlar
public class UserContext
{
    private IUserState _state;

    public UserContext(IUserState state)
    {
        SetState(state);
    }

    public void SetState(IUserState state)
    {
        _state = state;
        Console.WriteLine($"State: {_state.GetType().Name}");
    }

    public void Request()
    {
        _state.Handle(this);
    }
}

// Konkret tillstånd för icke-auktoriserad användare
public class UnauthorizedState : IUserState
{
    public void Handle(UserContext context)
    {
        Console.WriteLine("User is not authenticated. Redirecting to login page...");
        context.SetState(new AuthorizedState());
    }
}

// Konkret tillstånd för auktoriserad användare
public class AuthorizedState : IUserState
{
    public void Handle(UserContext context)
    {
        Console.WriteLine("User is authenticated. Access granted.");
        context.SetState(new LoggedOutState());
    }
}

// Konkret tillstånd för utloggad användare
public class LoggedOutState : IUserState
{
    public void Handle(UserContext context)
    {
        Console.WriteLine("User has logged out. Redirecting to home page...");
        context.SetState(new UnauthorizedState());
    }
}

// Programklass för att demonstrera användarautentisering och sessionshantering med State-mönstret
class Program
{
    static void Main()
    {
        UserContext userContext = new UserContext(new UnauthorizedState());

        // Simulerar autentisering och sessioner
        userContext.Request(); // Icke-auktoriserad -> Auktoriserad
        userContext.Request(); // Auktoriserad -> Utloggad
        userContext.Request(); // Utloggad -> Icke-auktoriserad
    }
}
