using StoreWithDataBases.Check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataBases
{
    /// <summary>
    /// Окно входа
    /// </summary>
    public partial class MainWindow : Window
    {
        CheckUser checkUser = new CheckUser();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_LogIn(object sender, RoutedEventArgs e)
        {
            tbUserName.Text = StoreWithDataBases.Properties.Settings.Default.UserName;

            tbPassword.Password = StoreWithDataBases.Properties.Settings.Default.Password;
        }

        /// <summary>
        /// Действия при нажатии кнопки "Зарегистрироваться" 
        /// </summary>
        private void Registration_Redirect(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Log in" 
        /// </summary>
        private void Click_LogIn(object sender, RoutedEventArgs e)
        {
            if (checkUser.CheckUserToDataBase(tbUserName.Text, tbPassword.Password))
            {
                MessageBox.Show("User not found" +
                    "\ncheck UserName and Password" +
                    "\nor pass register",
                    "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.Hide();
                ClientsWindow clientsWindow = new ClientsWindow();
                clientsWindow.Show();
                MessageBox.Show("You have successfully log in",
                    "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
