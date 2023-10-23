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

                if(user == null || pass == null)
                {
                    return true;
                }

                if (user.ToString().Equals(userName) && pass.ToString().Equals(password))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connection to database({ex.Message})", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }

        public bool CheckValidationUserName(string input)
        {
            string userName = input;
            Regex regex = new Regex(@"^[0-9a-zA-Z]{5,}");

            if (regex.IsMatch(userName))
            {
                return true;
            }
            else return false;
        }

        public bool CheckValidationPassword(string input)
        {
            if (Regex.IsMatch(input, @"^(?=.*[0-9])(?=.*[A-Z])\w{5,}"))
            {
                return true;
            }
            else return false;
        }

        public bool CheckEqualPasswords(string password, string confirmPassword)
        {
            if (password.Equals(confirmPassword))
            {
                return true;
            }
            return false;
        }
    }
}
