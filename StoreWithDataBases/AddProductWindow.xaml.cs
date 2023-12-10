using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public AddProductWindow(DataRow dataRow, string email) : this()
        {
            tbEMail.Text = email;

            btnCancel.Click += delegate { this.DialogResult = false; };
            btnClearForm.Click += delegate
            {
                tbEMail.Text = "";
                tbProductCode.Text = "";
                tbProductName.Text = "";
            };

            btnAddProduct.Click += delegate
            {
                if (String.IsNullOrWhiteSpace(tbEMail.Text.ToString()) ||
                    !Regex.IsMatch(tbEMail.Text.ToString(), "^\\S+@\\S+\\.\\S+$"))
                {
                    lErrorEmail.Content = "Введите \"E-mail\" в формате name@site.ru";
                    return;
                }
                else
                {
                    lErrorEmail.Content = "";
                }
                if (String.IsNullOrWhiteSpace(tbProductCode.Text.ToString()) ||
                    !Regex.IsMatch(tbProductCode.Text.ToString(), "^[0-9]{4}$"))
                {
                    lErrorProductCode.Content = "Введите \"Код продукта\" 4 цифры";
                    return;
                }
                else
                {
                    lErrorProductCode.Content = "";
                }
                if (String.IsNullOrWhiteSpace(tbProductName.Text.ToString()) ||
                        !Regex.IsMatch(tbProductName.Text.ToString(), "^[a-zA-Z0-9]{2,50}$"))
                {
                    lErrorProductName.Content = "Введите \"Наименование\" от 2 до 50 символов";
                    return;
                }
                else
                {
                    lErrorProductName.Content = "";
                }

                dataRow["EMail"] = tbEMail.Text;
                dataRow["ProductCode"] = tbProductCode.Text;
                dataRow["ProductName"] = tbProductName.Text;
                this.DialogResult = !false;
            };
        }
    }
}
