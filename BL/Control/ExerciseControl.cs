using BL.Model;
using System.Data;
using System.Windows.Forms;

namespace BL.Control
{
    public class ExerciseControl : DatabaseDatasaver
    {
        private readonly User User;
        DataGridView gridView;
        string tableName;
        bool newRowAdding = false;

        public ExerciseControl(User user, string tablename, DataGridView dataGridView):base(dataGridView,tablename)
        {
            User = user;
            tableName = tablename;
            gridView = dataGridView;
        }

        public void AddActivity(Activity activity, int duration)
        {
            activity.CaloriesPerMinute = activity.CaloriesPerMinute * duration;
        }

        public void LoadExerciseData()
        {
            LoadData();
        }

        public void ReloadExerciseData()
        {
            ReloadData();
        }

        public void ExerciseAddRow()
        {
            if (newRowAdding == false)
            {
                newRowAdding = true;
                AddRow();
            }
           
        }

        public void ExerciseValueChanged()
        {
            if (newRowAdding == false)
            {
                ValueChanged();
            }
           
        }

        public void ExerciseContentClick(DataGridViewCellEventArgs e)
        {
            string task = gridView.Rows[e.RowIndex].Cells[3].Value.ToString();

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
                row["CaloriesPerMinute"] = gridView.Rows[rowIndex].Cells["CaloriesPerMinute"].Value;


                dataSet.Tables[tableName].Rows.Add(row);
                dataSet.Tables[tableName].Rows.RemoveAt(dataSet.Tables["Activities"].Rows.Count - 1);

                gridView.Rows.RemoveAt(gridView.Rows.Count - 2);
                gridView.Rows[e.RowIndex].Cells[3].Value = "Delete";

                sqldataAdapter.Update(dataSet, tableName);

                newRowAdding = false;

            }
            else if (task == "Update")
            {
                int r = e.RowIndex;

                dataSet.Tables[tableName].Rows[r]["Name"] = gridView.Rows[r].Cells["Name"].Value;
                dataSet.Tables[tableName].Rows[r]["CaloriesPerMinute"] = gridView.Rows[r].Cells["CaloriesPerMinute"].Value;

                gridView.Rows[e.RowIndex].Cells[3].Value = "Delete";

                sqldataAdapter.Update(dataSet, tableName);

            }
            ReloadExerciseData();
        }

    }
}
