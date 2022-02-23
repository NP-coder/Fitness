using System;
using System.Windows.Forms;
using BL.Control;
using BL.Model;

namespace View
{
    public partial class ActivityForm : Form  
    {
        ExerciseControl exerciseControl;
        string tableName = "Activities";
        string exerciseName;
        double caloriesperminet, burned;
        private Label Calories;

        public ActivityForm()
        {
            InitializeComponent();
        }


        private void Activity_Load(object sender, EventArgs e)
        {
            main main = this.Owner as main;
            if (main != null)
            {
                exerciseControl = new ExerciseControl(main.usercontroler.CurrentUser, tableName, ActivityGrid);
                exerciseControl.LoadExerciseData();
                Calories = main.BurnedCalories;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity(exerciseName, caloriesperminet);
            exerciseControl.AddActivity(activity, int.Parse(numericUpDown1.Value.ToString()));

            burned += activity.CaloriesPerMinute;

            Calories.Text = burned.ToString();
        }

        private void ActivityGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                exerciseControl.ExerciseAddRow();
            }
            catch
            {
                MessageBox.Show("Введені некоректні дані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void ActivityGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                exerciseControl.ExerciseValueChanged();
            }
            catch 
            {
                MessageBox.Show("Введені некоректні дані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ActivityGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    exerciseControl.ExerciseContentClick(e);
                }
            }
            catch
            {
                MessageBox.Show("Введені некоректні дані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivityGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(string.IsNullOrEmpty(ActivityGrid.CurrentRow.Cells[1].Value.ToString()) == false
                && string.IsNullOrWhiteSpace(ActivityGrid.CurrentRow.Cells[2].Value.ToString()) == false)
            {
                exerciseName = ActivityGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                caloriesperminet = double.Parse(ActivityGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }
    }
}
