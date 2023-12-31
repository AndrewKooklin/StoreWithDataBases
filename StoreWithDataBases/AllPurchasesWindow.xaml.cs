﻿using StoreWithDataBases.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StoreWithDataBases
{
    /// <summary>
    /// Окно для показа всех покупок всех клиентов
    /// </summary>
    public partial class AllPurchasesWindow : Window
    {
        OleDbDataAdapter oleDA;
        DataTable dT;
        DataRowView rowView;
        ConnectToOleDB connectToOleDB;

        public AllPurchasesWindow()
        {
            InitializeComponent();
            CreateCommands();
        }

        private void CreateCommands()
        {
            dT = new DataTable();
            oleDA = new OleDbDataAdapter();

            //SelectCommand
            string query = "SELECT Id, EMail, ProductCode, ProductName " +
                            "FROM AllPurchasesClients";
            connectToOleDB = new ConnectToOleDB();
            oleDA.SelectCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());
            //EndSelectCommand

            //InsertCommand
            query = "INSERT INTO AllPurchasesClients (EMail, ProductCode, ProductName) VALUES (?, ?, ?)";

            oleDA.InsertCommand = new OleDbCommand(query, connectToOleDB.GetOleDBConnection());

            //oleDA.InsertCommand.Parameters.Add("@Id", OleDbType.Integer, 4, "Id");
            oleDA.InsertCommand.Parameters.Add("@EMail", OleDbType.VarChar, 50, "EMail");
            oleDA.InsertCommand.Parameters.Add("@ProductCode", OleDbType.VarChar, 50, "ProductCode");
            oleDA.InsertCommand.Parameters.Add("@ProductName", OleDbType.VarChar, 50, "ProductName");
            //EndInsertCommand

            //UpdateCommand
            query = "UPDATE AllPurchasesClients SET EMail = ?, ProductCode = ?, ProductName = ? WHERE Id = ? ";

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
            dgAllPurchasesClients.DataContext = dT.DefaultView;
        }

        /// <summary>
        /// Действия при нажатии кнопки "Добавить" 
        /// </summary>
        private void BAddProduct_Click(object sender, RoutedEventArgs e)
        {
            DataRow dR = dT.NewRow();
            AddProductWindow addProductWindow = new AddProductWindow(dR, "");
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
        /// Действия при редактировании ячейки 
        /// </summary>
        private void CellEdit_Ending(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            rowView = (DataRowView)dgAllPurchasesClients.SelectedItem;
            rowView.BeginEdit();
        }

        /// <summary>
        /// Действия при нажатии кнопки "Удалить" 
        /// </summary>
        private void BDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgAllPurchasesClients.SelectedIndex == -1 || !(dgAllPurchasesClients.SelectedItem is DataRowView))
            {
                MessageBox.Show("Выберите продукт", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                rowView = (DataRowView)dgAllPurchasesClients.SelectedItem;
                rowView.Row.Delete();
                oleDA.Update(dT);
            }
        }

        /// <summary>
        /// Действия при загрузке окна 
        /// </summary>
        private void AllPurchasesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgAllPurchasesClients.SelectedItem = null;
        }

        /// <summary>
        /// Действия при закрытии окна 
        /// </summary>
        private void AllPurchasesWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            connectToOleDB.CloseOleDBConnection();
            dgAllPurchasesClients.DataContext = null;
        }
    }
}
