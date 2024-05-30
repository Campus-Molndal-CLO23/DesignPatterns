using System;

namespace DecoratorPatternAdvancedExample
{
    // Component - defines the interface for objects that can have responsibilities added to them dynamically
    public interface IDataAccess
    {
        void ExecuteQuery(string query);
    }

    // Concrete Component - implements the component interface
    public class DatabaseAccess : IDataAccess
    {
        public void ExecuteQuery(string query)
        {
            Console.WriteLine($"Executing query: {query}");
        }
    }

    // Decorator - maintains a reference to a component object and defines an interface that conforms to the component's interface
    public abstract class DataAccessDecorator : IDataAccess
    {
        protected IDataAccess _dataAccess;

        public DataAccessDecorator(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public virtual void ExecuteQuery(string query)
        {
            _dataAccess.ExecuteQuery(query);
        }
    }

    // Concrete Decorator - adds logging functionality
    public class LoggingDataAccess : DataAccessDecorator
    {
        public LoggingDataAccess(IDataAccess dataAccess) : base(dataAccess) { }

        public override void ExecuteQuery(string query)
        {
            Console.WriteLine($"Logging: Executing query: {query}");
            base.ExecuteQuery(query);
        }
    }

    // Concrete Decorator - adds caching functionality
    public class CachingDataAccess : DataAccessDecorator
    {
        public CachingDataAccess(IDataAccess dataAccess) : base(dataAccess) { }

        public override void ExecuteQuery(string query)
        {
            Console.WriteLine($"Checking cache for query: {query}");
            base.ExecuteQuery(query);
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dataAccess = new DatabaseAccess();

            IDataAccess loggingDataAccess = new LoggingDataAccess(dataAccess);
            IDataAccess cachingDataAccess = new CachingDataAccess(loggingDataAccess);

            cachingDataAccess.ExecuteQuery("SELECT * FROM users");
        }
    }
}

// Output:
// Checking cache for query: SELECT * FROM users
// Logging: Executing query: SELECT * FROM users
// Executing query: SELECT * FROM users


// Förklaring:
// I detta exempel har vi två klasser: LoggingDataAccess och CachingDataAccess.
// LoggingDataAccess och CachingDataAccess är båda dekoratörer som lägger till 
// funktionalitet till en befintlig klass som implementerar IDataAccess-gränssnittet.
// I klienten skapas en instans av DatabaseAccess-klassen och sedan läggs
// LoggingDataAccess och CachingDataAccess till i en kedja. När ExecuteQuery-metoden
// anropas på den sista dekoratören i kedjan kommer alla dekoratörer att köras i
// ordning och funktionaliteten från varje dekoratör kommer att läggas till i
// den ursprungliga implementationen av ExecuteQuery-metoden i DatabaseAccess-klassen.
// Detta möjliggör att funktionalitet kan läggas till dynamiskt utan att ändra den
// ursprungliga klassen.
