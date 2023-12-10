using StoreWithDataBases.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataBases
{
    /// <summary>
    /// Окно со списком покупок клиента
    /// </summary>
    public partial class ProductsClient : Window
    {
        OleDbDataAdapter oleDA;
        DataTable dT;
        DataRowView rowView;
        ConnectToOleDB connectToOleDB;

        public string Email { get; }

        public ProductsClient()
        {
            InitializeComponent();
            CreateCommands();
        }

        public ProductsClient(string email)
        {
            Email = email;
            InitializeComponent();
            CreateCommands();
        }

        /// <summary>
        /// Регистрация команд CRUD 
        /// </summary>
        private void CreateCommands()
        {
            dT = new DataTable();
            oleDA = new OleDbDataAdapter();
            string query = "";

            //SelectCommand
            if (String.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Отсутствует E-mail клиента", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                query = $"SELECT Id, EMail, ProductCode, ProductName " +
                            $"FROM AllPurchasesClients WHERE EMail = '{Email}'";
            }
            
            connectToOleDB = new ConnectToOleDB();
            oleDA.SelectCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            //EndSelectCommand

            //InsertCommand
            query = @"INSERT INTO AllPurchasesClients (EMail, ProductCode, ProductName) VALUES (?, ?, ?)";

            oleDA.InsertCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());

            //oleDA.InsertCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id");
            oleDA.InsertCommand.Parameters.Add("@EMail", OleDbType.VarChar, 50, "EMail");
            oleDA.InsertCommand.Parameters.Add("@ProductCode", OleDbType.VarChar, 50, "ProductCode");
            oleDA.InsertCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 50, "ProductName");
            //EndInsertCommand

            //UpdateCommand
            query = @"UPDATE AllPurchasesClients SET EMail = ?, ProductCode = ?, ProductName = ? WHERE Id = ? ";

            oleDA.UpdateCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            oleDA.UpdateCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id").SourceVersion = DataRowVersion.Original;
            oleDA.UpdateCommand.Parameters.Add("@EMail", OleDbType.VarChar, 50, "EMail");
            oleDA.UpdateCommand.Parameters.Add("@ProductCode", OleDbType.VarChar, 50, "ProductCode");
            oleDA.UpdateCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 50, "ProductName");
            //EndUpdateCommand

            //DeleteCommand
            query = "DELETE FROM AllPurchasesClients WHERE Id = ?";

            oleDA.DeleteCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            oleDA.DeleteCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id");
            //EndDeleteCommand

            oleDA.Fill(dT);
            dgClientProducts.DataContext = dT.DefaultView;
        }

        /// <summary>
        /// Действия при нажатии кнопки "Добавить" 
        /// </summary>
        private void BAddProduct_Click(object sender, RoutedEventArgs e)
        {
            DataRow dR = dT.NewRow();
            AddProductWindow addProductWindow = new AddProductWindow(dR, Email);
            
            addProductWindow.ShowDialog();

            if (addProductWindow.DialogResult.Value)
            {
                dT.Rows.Add(dR);
                oleDA.Update(dT);
            }
        }

        /// <summary>
        /// Действия при изменении ячейки 
        /// </summary>
        private void CurrentCell_Changed(object sender, EventArgs e)
        {
            if (rowView == null) return;
            rowView.EndEdit();
            oleDA.Update(dT);
        }

        /// <summary>
        /// Действия при окончании редактирования ячейки 
        /// </summary>
        private void CellEdit_Ending(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            rowView = (DataRowView)dgClientProducts.SelectedItem;
            rowView.BeginEdit();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Удалить" 
        /// </summary>
        private void BDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgClientProducts.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите продукт", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                rowView = (DataRowView)dgClientProducts.SelectedItem;
                rowView.Row.Delete();
                oleDA.Update(dT);
            }
        }

        /// <summary>
        /// Действия при загрузке окна 
        /// </summary>
        private void ProductsClientWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgClientProducts.SelectedItem = null;
        }

        /// <summary>
        /// Действия при выгрузке окна 
        /// </summary>
        private void ProductsClientWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            connectToOleDB.CloseOleDBConnection();
            dgClientProducts.DataContext = null;
        }
    }
}
