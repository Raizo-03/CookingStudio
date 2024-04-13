using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Add this namespace for MySQL

namespace CookingStudio.database
{
    public class DatabaseManager
    {
        private string connectionString; // Connection string to your database

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExecuteNonQuery(string query, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
