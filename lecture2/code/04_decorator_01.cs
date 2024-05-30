using System;

namespace DecoratorPatternSimpleExample
{
    // Component - defines the interface for objects that can have responsibilities added to them dynamically
    public interface ILogger
    {
        void Log(string message);
    }

    // Concrete Component - implements the component interface
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

    // Decorator - maintains a reference to a component object and defines an interface that conforms to the component's interface
    public abstract class LoggerDecorator : ILogger
    {
        protected ILogger _logger;

        public LoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void Log(string message)
        {
            _logger.Log(message);
        }
    }

    // Concrete Decorator - adds responsibilities to the component
    public class TimestampLogger : LoggerDecorator
    {
        public TimestampLogger(ILogger logger) : base(logger) { }

        public override void Log(string message)
        {
            base.Log($"{DateTime.Now}: {message}");
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.Log("Starting application");

            ILogger timestampLogger = new TimestampLogger(logger);
            timestampLogger.Log("Application started");
        }
    }
}

// Output:
// Log: Starting application
// Log: 2024-05-29 12:34:56: Application started

// Förklaring:
// I detta exempel har vi två klasser: ConsoleLogger och TimestampLogger. 
// ConsoleLogger är en Concrete Component som implementerar ILogger-gränssnittet. 
// TimestampLogger är en Concrete Decorator som ärver från LoggerDecorator och 
// lägger till en tidsstämpel till loggmeddelandet. I Main-metoden skapas en instans 
// av ConsoleLogger och ett meddelande loggas. Sedan skapas en instans av TimestampLogger
// som tar en ConsoleLogger som parameter. Ett meddelande loggas igen och denna gång 
// innehåller det en tidsstämpel. Detta möjliggör att funktionalitet kan läggas till 
// dynamiskt utan att ändra den ursprungliga klassen.