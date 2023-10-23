using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWithDataBases.Data
{
    public class ConnectToSQLDB
    {
        static string con = StoreWithDataBases.Properties.Settings.Default.SQLBase;

        SqlConnection sqlConnection = new SqlConnection(con);

        public void OpenSQLConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseSQLConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }
    }
}
