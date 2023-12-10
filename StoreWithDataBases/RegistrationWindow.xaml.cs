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
    /// Окно регистрации пользователя
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public bool RememberMeIsChecked { get; set; }

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Log in" 
        /// </summary>
        private void LogIn_Redirect(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Registration" 
        /// </summary>
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

                    if (RememberMeIsChecked)
                    {
                        StoreWithDataBases.Properties.Settings.Default.UserName = tbUserName.Text.ToString();
                        StoreWithDataBases.Properties.Settings.Default.Password = tbPassword.Password.ToString();
                        StoreWithDataBases.Properties.Settings.Default.Save();
                    }

                    MessageBox.Show("You succesfully registered", "Registered",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Could not connect to database({ex.Message})", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("User is already registered," +
                    "\nenter through the Login form", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Действие при отметке чекбокса "Запомнить меня"
        /// </summary>
        private void RememberMe_Checked(object sender, RoutedEventArgs e)
        {
            RememberMeIsChecked = true;
        }

        /// <summary>
        /// Действие при очистке чекбокса "Запомнить меня"
        /// </summary>
        private void RememberMe_Unchecked(object sender, RoutedEventArgs e)
        {
            RememberMeIsChecked = false;
        }
    }
}
