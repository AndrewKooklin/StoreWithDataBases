using StoreWithDataBases.Check;
using StoreWithDataBases.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataBases
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Redirect(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Click_Registration(object sender, RoutedEventArgs e)
        {
            CheckUser checkUser = new CheckUser();
            //if(!checkUser.CheckUserToDataBase(tbUserName.Text, tbPassword.Password))
            //{
                ConnectToSQLDB connectToSQLDB = new ConnectToSQLDB();
                SqlConnection sqlConnection = connectToSQLDB.GetSqlConnection();
                try
                {
                    string query = $"INSERT INTO Users(UserName, Password) VALUES('{tbUserName.Text}', '{tbPassword.Password}')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                    //connectToSQLDB.OpenSQLConnection();
                    sqlCommand.ExecuteNonQuery();
                    connectToSQLDB.CloseSQLConnection();
                    MessageBox.Show("You succesfully registered", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Could not connect to database({ex.Message})", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MessageBox.Show("");
            //}
            //else
            //{
            //    MessageBox.Show("User is already registered," +
            //        "\nenter through the Login form", "Error",
            //            MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
