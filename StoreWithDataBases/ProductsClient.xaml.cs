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
    /// Interaction logic for ProductsClient.xaml
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

        private void CreateCommands()
        {
            dT = new DataTable();
            oleDA = new OleDbDataAdapter();

            //SelectCommand
            string query = $"SELECT Id, EMail, ProductCode, ProductName " +
                            $"FROM ClientProducts";
            connectToOleDB = new ConnectToOleDB();
            oleDA.SelectCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            //EndSelectCommand

            //InsertCommand
            //query = @"INSERT INTO ClientProducts (EMail, ProductCode, ProductName) VALUES (@EMail, @ProductCode, @ProductName)";

            //oleDA.InsertCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());

            //oleDA.InsertCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id");
            //oleDA.InsertCommand.Parameters.Add("@EMail", OleDbType.VarChar, 50, "EMail");
            //oleDA.InsertCommand.Parameters.Add("@ProductCode", OleDbType.VarChar, 50, "ProductCode");
            //oleDA.InsertCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 50, "ProductName");
            //EndInsertCommand

            //UpdateCommand
            query = @"UPDATE ClientProducts SET EMail = @EMail, ProductCode = @ProductCode, ProductName = @ProductName WHERE Id = @Id";

            oleDA.UpdateCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            oleDA.UpdateCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id").SourceVersion = DataRowVersion.Original;
            oleDA.UpdateCommand.Parameters.Add("@EMail", OleDbType.VarChar, 50, "EMail");
            oleDA.UpdateCommand.Parameters.Add("@ProductCode", OleDbType.VarChar, 50, "ProductCode");
            oleDA.UpdateCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 50, "ProductName");
            //EndUpdateCommand

            //DeleteCommand
            //query = "DELETE FROM ClientProducts WHERE Id = @Id";

            //oleDA.DeleteCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            //oleDA.DeleteCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id");
            //EndDeleteCommand

            oleDA.Fill(dT);
            dgClientProducts.DataContext = dT.DefaultView;
        }

        private void BAddProduct_Click(object sender, RoutedEventArgs e)
        {
            DataRow dR = dT.NewRow();
            AddProductWindow addProductWindow = new AddProductWindow(dR);
            addProductWindow.ShowDialog();


            if (addProductWindow.DialogResult.Value)
            {
                dT.Rows.Add(dR);
                oleDA.Update(dT);
            }
        }

        private void CurrentCell_Changed(object sender, EventArgs e)
        {

        }

        private void CellEdit_Ending(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

        }

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

        private void ProductsClientWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgClientProducts.SelectedItem = null;
        }

        private void ProductsClientWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            connectToOleDB.CloseOleDBConnection();
            dgClientProducts.DataContext = null;
        }
    }
}
