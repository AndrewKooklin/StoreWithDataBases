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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        public AddProductWindow(DataRow dataRow) : this()
        {
            btnCancel.Click += delegate { this.DialogResult = false; };
            btnClearForm.Click += delegate
            {
                tbEMail.Text = "";
                tbProductCode.Text = "";
                tbProductName.Text = "";
            };

            btnAddProduct.Click += delegate
            {
                dataRow["EMail"] = tbEMail.Text;
                dataRow["ProductCode"] = tbProductCode.Text;
                dataRow["ProductName"] = tbProductName.Text;
                this.DialogResult = !false;
            };
        }
    }
}
