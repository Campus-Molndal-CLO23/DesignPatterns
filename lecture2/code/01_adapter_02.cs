using System;

namespace AdapterPatternExampleRealWorld
{
    // ITarget interface - this is the interface that clients expect to work with.
    public interface IDatabase
    {
        void Connect();
        void Disconnect();
        void ExecuteQuery(string query);
    }

    // Existing class for MySQL database
    public class MySQLDatabase
    {
        public void OpenMySQLConnection()
        {
            Console.WriteLine("MySQL database connection opened.");
        }

        public void CloseMySQLConnection()
        {
            Console.WriteLine("MySQL database connection closed.");
        }

        public void RunMySQLQuery(string query)
        {
            Console.WriteLine($"Executing MySQL query: {query}");
        }
    }

    // Existing class for PostgreSQL database
    public class PostgreSQLDatabase
    {
        public void OpenPostgreSQLConnection()
        {
            Console.WriteLine("PostgreSQL database connection opened.");
        }

        public void ClosePostgreSQLConnection()
        {
            Console.WriteLine("PostgreSQL database connection closed.");
        }

        public void RunPostgreSQLQuery(string query)
        {
            Console.WriteLine($"Executing PostgreSQL query: {query}");
        }
    }

    // Adapter class for MySQLDatabase
    public class MySQLAdapter : IDatabase
    {
        private readonly MySQLDatabase _mySQLDatabase;

        // The constructor takes an instance of MySQLDatabase.
        public MySQLAdapter(MySQLDatabase mySQLDatabase)
        {
            _mySQLDatabase = mySQLDatabase;
        }

        // The Connect method is adapted to call OpenMySQLConnection on the MySQLDatabase instance.
        public void Connect()
        {
            _mySQLDatabase.OpenMySQLConnection();
        }

        // The Disconnect method is adapted to call CloseMySQLConnection on the MySQLDatabase instance.
        public void Disconnect()
        {
            _mySQLDatabase.CloseMySQLConnection();
        }

        // The ExecuteQuery method is adapted to call RunMySQLQuery on the MySQLDatabase instance.
        public void ExecuteQuery(string query)
        {
            _mySQLDatabase.RunMySQLQuery(query);
        }
    }

    // Adapter class for PostgreSQLDatabase
    public class PostgreSQLAdapter : IDatabase
    {
        private readonly PostgreSQLDatabase _postgreSQLDatabase;

        // The constructor takes an instance of PostgreSQLDatabase.
        public PostgreSQLAdapter(PostgreSQLDatabase postgreSQLDatabase)
        {
            _postgreSQLDatabase = postgreSQLDatabase;
        }

        // The Connect method is adapted to call OpenPostgreSQLConnection on the PostgreSQLDatabase instance.
        public void Connect()
        {
            _postgreSQLDatabase.OpenPostgreSQLConnection();
        }

        // The Disconnect method is adapted to call ClosePostgreSQLConnection on the PostgreSQLDatabase instance.
        public void Disconnect()
        {
            _postgreSQLDatabase.ClosePostgreSQLConnection();
        }

        // The ExecuteQuery method is adapted to call RunPostgreSQLQuery on the PostgreSQLDatabase instance.
        public void ExecuteQuery(string query)
        {
            _postgreSQLDatabase.RunPostgreSQLQuery(query);
        }
    }

    // Client class - this class uses the IDatabase interface.
    public class Client
    {
        private readonly IDatabase _database;

        // The constructor takes an instance of IDatabase.
        public Client(IDatabase database)
        {
            _database = database;
        }

        // This method calls the Connect, ExecuteQuery, and Disconnect methods on the IDatabase instance.
        public void PerformDatabaseOperations(string query)
        {
            _database.Connect();
            _database.ExecuteQuery(query);
            _database.Disconnect();
        }
    }

    // Main program to demonstrate the Adapter Pattern with different database adapters.
    class Program
    {
        static void Main(string[] args)
        {
            // Using the MySQL database
            MySQLDatabase mySQLDatabase = new MySQLDatabase();
            IDatabase mySQLAdapter = new MySQLAdapter(mySQLDatabase);
            Client client1 = new Client(mySQLAdapter);
            client1.PerformDatabaseOperations("SELECT * FROM users");

            // Using the PostgreSQL database
            PostgreSQLDatabase postgreSQLDatabase = new PostgreSQLDatabase();
            IDatabase postgreSQLAdapter = new PostgreSQLAdapter(postgreSQLDatabase);
            Client client2 = new Client(postgreSQLAdapter);
            client2.PerformDatabaseOperations("SELECT * FROM employees");
        }
    }
}

// Output:
// MySQL database connection opened.
// Executing MySQL query: SELECT * FROM users

// Förklaring: 
// I det här exemplet har vi två befintliga klasser, MySQLDatabase och PostgreSQLDatabase, 
// som har olika metoder för att ansluta till databasen och köra frågor.
// Vi skapar adapterklasser, MySQLAdapter och PostgreSQLAdapter, 
// som implementerar IDatabase-interface och anpassar de befintliga metoderna 
// till IDatabase-metoderna. Klienten använder IDatabase-interface för att
// ansluta till databasen, köra frågor och koppla från databasen.
// I huvudprogrammet skapar vi en instans av MySQLAdapter och en instans av
// PostgreSQLAdapter och skickar dem till klienten för att utföra databasoperationer.
// Klienten ansluter till databasen, kör en fråga och kopplar sedan från databasen.
// Detta möjliggör att klienten kan använda samma interface för att arbeta med
// olika databaser utan att behöva känna till de specifika detaljerna för varje databas.
// Adapter-mönstret används för att anpassa ett interface till ett annat.
// Det kan vara användbart när du vill använda en klass som har ett interface som inte
// passar med det interface som en klient förväntar sig. 

