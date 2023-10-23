using StoreWithDataBases.Check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreWithDataBases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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

        private void Registration_Redirect(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void Click_LogIn(object sender, RoutedEventArgs e)
        {
            if(checkUser.CheckUserToDataBase(tbUserName.Text, tbPassword.Password))
            {
                MessageBox.Show("User not found" +
                    "\ncheck UserName and Password" +
                    "\nor pass register", 
                    "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error );
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
