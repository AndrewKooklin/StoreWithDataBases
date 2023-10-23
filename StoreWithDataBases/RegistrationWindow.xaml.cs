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

            if (!checkUser.CheckValidationUserName(tbUserName.Text))
            {
                MessageBox.Show("Username must be " +
                                "\nat least 5 characters",
                                "Require",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!checkUser.CheckValidationPassword(tbPassword.Password))
            {
                MessageBox.Show("Password must be at least " +
                                "\ncontain 5 characters, " +
                                "\nat least one small one," +
                                "\none capital," +
                                "\nand one digit", "Require",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(!checkUser.CheckEqualPasswords(tbPassword.Password, tbConfirmPassword.Password))
            {
                MessageBox.Show("Password and Confirm Password are not equals", "Require",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (checkUser.CheckUserToDataBase(tbUserName.Text, tbPassword.Password))
            {
                ConnectToSQLDB connectToSQLDB = new ConnectToSQLDB();
                try
                {
                    string query = $"INSERT INTO Users(UserName, Password) VALUES('{tbUserName.Text}', '{tbPassword.Password}')";
                    SqlCommand sqlCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());
                    connectToSQLDB.OpenSQLConnection();
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
            }
            else
            {
                MessageBox.Show("User is already registered," +
                    "\nenter through the Login form", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
