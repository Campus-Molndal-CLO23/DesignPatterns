using System;

// Definierar ett gränssnitt för alla loggers
public interface ILogger
{
    // Metod för att sätta nästa logger i kedjan
    ILogger SetNext(ILogger nextLogger);

    // Metod för att logga ett meddelande med en viss loggningsnivå
    void Log(string message, LogLevel level);
}

// Enum för olika loggningsnivåer
public enum LogLevel
{
    INFO,
    DEBUG,
    ERROR
}

// Abstrakt klass som implementerar grundläggande funktionalitet för loggers
public abstract class AbstractLogger : ILogger
{
    private ILogger _nextLogger;

    // Sätter nästa logger i kedjan
    public ILogger SetNext(ILogger nextLogger)
    {
        _nextLogger = nextLogger;
        return nextLogger;
    }

    // Loggar ett meddelande och skickar det vidare i kedjan om nödvändigt
    public void Log(string message, LogLevel level)
    {
        if (HandleLog(message, level) && _nextLogger != null)
        {
            _nextLogger.Log(message, level);
        }
    }

    // Abstrakt metod som varje konkret logger måste implementera
    protected abstract bool HandleLog(string message, LogLevel level);
}

// Konkreta klasser för olika loggningsnivåer

public class InfoLogger : AbstractLogger
{
    protected override bool HandleLog(string message, LogLevel level)
    {
        if (level == LogLevel.INFO)
        {
            Console.WriteLine($"INFO: {message}");
            return false; // Stoppa vidare bearbetning
        }
        return true; // Fortsätt bearbetning
    }
}

public class DebugLogger : AbstractLogger
{
    protected override bool HandleLog(string message, LogLevel level)
    {
        if (level == LogLevel.DEBUG)
        {
            Console.WriteLine($"DEBUG: {message}");
            return false; // Stoppa vidare bearbetning
        }
        return true; // Fortsätt bearbetning
    }
}

public class ErrorLogger : AbstractLogger
{
    protected override bool HandleLog(string message, LogLevel level)
    {
        if (level == LogLevel.ERROR)
        {
            Console.WriteLine($"ERROR: {message}");
            return false; // Stoppa vidare bearbetning
        }
        return true; // Fortsätt bearbetning
    }
}

// Programklass för att demonstrera loggningskedjan
class Program
{
    static void Main()
    {
        // Skapar loggningskedjan
        ILogger loggerChain = new InfoLogger();
        loggerChain.SetNext(new DebugLogger()).SetNext(new ErrorLogger());

        // Testar loggningskedjan med olika nivåer
        loggerChain.Log("This is an info message.", LogLevel.INFO);
        loggerChain.Log("This is a debug message.", LogLevel.DEBUG);
        loggerChain.Log("This is an error message.", LogLevel.ERROR);
    }
}

/* Exempel på körning:
INFO: This is an info message.
DEBUG: This is a debug message.
ERROR: This is an error message.
*/
