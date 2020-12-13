using BL.Model;
using System;
using System.Windows.Forms;
using System.Data;

namespace BL.Control
{
    public class EatControl : DatabaseDatasaver
    {
        private readonly User User;
        DataGridView gridView;
        string tableName;
        bool newRowAdding = false;

        public EatControl(User user,DataGridView dataGrid, string tablename) : base(dataGrid, tablename)
        {
            User = user;
            gridView = dataGrid;
            tableName = tablename;
        }

        public void AddEating(Food food, int weight)
        {
            food.Calories = Math.Round(food.Calories * weight, 1);
            food.Fats = Math.Round(food.Fats * weight, 1);
            food.Carbohydrates = Math.Round(food.Carbohydrates * weight, 1);
            food.Proteines = Math.Round(food.Proteines * weight, 1);
        }

        public void LoadFoodData()
        {
            LoadData();
        }

        public void ReloadFoodData()
        {
            ReloadData();
        }

        public void FoodAddRow()
        {
            if (newRowAdding == false)
            {
                newRowAdding = true;
                AddRow();
            }
           
        }

        public void FoodValueChanged()
        {
            if (newRowAdding == false)
            {
                ValueChanged();
            }
        }

        public void EatContentClick( DataGridViewCellEventArgs e)
        {

            string task = gridView.Rows[e.RowIndex].Cells[6].Value.ToString();

            if (task == "Delete")
            {
                if (MessageBox.Show("Ви хочете видалити цю строку?", "Удалити", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;
                    gridView.Rows.RemoveAt(rowIndex);
                    dataSet.Tables[tableName].Rows[rowIndex].Delete();
                    sqldataAdapter.Update(dataSet, tableName);
                }
            }
            else if (task == "Insert")
            {
                int rowIndex = gridView.Rows.Count - 2;
                DataRow row = dataSet.Tables[tableName].NewRow();

                row["Name"] = gridView.Rows[rowIndex].Cells["Name"].Value;
                row["Proteines"] = gridView.Rows[rowIndex].Cells["Proteines"].Value;
                row["Fats"] = gridView.Rows[rowIndex].Cells["Fats"].Value;
                row["Carbohydrates"] = gridView.Rows[rowIndex].Cells["Carbohydrates"].Value;
                row["Calories"] = gridView.Rows[rowIndex].Cells["Calories"].Value;

                dataSet.Tables[tableName].Rows.Add(row);
                dataSet.Tables[tableName].Rows.RemoveAt(dataSet.Tables["Foods"].Rows.Count - 1);

                gridView.Rows.RemoveAt(gridView.Rows.Count - 2);
                gridView.Rows[e.RowIndex].Cells[6].Value = "Delete";

                sqldataAdapter.Update(dataSet, tableName);

                newRowAdding = false;
            }
            else if (task == "Update")
            {
                int r = e.RowIndex;

                dataSet.Tables[tableName].Rows[r]["Name"] = gridView.Rows[r].Cells["Name"].Value;
                dataSet.Tables[tableName].Rows[r]["Proteines"] = gridView.Rows[r].Cells["Proteines"].Value;
                dataSet.Tables[tableName].Rows[r]["Fats"] = gridView.Rows[r].Cells["Fats"].Value;
                dataSet.Tables[tableName].Rows[r]["Carbohydrates"] = gridView.Rows[r].Cells["Carbohydrates"].Value;
                dataSet.Tables[tableName].Rows[r]["Calories"] = gridView.Rows[r].Cells["Calories"].Value;

                gridView.Rows[e.RowIndex].Cells[6].Value = "Delete";

                sqldataAdapter.Update(dataSet, tableName);
            }
            ReloadFoodData();
        }
    }
}
