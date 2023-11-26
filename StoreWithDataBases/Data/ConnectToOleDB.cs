using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWithDataBases.Data
{
    public class ConnectToOleDB
    {
        static string con = StoreWithDataBases.Properties.Settings.Default.OleDbBase;

        OleDbConnection oleDbConnection = new OleDbConnection(con);

        public void OpenOleDBConnection()
        {
            if (oleDbConnection.State == ConnectionState.Closed)
            {
                oleDbConnection.Open();
            }
        }

        public void CloseOleDBConnection()
        {
            if (oleDbConnection.State == ConnectionState.Open)
            {
                oleDbConnection.Close();
            }
        }

        public OleDbConnection GetOleDBConnection()
        {
            return oleDbConnection;
        }
    }
}
