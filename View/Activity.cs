using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Control;


namespace View
{
    public partial class Activity : Form  
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqldBuilder = null;
        private SqlDataAdapter sqldataAdapter = null;
        private DataSet dataSet = null;
        bool newRowAdding = false;

        public Activity()
        {
            InitializeComponent();
        }


        private void Activity_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBConnection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

           LoadData("Activities");
        }
       
         
        
        public void LoadData(string tableName)
        {
            try
            {
                sqldataAdapter = new SqlDataAdapter($"SELECT *, 'Delete' AS [Command] FROM {tableName}", sqlConnection);
                sqldBuilder = new SqlCommandBuilder(sqldataAdapter);

                sqldBuilder.GetInsertCommand();
                sqldBuilder.GetUpdateCommand();
                sqldBuilder.GetDeleteCommand();


                dataSet = new DataSet();
                sqldataAdapter.Fill(dataSet, tableName);
                ActivityGrid.DataSource = dataSet.Tables[tableName];
                for (int i = 0; i < ActivityGrid.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    ActivityGrid[ActivityGrid.ColumnCount - 1, i] = linkCell;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData(string tableName)
        {
            try
            {
                dataSet.Tables[tableName].Clear();
                sqldataAdapter.Fill(dataSet, tableName);
                ActivityGrid.DataSource = dataSet.Tables[tableName];
                for (int i = 0; i < ActivityGrid.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    ActivityGrid[ActivityGrid.ColumnCount - 1, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValueChange(DataGridView dataGridView)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                    DataGridViewRow editRow = dataGridView.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[dataGridView.ColumnCount - 1, rowIndex] = linkCell;
                    editRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRow(DataGridView dataGridView)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView.Rows.Count - 2;
                    DataGridViewRow row = dataGridView.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView[dataGridView.ColumnCount - 1, lastRow] = linkCell;
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivityGrid_UserAddedRow_1(object sender, DataGridViewRowEventArgs e)
        {
            AddRow(ActivityGrid);
        }

        private void ActivityGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ValueChange(ActivityGrid);
        }

        private void ActivityGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string task = ActivityGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Ви хочете удалити цю строку?", "Удалити", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            ActivityGrid.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Activities"].Rows[rowIndex].Delete();
                            sqldataAdapter.Update(dataSet, "Activities");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = ActivityGrid.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Activities"].NewRow();

                        row["Name"] = ActivityGrid.Rows[rowIndex].Cells["Name"].Value;
                        row["CaloriesPerMinute"] = ActivityGrid.Rows[rowIndex].Cells["CaloriesPerMinute"].Value;


                        dataSet.Tables["Activities"].Rows.Add(row);
                        dataSet.Tables["Activities"].Rows.RemoveAt(dataSet.Tables["Activities"].Rows.Count - 1);

                        ActivityGrid.Rows.RemoveAt(ActivityGrid.Rows.Count - 2);
                        ActivityGrid.Rows[e.RowIndex].Cells[3].Value = "Delete";

                        sqldataAdapter.Update(dataSet, "Activities");

                        newRowAdding = false;

                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Activities"].Rows[r]["Name"] = ActivityGrid.Rows[r].Cells["Name"].Value;
                        dataSet.Tables["Activities"].Rows[r]["CaloriesPerMinute"] = ActivityGrid.Rows[r].Cells["CaloriesPerMinute"].Value;

                        ActivityGrid.Rows[e.RowIndex].Cells[3].Value = "Delete";

                        sqldataAdapter.Update(dataSet, "Activities");

                    }
                    ReloadData("Activities");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
