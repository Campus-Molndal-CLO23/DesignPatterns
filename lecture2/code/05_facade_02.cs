using System;
using System.Data.SqlClient;

namespace FacadePatternExample2
{
    // Subsystem classes
    public class DatabaseConnector
    {
        public SqlConnection Connect(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }

    public class DatabaseCommand
    {
        public void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecuteQuery(SqlConnection connection, string query)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                return command.ExecuteReader();
            }
        }
    }

    public class DatabaseDisconnector
    {
        public void Disconnect(SqlConnection connection)
        {
            connection.Close();
        }
    }

    // Facade class
    public class DatabaseManager
    {
        private DatabaseConnector _connector;
        private DatabaseCommand _command;
        private DatabaseDisconnector _disconnector;

        public DatabaseManager()
        {
            _connector = new DatabaseConnector();
            _command = new DatabaseCommand();
            _disconnector = new DatabaseDisconnector();
        }

        public void ExecuteNonQuery(string connectionString, string query)
        {
            var connection = _connector.Connect(connectionString);
            _command.ExecuteNonQuery(connection, query);
            _disconnector.Disconnect(connection);
        }

        public void ExecuteQuery(string connectionString, string query)
        {
            var connection = _connector.Connect(connectionString);
            var reader = _command.ExecuteQuery(connection, query);
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();
            _disconnector.Disconnect(connection);
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here";
            string createTableQuery = "CREATE TABLE TestTable (ID INT, Name NVARCHAR(50))";
            string insertDataQuery = "INSERT INTO TestTable (ID, Name) VALUES (1, 'John Doe')";
            string selectDataQuery = "SELECT Name FROM TestTable";

            DatabaseManager dbManager = new DatabaseManager();
            dbManager.ExecuteNonQuery(connectionString, createTableQuery);
            dbManager.ExecuteNonQuery(connectionString, insertDataQuery);
            dbManager.ExecuteQuery(connectionString, selectDataQuery);
        }
    }
}

// Output:
// John Doe


// Förklaring:
// I detta exempel har vi fyra klasser: DatabaseConnector, DatabaseCommand, 
// DatabaseDisconnector och DatabaseManager.
// DatabaseConnector klassen hanterar anslutningen till databasen,
// DatabaseCommand klassen hanterar att köra frågor mot databasen,
// DatabaseDisconnector klassen hanterar att koppla från databasen,
// och DatabaseManager klassen är en fasadklass som samordnar anslutning,
// fråga och frånkoppling av databasen.
// I klienten skapas en instans av DatabaseManager och används för att
// skapa en tabell, lägga till data i tabellen och hämta data från tabellen.
// Genom att använda en fasadklass kan klienten interagera med flera
// underliggande klasser genom ett enkelt gränssnitt utan att behöva känna
// till de interna detaljerna i varje klass. 