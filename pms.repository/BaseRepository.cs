using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pms.repository
{
    public abstract class BaseRepository
    {
        public static string GetConnectionString(string connStrName)
        {
            return ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;
        }
        public static IDbConnection OpenConnection(string connStrName)
        {
            IDbConnection connection = new SqlConnection(connStrName);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }
    }
}
