using System;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// Enum representing supported database types.
    /// </summary>
    public enum DatabaseType
    {
        MySQL,
        SQLServer,
        MongoDB,
        SQLite,
        LocalDB,
        Firebase
    }

    /// <summary>
    /// Fluent builder for constructing connection strings for various database types.
    /// </summary>
    public class ConnectionStringBuilder
    {
        private string username;
        private string password;
        private string server;
        private int? port;
        private string databaseName;
        private bool integratedSecurity = true;
        private string filename;
        private int version = 3;
        private DatabaseType databaseType;

        /// <summary>
        /// Sets the username for the connection.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetUsername(string username)
        {
            this.username = username;
            return this;
        }

        /// <summary>
        /// Sets the password for the connection.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        /// <summary>
        /// Sets the server and optionally the port for the connection.
        /// </summary>
        /// <param name="server">The server string, optionally including port.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetServer(string server)
        {
            ParseServerAndPort(server);
            return this;
        }

        /// <summary>
        /// Sets the port for the connection.
        /// </summary>
        /// <param name="port">The port number.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetPort(int port)
        {
            this.port = port;
            return this;
        }

        /// <summary>
        /// Sets the type of database for the connection.
        /// </summary>
        /// <param name="databaseType">The database type.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetDatabaseType(DatabaseType databaseType)
        {
            this.databaseType = databaseType;
            return this;
        }

        /// <summary>
        /// Sets the database name for the connection.
        /// </summary>
        /// <param name="databaseName">The database name.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetDatabaseName(string databaseName)
        {
            this.databaseName = databaseName;
            return this;
        }

        /// <summary>
        /// Sets the integrated security option for the connection.
        /// </summary>
        /// <param name="integratedSecurity">The integrated security option.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetIntegratedSecurity(bool integratedSecurity)
        {
            this.integratedSecurity = integratedSecurity;
            return this;
        }

        /// <summary>
        /// Sets the filename for SQLite connection.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetFilename(string filename)
        {
            this.filename = filename;
            return this;
        }

        /// <summary>
        /// Sets the version for SQLite connection.
        /// </summary>
        /// <param name="version">The version number.</param>
        /// <returns>The ConnectionStringBuilder instance.</returns>
        public ConnectionStringBuilder SetVersion(int version)
        {
            this.version = version;
            return this;
        }

        /// <summary>
        /// Parses the server string to extract the server and port.
        /// </summary>
        /// <param name="server">The server string.</param>
        private void ParseServerAndPort(string server)
        {
            var parts = server.Split(':');
            this.server = parts[0];
            if (parts.Length > 1 && int.TryParse(parts[1], out int parsedPort))
            {
                this.port = parsedPort;
            }
        }

        /// <summary>
        /// Builds the connection string based on the specified parameters.
        /// </summary>
        /// <returns>The constructed connection string.</returns>
        public string Build()
        {
            SetDefaultServerAndPort();
            ValidateParameters();

            return databaseType switch
            {
                DatabaseType.MySQL => BuildMySQLConnectionString(),
                DatabaseType.SQLServer => BuildSQLServerConnectionString(),
                DatabaseType.MongoDB => BuildMongoDBConnectionString(),
                DatabaseType.SQLite => BuildSQLiteConnectionString(),
                DatabaseType.LocalDB => BuildLocalDBConnectionString(),
                DatabaseType.Firebase => BuildFirebaseConnectionString(),
                _ => throw new NotSupportedException("Database type not supported.")
            };
        }

        /// <summary>
        /// Sets default values for server and port based on the database type.
        /// </summary>
        private void SetDefaultServerAndPort()
        {
            if (string.IsNullOrEmpty(server))
            {
                switch (databaseType)
                {
                    case DatabaseType.MySQL:
                        server = "localhost";
                        port = port ?? 3306;
                        break;
                    case DatabaseType.SQLServer:
                        server = "localhost";
                        port = port ?? 1433;
                        break;
                    case DatabaseType.MongoDB:
                        server = "localhost";
                        port = port ?? 27017;
                        break;
                    case DatabaseType.SQLite:
                        server = null;
                        port = null;
                        break;
                    case DatabaseType.LocalDB:
                        server = "MSSQLLocalDB";
                        port = null;
                        break;
                    case DatabaseType.Firebase:
                        server = "myFirebaseServer";
                        port = null;
                        break;
                }
            }
        }

        /// <summary>
        /// Validates that the necessary parameters are set.
        /// </summary>
        private void ValidateParameters()
        {
            if (string.IsNullOrEmpty(server) && databaseType != DatabaseType.SQLite)
            {
                throw new InvalidOperationException("Server is required.");
            }

            if (databaseType != DatabaseType.SQLite && databaseType != DatabaseType.LocalDB && databaseType != DatabaseType.Firebase &&
                (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
            {
                throw new InvalidOperationException("Username and password are required for non-SQLite, non-LocalDB, and non-Firebase databases.");
            }
        }

        /// <summary>
        /// Builds a MySQL connection string.
        /// </summary>
        /// <returns>The MySQL connection string.</returns>
        private string BuildMySQLConnectionString()
        {
            var connectionString = new StringBuilder($"Server={server};Database={databaseName ?? "myDataBase"};User Id={username};Password={password};");
            if (port.HasValue) connectionString.Append($"Port={port};");
            return connectionString.ToString();
        }

        /// <summary>
        /// Builds a SQL Server connection string.
        /// </summary>
        /// <returns>The SQL Server connection string.</returns>
        private string BuildSQLServerConnectionString()
        {
            var connectionString = new StringBuilder($"Server={server}");
            if (port.HasValue) connectionString.Append($",{port}");
            connectionString.Append($";Database={databaseName ?? "myDataBase"};User Id={username};Password={password};");
            return connectionString.ToString();
        }

        /// <summary>
        /// Builds a MongoDB connection string.
        /// </summary>
        /// <returns>The MongoDB connection string.</returns>
        private string BuildMongoDBConnectionString()
        {
            var connectionString = new StringBuilder($"mongodb://{username}:{password}@{server}");
            if (port.HasValue) connectionString.Append($":{port}");
            connectionString.Append($"/{databaseName ?? "myDataBase"}");
            return connectionString.ToString();
        }

        /// <summary>
        /// Builds a SQLite connection string.
        /// </summary>
        /// <returns>The SQLite connection string.</returns>
        private string BuildSQLiteConnectionString()
        {
            var connectionString = new StringBuilder($"Data Source={filename ?? "myDatabase.db"};Version={version};");
            if (!string.IsNullOrEmpty(password)) connectionString.Append($"Password={password};");
            return connectionString.ToString();
        }

        /// <summary>
        /// Builds a LocalDB connection string.
        /// </summary>
        /// <returns>The LocalDB connection string.</returns>
        private string BuildLocalDBConnectionString()
        {
            var connectionString = new StringBuilder($"Server=(localdb)\\{server};Integrated Security={integratedSecurity};");
            if (!integratedSecurity) connectionString.Append($"User Id={username};Password={password};");
            return connectionString.ToString();
        }

        /// <summary>
        /// Builds a Firebase connection string.
        /// </summary>
        /// <returns>The Firebase connection string.</returns>
        private string BuildFirebaseConnectionString()
        {
            var connectionString = new StringBuilder($"https://{server}.firebaseio.com/");
            if (!string.IsNullOrEmpty(username)) connectionString.Append($"auth={username}:{password}");
            return connectionString.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mySqlConnectionString = new ConnectionStringBuilder()
                .SetDatabaseType(DatabaseType.MySQL)
                .SetUsername("myUsername")
                .SetPassword("myPassword")
                .SetDatabaseName("myDatabase")
                .Build();

            Console.WriteLine("MySQL Connection String: " + mySqlConnectionString);

            var sqlServerConnectionString = new ConnectionStringBuilder()
                .SetDatabaseType(DatabaseType.SQLServer)
                .SetUsername("myUsername")
                .SetPassword("myPassword")
                .SetDatabaseName("myDatabase")
                .Build();

            Console.WriteLine("SQL Server Connection String: " + sqlServerConnectionString);

            var mongoDBConnectionString = new ConnectionStringBuilder()
                .SetDatabaseType(DatabaseType.MongoDB)
                .SetUsername("myUsername")
                .SetPassword("myPassword")
                .SetServer("localhost:27017")
                .SetDatabaseName("myDatabase")
                .Build();

            Console.WriteLine("MongoDB Connection String: " + mongoDBConnectionString);

            var sqliteConnectionString = new ConnectionStringBuilder()
                .SetDatabaseType(DatabaseType.SQLite)
                .SetFilename("myDatabase.db")
                .SetPassword("myPassword")
                .Build();

            Console.WriteLine("SQLite Connection String: " + sqliteConnectionString);

            var localDBConnectionString = new ConnectionStringBuilder()
                .SetDatabaseType(DatabaseType.LocalDB)
                .SetServer("MSSQLLocalDB")
                .SetIntegratedSecurity(true)
                .Build();

            Console.WriteLine("LocalDB Connection String: " + localDBConnectionString);

            var firebaseConnectionString = new ConnectionStringBuilder()
                .SetDatabaseType(DatabaseType.Firebase)
                .SetUsername("myUsername")
                .SetPassword("myPassword")
                .Build();

            Console.WriteLine("Firebase Connection String: " + firebaseConnectionString);
        }
    }
}
