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
                Regex regString = new Regex("^[a-zA-Z0-9]{3,50}$");

                if (String.IsNullOrWhiteSpace(tbLastName.Text.ToString()) || !regString.IsMatch(tbLastName.Text.ToString()))
                {
                    lErrorLastName.Content = "Введите \"Фамилию\" от 3 до 50 символов";
                    return;
                }
                else 
                { 
                    lErrorLastName.Content = ""; 
                }
                if (String.IsNullOrWhiteSpace(tbFirstName.Text.ToString()) || !regString.IsMatch(tbFirstName.Text.ToString()))
                {
                    lErrorFirstName.Content = "Введите \"Имя\" от 3 до 50 символов";
                    return;
                }
                else
                {
                    lErrorFirstName.Content = "";
                }
                if (String.IsNullOrWhiteSpace(tbFathersName.Text.ToString()) || 
                        !regString.IsMatch(tbFathersName.Text.ToString()))
                {
                    lErrorFathersName.Content = "Введите \"Отчество\" от 3 до 50 символов";
                    return;
                }
                else
                {
                    lErrorFathersName.Content = "";
                }
                if (String.IsNullOrWhiteSpace(tbPhoneNumber.Text.ToString()) || 
                    !Regex.IsMatch(tbPhoneNumber.Text.ToString(), "^[0-9]{11}$"))
                {
                    lErrorPhoneNumber.Content = "Введите \"Телефон\" 11 цифр";
                    return;
                }
                else
                {
                    lErrorPhoneNumber.Content = "";
                }
                if (String.IsNullOrWhiteSpace(tbEMail.Text.ToString()) ||
                    !Regex.IsMatch(tbEMail.Text.ToString(), "[a-zA-Z0-9](@)(.+).[a-zA-Z0-9]+$"))
                {
                    lErrorEMail.Content = "Введите \"E-mail\" в формате name@site.ru";
                    return;
                }
                else
                {
                    lErrorEMail.Content = "";
                }

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
