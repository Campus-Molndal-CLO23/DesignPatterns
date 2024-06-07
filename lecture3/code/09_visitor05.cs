using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SQLiteExtensions
{
    public static class SQLiteExtensions
    {
        /// <summary>
        /// Executes a query and returns the result as a list of dictionaries.
        /// Each dictionary represents a row, with column names as keys.
        /// </summary>
        /// <param name="connection">The SQLite connection.</param>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>A list of dictionaries representing the result set.</returns>
        public static List<Dictionary<string, object>> ExecuteQueryToList(this SQLiteConnection connection, string query, Dictionary<string, object> parameters = null)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                    }
                }

                using (var reader = command.ExecuteReader())
                {
                    var result = new List<Dictionary<string, object>>();
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                        }
                        result.Add(row);
                    }
                    return result;
                }
            }
        }

        /// <summary>
        /// Executes a non-query command such as INSERT, UPDATE, or DELETE.
        /// </summary>
        /// <param name="connection">The SQLite connection.</param>
        /// <param name="query">The SQL command to execute.</param>
        /// <param name="parameters">The parameters to use in the command.</param>
        /// <returns>The number of rows affected.</returns>
        public static int ExecuteNonQuery(this SQLiteConnection connection, string query, Dictionary<string, object> parameters = null)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                    }
                }
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a scalar query and returns the result.
        /// </summary>
        /// <param name="connection">The SQLite connection.</param>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">The parameters to use in the query.</param>
        /// <returns>The scalar result.</returns>
        public static object ExecuteScalar(this SQLiteConnection connection, string query, Dictionary<string, object> parameters = null)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
                    }
                }
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Converts a DataTable to a list of dictionaries for offline use.
        /// Each dictionary represents a row, with column names as keys.
        /// </summary>
        /// <param name="dataTable">The DataTable to convert.</param>
        /// <returns>A list of dictionaries representing the DataTable.</returns>
        public static List<Dictionary<string, object>> ToList(this DataTable dataTable)
        {
            var result = new List<Dictionary<string, object>>();
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, object>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    dictionary[column.ColumnName] = row[column] == DBNull.Value ? null : row[column];
                }
                result.Add(dictionary);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SQLiteExtensions;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=mydatabase.db;Version=3;";
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Example of executing a query and getting the result as a list of dictionaries
            string query = "SELECT * FROM Users WHERE Age > @age";
            var parameters = new Dictionary<string, object> { { "@age", 18 } };
            List<Dictionary<string, object>> users = connection.ExecuteQueryToList(query, parameters);

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user["ID"]}, Name: {user["Name"]}, Age: {user["Age"]}");
            }

            // Example of executing a non-query command
            string insertQuery = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";
            var insertParameters = new Dictionary<string, object> { { "@name", "John Doe" }, { "@age", 25 } };
            int rowsAffected = connection.ExecuteNonQuery(insertQuery, insertParameters);
            Console.WriteLine($"Rows affected: {rowsAffected}");

            // Example of executing a scalar query
            string scalarQuery = "SELECT COUNT(*) FROM Users";
            object count = connection.ExecuteScalar(scalarQuery);
            Console.WriteLine($"Total users: {count}");
        }
    }
}

