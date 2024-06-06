using System;

// Gränssnitt för tillstånd
public interface IState
{
    void Handle(Context context);
}

// Klass som representerar kontexten där tillstånden växlar
public class Context
{
    private IState _state;

    public Context(IState state)
    {
        SetState(state);
    }

    public void SetState(IState state)
    {
        _state = state;
        Console.WriteLine($"State: {_state.GetType().Name}");
    }

    public void Request()
    {
        _state.Handle(this);
    }
}

// Konkret tillstånd för att ladda data
public class LoadingState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Loading data...");
        // Simulerar data laddning
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Data loaded.");
        context.SetState(new SavingState());
    }
}

// Konkret tillstånd för att spara data
public class SavingState : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Saving data...");
        // Simulerar data sparande
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Data saved.");
        context.SetState(new LoadingState());
    }
}

// Programklass för att demonstrera laddning och sparande med State-mönstret
class Program
{
    static void Main()
    {
        Context context = new Context(new LoadingState());

        // Simulerar processcykel för laddning och sparande
        context.Request(); // Ladda data
        context.Request(); // Spara data
        context.Request(); // Ladda data
        context.Request(); // Spara data
    }
}
