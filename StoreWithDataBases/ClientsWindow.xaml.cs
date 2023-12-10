using StoreWithDataBases.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StoreWithDataBases
{
    /// <summary>
    /// Окно со списком клиентов
    /// </summary>
    public partial class ClientsWindow : Window
    {
        SqlDataAdapter sqlDA;
        OleDbDataAdapter oleDbDA;
        DataTable dT;
        DataRowView rowView;
        ConnectToSQLDB connectToSQLDB;
        ConnectToOleDB connectToOleDB;
        public ClientsWindow()
        {
            InitializeComponent();
            CreateCommands();
        }

        /// <summary>
        /// Метод формирования команд CRUD
        /// </summary>
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
                           LastName = @LastName,
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

        /// <summary>
        /// Действия при изменении ячейки 
        /// </summary>
        private void CurrentCell_Changed(object sender, EventArgs e)
        {
            if (rowView == null) return;
            rowView.EndEdit();
            sqlDA.Update(dT);
        }

        /// <summary>
        /// Действия при окончании редактирования ячейки 
        /// </summary>
        private void CellEdit_Ending(object sender, DataGridCellEditEndingEventArgs e)
        {
            rowView = (DataRowView)dgClients.SelectedItem;
            rowView.BeginEdit();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Добавить" 
        /// </summary>
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

        /// <summary>
        /// Действия при нажатии кнопки "Удалить" 
        /// </summary>
        private void MIDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            string email = "";

            if (dgClients.SelectedIndex == -1 || dgClients.SelectedIndex == dT.Rows.Count)
            {
                MessageBox.Show("Выберите клиента", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                var result = MessageBox.Show("При удалении клиента" +
                    "\nбудут удалены все его покупки." +
                    "\nВы уверены, что хотите" +
                    "\nудалить клиента?", "Удаление клиента и его покупок", 
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Cancel || result == MessageBoxResult.No)
                {
                    return;
                }
                if (result == MessageBoxResult.Yes)
                {
                    connectToOleDB = new ConnectToOleDB();
                    oleDbDA = new OleDbDataAdapter();
                    try
                    {
                        int selectedNumber = dgClients.SelectedIndex;
                        email = dT.Rows[selectedNumber]["EMail"].ToString();
                        using (connectToOleDB.GetOleDBConnection())
                        {
                            string query = $"DELETE FROM AllPurchasesClients WHERE EMail = '{email}'";
                            connectToOleDB.OpenOleDBConnection();
                            oleDbDA.DeleteCommand = connectToOleDB.CreateCommandOleDBConnection();
                            //sqlDA.DeleteCommand.Parameters.Add("@EMail", SqlDbType.VarChar, 50, email);
                            oleDbDA.DeleteCommand.CommandText = query;
                            int rows = oleDbDA.DeleteCommand.ExecuteNonQuery();
                            connectToOleDB.CloseOleDBConnection();
                            if (rows <= 0)
                            {
                                MessageBox.Show("У клиента нет покупок", "Информация",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            if (rows > 0)
                            {
                                MessageBox.Show("Покупки клиента удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    rowView = (DataRowView)dgClients.SelectedItem;
                    rowView.Row.Delete();
                    sqlDA.Update(dT);
                }
            }
        }

        /// <summary>
        /// Действия при загрузке окна 
        /// </summary>
        private void ClientsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgClients.SelectedItem = null;
        }

        /// <summary>
        /// Действия при закрытии окна 
        /// </summary>
        private void ClientsWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            connectToSQLDB.CloseSQLConnection();
            dgClients.DataContext = null;
            App.Current.Shutdown();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Покупки клиента" 
        /// </summary>
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
                email = dT.Rows[selectedNumber]["EMail"].ToString();
            }

            ProductsClient pc = new ProductsClient(email);
            pc.Show();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Все покупки" 
        /// </summary>
        private void ShowAllPurchases_Click(object sender, RoutedEventArgs e)
        {
            AllPurchasesWindow aPW = new AllPurchasesWindow();
            aPW.Show();
        }
    }
}
