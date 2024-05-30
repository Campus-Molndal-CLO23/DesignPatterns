using System;

namespace ProxyPatternExample1
{
    // Subject interface
    public interface IDatabase
    {
        void Query(string sql);
    }

    // RealSubject - the actual database class
    public class RealDatabase : IDatabase
    {
        public void Query(string sql)
        {
            Console.WriteLine($"Executing query: {sql}");
        }
    }

    // Proxy - controls access to the RealDatabase
    public class DatabaseProxy : IDatabase
    {
        private RealDatabase _realDatabase;
        private string _username;
        private string _password;

        public DatabaseProxy(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void Query(string sql)
        {
            if (Authenticate())
            {
                if (_realDatabase == null)
                {
                    _realDatabase = new RealDatabase();
                }
                _realDatabase.Query(sql);
            }
            else
            {
                Console.WriteLine("Authentication failed. Access denied.");
            }
        }

        private bool Authenticate()
        {
            // Simulate authentication
            return _username == "admin" && _password == "password";
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase db = new DatabaseProxy("admin", "password");
            db.Query("SELECT * FROM users");

            IDatabase dbInvalid = new DatabaseProxy("user", "wrongpassword");
            dbInvalid.Query("SELECT * FROM users");
        }
    }
}

// Output:
// Executing query: SELECT * FROM users
// Authentication failed. Access denied.
//
// Koden visar ett exempel på Proxy-mönstret. 
// I exemplet finns en IDatabase-interface som definierar en Query-metod. 
// RealDatabase-klassen implementerar IDatabase och innehåller den faktiska 
// implementationen av Query-metoden. DatabaseProxy-klassen fungerar som en 
// proxy för RealDatabase och kontrollerar åtkomsten till den. Proxy-klassen 
// innehåller en instans av RealDatabase och en autentiseringsmekanism för att 
// kontrollera om användaren har behörighet att utföra frågor mot databasen. När 
// en Query-metod anropas på proxy-klassen, kontrolleras autentiseringen och om 
// den lyckas skapas en instans av RealDatabase och Query-metoden anropas på 
// den. Annars skrivs ett meddelande ut om att autentiseringen misslyckades och 
// åtkomst nekades.
