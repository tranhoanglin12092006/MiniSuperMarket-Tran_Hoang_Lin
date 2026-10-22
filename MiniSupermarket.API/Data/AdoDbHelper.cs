using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace MiniSupermarket.API.Data
{
    public static class AdoDbHelper
    {
        public static bool IsMySql(string connectionString)
        {
            return !string.IsNullOrEmpty(connectionString) && (
                connectionString.Contains("Port=3306") || 
                connectionString.Contains("User=") || 
                connectionString.Contains("uid=") || 
                connectionString.Contains("3306")
            );
        }

        public static DbConnection CreateConnection(string connectionString)
        {
            if (IsMySql(connectionString))
            {
                return new MySqlConnection(connectionString);
            }
            return new SqlConnection(connectionString);
        }

        public static DbDataAdapter CreateDataAdapter(DbCommand command, string connectionString)
        {
            if (IsMySql(connectionString))
            {
                return new MySqlDataAdapter((MySqlCommand)command);
            }
            return new SqlDataAdapter((SqlCommand)command);
        }

        public static DbParameter AddParam(DbCommand command, string name, object? value)
        {
            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            command.Parameters.Add(p);
            return p;
        }
    }
}
