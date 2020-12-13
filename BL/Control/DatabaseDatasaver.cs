using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BL.Control
{
    public class DatabaseDatasaver 
    {
        protected SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBConnection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        protected SqlCommandBuilder sqldBuilder = null;
        protected SqlDataAdapter sqldataAdapter = null;
        protected DataSet dataSet = null;
        DataGridView dataGridView;
        string tableName;

        protected DatabaseDatasaver(DataGridView datagridview, string tablename)
        {
            dataGridView = datagridview;
            tableName = tablename;
        }

        protected DatabaseDatasaver(string tablename)
        {
            tableName = tablename;
        }

       
        protected void LoadData()
        {
            sqldataAdapter = new SqlDataAdapter($"SELECT *, 'Delete' AS [Command] FROM {tableName}", sqlConnection);
            sqldBuilder = new SqlCommandBuilder(sqldataAdapter);

            sqldBuilder.GetInsertCommand();
            sqldBuilder.GetUpdateCommand();
            sqldBuilder.GetDeleteCommand();

            dataSet = new DataSet();
            sqldataAdapter.Fill(dataSet, tableName);
            dataGridView.DataSource = dataSet.Tables[tableName];
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView[dataGridView.ColumnCount - 1, i] = linkCell;
            }
        }

        protected void ReloadData()
        {
            dataSet.Tables[tableName].Clear();
            sqldataAdapter.Fill(dataSet, tableName);
            dataGridView.DataSource = dataSet.Tables[tableName];
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView[dataGridView.ColumnCount - 1, i] = linkCell;
            }
        }

        protected void AddRow()
        {
            int lastRow = dataGridView.Rows.Count - 2;
            DataGridViewRow row = dataGridView.Rows[lastRow];
            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            dataGridView[dataGridView.ColumnCount - 1, lastRow] = linkCell;
            row.Cells["Command"].Value = "Insert";
        }

        protected void ValueChanged()
        {
            int rowIndex = dataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow editRow = dataGridView.Rows[rowIndex];
            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            dataGridView[dataGridView.ColumnCount - 1, rowIndex] = linkCell;
            editRow.Cells["Command"].Value = "Update";
        }
    }
}
