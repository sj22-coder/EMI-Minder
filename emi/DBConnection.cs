using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emi
{
    public static class DBConnection
    {
        public static string connectionString =
            @"Data Source=YOUR_SERVER_NAME;Initial Catalog=EMIDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
