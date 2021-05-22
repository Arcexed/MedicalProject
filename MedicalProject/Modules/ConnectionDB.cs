using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MedicalProject.DB
{
    public class ConnectionDB
    {
        public static string ip = "localhost";
        public static string databaseName = "MedicalDB";

        public static MySqlConnectionStringBuilder connectionStringBuilder;
        
        public static MySqlConnection conn;
        public static void GenerateCFG(string databaseLogin, string databasePassword)
        {
            connectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = ip,
                Database = databaseName,
                UserID = databaseLogin,
                Password = databasePassword,
                
                

            };
            conn = new MySqlConnection(connectionStringBuilder.ConnectionString);
        }
    }
    
}
