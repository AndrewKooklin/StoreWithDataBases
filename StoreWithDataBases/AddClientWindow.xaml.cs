using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace StoreWithDataBases
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        public AddClientWindow(DataRow dataRow) : this()
        {
            btnCancel.Click += delegate { this.DialogResult = false; };
            btnClearForm.Click += delegate
            {
                tbLastName.Text = "";
                tbFirstName.Text = "";
                tbFathersName.Text = "";
                tbPhoneNumber.Text = "";
                tbEMail.Text = "";
            };

            btnAddClient.Click += delegate
            {
                dataRow["LastName"] = tbLastName.Text;
                dataRow["FirstName"] = tbFirstName.Text;
                dataRow["FathersName"] = tbFathersName.Text;
                dataRow["PhoneNumber"] = tbPhoneNumber.Text;
                dataRow["EMail"] = tbEMail.Text;
                this.DialogResult = !false;
            };
        }
    }
}
