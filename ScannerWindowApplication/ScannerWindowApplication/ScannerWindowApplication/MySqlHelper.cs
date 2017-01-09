using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ScannerWindowApplication
{
    public class MySqlHelper
    {
        private string ConnectionString { get; set; }

        public static MySqlHelper Instance { get; set; }

        public MySqlHelper()
        {
        }

        public MySqlHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static void Initialize(string connectionString)
        {
            Instance = new MySqlHelper(connectionString);
        }

        public int ExecuteNonQuery(string query, CommandType commandType = CommandType.Text)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.CommandType = commandType;
                return command.ExecuteNonQuery();
            }
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
        }

        public DataTable GetDataTable(string query, CommandType commandType = CommandType.Text)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.CommandType = commandType;
                using (var reader = command.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public DataTable GetDataTable(SqlCommand command)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                using (var reader = command.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }


        public string ExecuteScalar(string query, CommandType commandType = CommandType.Text)
        {
            var table = GetDataTable(query);
            return table.Rows[0][0].ToString();
        }

        public string ExecuteScalar(SqlCommand command)
        {
            var table = GetDataTable(command);
            return table.Rows[0][0].ToString();
        }
    }
}