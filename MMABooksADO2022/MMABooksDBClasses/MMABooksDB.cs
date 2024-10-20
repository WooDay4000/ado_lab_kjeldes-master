using System;

using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MMABooksDBClasses
{
    public static class MMABooksDB
    {
        // This method then uses the string made to connect to the
        // server so that information stored can be read and changed.
        public static MySqlConnection GetConnection()
        {
            string connectionString = GetMySqlConnectionString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;

        }
        // Gets the information and makes a string to the sql server.
        private static string GetMySqlConnectionString()
        {
            string folder = System.AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                    .SetBasePath(folder)
                    .AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true);

            string connectionString = builder.Build().GetConnectionString("mySql");

            return connectionString;
        }
    }
}
