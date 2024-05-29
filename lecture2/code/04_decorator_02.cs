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
