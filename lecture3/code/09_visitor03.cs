/*
Förklaringar till koden
IDatabaseVisitor: Gränssnitt för besökare som definierar metoder för att besöka olika typer av databaser.
IDatabase: Gränssnitt för element som kan acceptera en besökare.
SqlDatabase: Konkret element för SQL-databaser.
NoSqlDatabase: Konkret element för NoSQL-databaser.
DatabaseBackupVisitor: Konkret besökare som hanterar och säkerhetskopierar databaser.
*/

using System;

/* Gränssnitt för besökare */
public interface IDatabaseVisitor
{
    void Visit(SqlDatabase sqlDatabase);
    void Visit(NoSqlDatabase noSqlDatabase);
}

/* Gränssnitt för element som kan acceptera en besökare */
public interface IDatabase
{
    void Accept(IDatabaseVisitor visitor);
}

/* Konkret element för SQL-databas */
public class SqlDatabase : IDatabase
{
    public string ConnectionString { get; set; }

    public SqlDatabase(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public void Accept(IDatabaseVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret element för NoSQL-databas */
public class NoSqlDatabase : IDatabase
{
    public string ConnectionString { get; set; }

    public NoSqlDatabase(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public void Accept(IDatabaseVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret besökare som hanterar databasoperationer */
public class DatabaseBackupVisitor : IDatabaseVisitor
{
    public void Visit(SqlDatabase sqlDatabase)
    {
        Console.WriteLine($"Backing up SQL Database with connection string: {sqlDatabase.ConnectionString}");
    }

    public void Visit(NoSqlDatabase noSqlDatabase)
    {
        Console.WriteLine($"Backing up NoSQL Database with connection string: {noSqlDatabase.ConnectionString}");
    }
}

/* Programklass för att demonstrera databaser med Visitor-mönstret */
class Program
{
    static void Main()
    {
        IDatabase sqlDatabase = new SqlDatabase("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        IDatabase noSqlDatabase = new NoSqlDatabase("mongodb://localhost:27017");

        IDatabaseVisitor backupVisitor = new DatabaseBackupVisitor();

        sqlDatabase.Accept(backupVisitor);
        noSqlDatabase.Accept(backupVisitor);
    }
}
