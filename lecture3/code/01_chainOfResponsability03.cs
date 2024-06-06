using System;

// Definierar ett gränssnitt för alla supportärendehanterare
public interface IRequestHandler
{
    // Metod för att sätta nästa hanterare i kedjan
    IRequestHandler SetNext(IRequestHandler nextHandler);

    // Metod för att hantera ett supportärende
    void HandleRequest(SupportRequest request);
}

// Klass för att representera ett supportärende
public class SupportRequest
{
    public string Description { get; set; }
    public int Level { get; set; }
}

// Abstrakt klass som implementerar grundläggande funktionalitet för hanterare
public abstract class AbstractRequestHandler : IRequestHandler
{
    private IRequestHandler _nextHandler;

    // Sätter nästa hanterare i kedjan
    public IRequestHandler SetNext(IRequestHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }

    // Hanterar ett supportärende och skickar det vidare i kedjan om nödvändigt
    public void HandleRequest(SupportRequest request)
    {
        if (Handle(request) && _nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }

    // Abstrakt metod som varje konkret hanterare måste implementera
    protected abstract bool Handle(SupportRequest request);
}

// Konkreta klasser för olika nivåer av support

public class Level1SupportHandler : AbstractRequestHandler
{
    protected override bool Handle(SupportRequest request)
    {
        if (request.Level == 1)
        {
            Console.WriteLine($"L1 handled request: {request.Description}");
            return false; // Stoppa vidare bearbetning
        }
        return true; // Fortsätt bearbetning
    }
}

public class Level2SupportHandler : AbstractRequestHandler
{
    protected override bool Handle(SupportRequest request)
    {
        if (request.Level == 2)
        {
            Console.WriteLine($"L2 handled request: {request.Description}");
            return false; // Stoppa vidare bearbetning
        }
        return true; // Fortsätt bearbetning
    }
}

public class Level3SupportHandler : AbstractRequestHandler
{
    protected override bool Handle(SupportRequest request)
    {
        if (request.Level == 3)
        {
            Console.WriteLine($"L3 handled request: {request.Description}");
            return false; // Stoppa vidare bearbetning
        }
        return true; // Fortsätt bearbetning
    }
}

// Programklass för att demonstrera supporthanteringskedjan
class Program
{
    static void Main()
    {
        // Skapar supporthanteringskedjan
        IRequestHandler handlerChain = new Level1SupportHandler();
        handlerChain.SetNext(new Level2SupportHandler()).SetNext(new Level3SupportHandler());

        // Skapar ett supportärende
        SupportRequest request = new SupportRequest
        {
            Description = "System is not responding.",
            Level = 2
        };

        // Hanterar supportärendet
        handlerChain.HandleRequest(request);
    }
}
