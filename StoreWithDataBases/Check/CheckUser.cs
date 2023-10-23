using StoreWithDataBases.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataBases.Check
{
    public class CheckUser
    {
        public bool CheckUserToDataBase(string userName, string password)
        {
            object user = null;
            object pass = null;
            ConnectToSQLDB connectToSQLDB = new ConnectToSQLDB();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string query = $"SELECT UserName, Password FROM Users WHERE UserName = '{userName}' AND Password = '{password}'";

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());
                connectToSQLDB.OpenSQLConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    user = sqlDataReader["UserName"];
                    pass = sqlDataReader["Password"];
                }

                sqlDataReader.Close();
                connectToSQLDB.CloseSQLConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connection to database({ex.Message})", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (user == null || pass == null)
            {
                return false;
            }
            else return true;
        }

        public bool CheckValidationUserName(string input)
        {
            string userName = input;
            Regex regex = new Regex(@"^(?=.*[^\s])[0-9a-zA-Z]{8,}");

            if (regex.IsMatch(userName))
            {
                return true;
            }
            else return false;
        }
    }
}
