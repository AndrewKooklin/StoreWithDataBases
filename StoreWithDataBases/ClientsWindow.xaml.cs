using StoreWithDataBases.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreWithDataBases
{
    /// <summary>
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        SqlDataAdapter sqlDA;
        DataTable dT;
        DataRowView rowView;
        ConnectToSQLDB connectToSQLDB;
        public ClientsWindow()
        {
            InitializeComponent();
            CreateCommands();
        }

        private void CreateCommands()
        {
            dT = new DataTable();
            sqlDA = new SqlDataAdapter();

            //SelectCommand
            string query = $"SELECT Id, LastName, FirstName, FathersName," +
                            $"PhoneNumber, EMail FROM Clients";
            connectToSQLDB = new ConnectToSQLDB();
            sqlDA.SelectCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());
            //EndSelectCommand

            //InsertCommand
            query = @"INSERT INTO Clients (LastName, FirstName, FathersName, PhoneNumber, EMail) 
                                 VALUES (@LastName, @FirstName,  @FathersName,  @PhoneNumber, @EMail);
                                SET @Id = @@IDENTITY;";

            sqlDA.InsertCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());

            sqlDA.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
            sqlDA.InsertCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            sqlDA.InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            sqlDA.InsertCommand.Parameters.Add("@FathersName", SqlDbType.VarChar, 50, "FathersName");
            sqlDA.InsertCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50, "PhoneNumber");
            sqlDA.InsertCommand.Parameters.Add("@EMail", SqlDbType.VarChar, 50, "EMail");
            //EndInsertCommand

            //UpdateCommand
            query = @"UPDATE Clients SET 
                           LastName = @wLastName,
                           FirstName = @FirstName, 
                           FathersName = @FathersName,
                           PhoneNumber = @PhoneNumber,
                           EMail = @EMail 
                    WHERE Id = @Id";

            sqlDA.UpdateCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());
            sqlDA.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").SourceVersion = DataRowVersion.Original;
            sqlDA.UpdateCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            sqlDA.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            sqlDA.UpdateCommand.Parameters.Add("@FathersName", SqlDbType.VarChar, 50, "FathersName");
            sqlDA.UpdateCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50, "PhoneNumber");
            sqlDA.UpdateCommand.Parameters.Add("@EMail", SqlDbType.VarChar, 50, "EMail");
            //EndUpdateCommand

            //DeleteCommand
            query = "DELETE FROM Clients WHERE Id = @Id";

            sqlDA.DeleteCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());
            sqlDA.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            //EndDeleteCommand

            sqlDA.Fill(dT);
            dgClients.DataContext = dT.DefaultView;
        }

        private void CurrentCell_Changed(object sender, EventArgs e)
        {
            if (rowView == null) return;
            rowView.EndEdit();
            sqlDA.Update(dT);
        }

        private void CellEdit_Ending(object sender, DataGridCellEditEndingEventArgs e)
        {
            rowView = (DataRowView)dgClients.SelectedItem;
            rowView.BeginEdit();
        }

        private void MIAddClient_Click(object sender, RoutedEventArgs e)
        {
            DataRow dR = dT.NewRow();
            AddClientWindow addClientWindow = new AddClientWindow(dR);
            addClientWindow.ShowDialog();


            if (addClientWindow.DialogResult.Value)
            {
                dT.Rows.Add(dR);
                sqlDA.Update(dT);
            }
        }

        private void MIDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (dgClients.SelectedIndex == -1 || rowView == null)
            {
                MessageBox.Show("Выберите клиента", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                rowView = (DataRowView)dgClients.SelectedItem;
                rowView.Row.Delete();
                sqlDA.Update(dT);
            }
        }

        private void ClientsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgClients.SelectedItem = null;
        }

        private void ClientsWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            connectToSQLDB.CloseSQLConnection();
            dgClients.DataContext = null;
        }

        private void ShowClientProducts_Click(object sender, RoutedEventArgs e)
        {
            string email = "";

            if (dgClients.SelectedIndex == -1 || dgClients.SelectedIndex == dT.Rows.Count)
            {
                MessageBox.Show("Выберите клиента", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                int selectedNumber = dgClients.SelectedIndex;
                //rowView = (DataRowView)dgClients.SelectedItem;
                //email = dT.Rows[selectedNumber]["EMail"].ToString();
            }

            ProductsClient pc = new ProductsClient();
            pc.Show();
        }

        private void ShowAllPurchases_Click(object sender, RoutedEventArgs e)
        {
            AllPurchasesWindow aPW = new AllPurchasesWindow();
            aPW.Show();
        }
    }
}
