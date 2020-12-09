using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Control;

namespace View
{
    public partial class Food : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqldBuilder = null;
        private SqlDataAdapter sqldataAdapter = null;
        private DataSet dataSet = null;
        bool newRowAdding = false;
        public EatControl eatControl;
        public UserControler user;

        public Food(main main)
        {
            InitializeComponent();
            user = main.user;
        }

        private void Food_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBConnection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlConnection.Open();

            LoadData("Foods");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            eatControl = new EatControl(user.CurrentUser);
            
        }

        private void FoodGrid_SelectionChanged(object sender, EventArgs e)
        {

        }


        private void FoodGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    string task = FoodGrid.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Ви хочете удалити цю строку?", "Удалити", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            FoodGrid.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Foods"].Rows[rowIndex].Delete();
                            sqldataAdapter.Update(dataSet, "Foods");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = FoodGrid.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Foods"].NewRow();

                        row["Name"] = FoodGrid.Rows[rowIndex].Cells["Name"].Value;
                        row["Proteines"] = FoodGrid.Rows[rowIndex].Cells["Proteines"].Value;
                        row["Fats"] = FoodGrid.Rows[rowIndex].Cells["Fats"].Value;
                        row["Carbohydrates"] = FoodGrid.Rows[rowIndex].Cells["Carbohydrates"].Value;
                        row["Calories"] = FoodGrid.Rows[rowIndex].Cells["Calories"].Value;

                        dataSet.Tables["Foods"].Rows.Add(row);
                        dataSet.Tables["Foods"].Rows.RemoveAt(dataSet.Tables["Foods"].Rows.Count - 1);

                        FoodGrid.Rows.RemoveAt(FoodGrid.Rows.Count - 2);
                        FoodGrid.Rows[e.RowIndex].Cells[6].Value = "Delete";

                        sqldataAdapter.Update(dataSet, "Foods");

                        newRowAdding = false;

                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Foods"].Rows[r]["Name"] = FoodGrid.Rows[r].Cells["Name"].Value;
                        dataSet.Tables["Foods"].Rows[r]["Proteines"] = FoodGrid.Rows[r].Cells["Proteines"].Value;
                        dataSet.Tables["Foods"].Rows[r]["Fats"] = FoodGrid.Rows[r].Cells["Fats"].Value;
                        dataSet.Tables["Foods"].Rows[r]["Carbohydrates"] = FoodGrid.Rows[r].Cells["Carbohydrates"].Value;
                        dataSet.Tables["Foods"].Rows[r]["Calories"] = FoodGrid.Rows[r].Cells["Calories"].Value;

                        FoodGrid.Rows[e.RowIndex].Cells[6].Value = "Delete";

                        sqldataAdapter.Update(dataSet, "Foods");

                    }
                    ReloadData("Foods");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FoodGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = FoodGrid.SelectedCells[0].RowIndex;
                    DataGridViewRow editRow = FoodGrid.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    FoodGrid[FoodGrid.ColumnCount - 1, rowIndex] = linkCell;
                    editRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FoodGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = FoodGrid.Rows.Count - 2;
                    DataGridViewRow row = FoodGrid.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    FoodGrid[FoodGrid.ColumnCount - 1, lastRow] = linkCell;
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                FoodGrid.DataSource = dataSet.Tables[tableName];
                for (int i = 0; i < FoodGrid.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    FoodGrid[FoodGrid.ColumnCount - 1, i] = linkCell;
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
                FoodGrid.DataSource = dataSet.Tables[tableName];
                for (int i = 0; i < FoodGrid.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    FoodGrid[FoodGrid.ColumnCount - 1, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
