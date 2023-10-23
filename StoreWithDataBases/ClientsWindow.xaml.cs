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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            string query = $"SELECT Id, LastName, FirstName, FathersName," +
                            $"PhoneNumber, EMail FROM Clients";
            connectToSQLDB = new ConnectToSQLDB();
            sqlDA.SelectCommand = new SqlCommand(query, connectToSQLDB.GetSqlConnection());



            sqlDA.Fill(dT);
            dgClients.DataContext = dT.DefaultView;
        }

        private void CurrentCell_Changed(object sender, EventArgs e)
        {

        }

        private void CellEdit_Ending(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
