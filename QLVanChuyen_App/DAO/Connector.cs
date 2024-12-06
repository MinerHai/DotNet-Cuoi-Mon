using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVanChuyen_App.DAO
{
    internal class Connector
    {
        public SqlConnection GetConnection()
        {
            string? connectStr = "Server=localhost,1433;Database=QUANLYVANCHUYEN;User Id=sql_quanlyvanchuyen;Password=12345;Integrated Security=true; TrustServerCertificate=true;";
            SqlConnection connection = new SqlConnection(connectStr);
            return connection;
        }
    }
}
