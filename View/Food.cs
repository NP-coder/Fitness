using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Control;
using BL.Model;

namespace View
{
    public partial class FoodForm : Form
    {
        double calories, prot, fats, carb;
        string productname;
        string tableName = "Foods";
        EatControl eatControl;
        Label Calories, Belki, Fats, Uglerod;
        double calories1, prot1, fats1, carb1;

        public FoodForm()
        {
            InitializeComponent();
        }

        private void Food_Load(object sender, EventArgs e)
        {
            main main = this.Owner as main;
            if (main != null)
            {
                eatControl = new EatControl(main.usercontroler.CurrentUser, FoodGrid, tableName);
                eatControl.LoadFoodData();
                Calories = main.Calories;
                Belki = main.Belki;
                Fats = main.Fats;
                Uglerod = main.Uglerod;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food product = new Food(productname, calories, prot, fats, carb);
           
            eatControl.AddEating(product, int.Parse(Weight.Value.ToString()));

            calories1 += product.Calories;
            prot1 += product.Proteines;
            fats1 += product.Fats;
            carb1 += product.Carbohydrates;

            Calories.Text = Math.Round(calories1, 1).ToString();
            Belki.Text = Math.Round(prot1, 1).ToString();
            Fats.Text = Math.Round(fats1, 1).ToString();
            Uglerod.Text = Math.Round(carb1, 1).ToString();
        }

        private void FoodGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(FoodGrid.CurrentRow.Cells[1].Value.ToString())==false
                && string.IsNullOrWhiteSpace(FoodGrid.CurrentRow.Cells[2].Value.ToString()) == false
                && string.IsNullOrWhiteSpace(FoodGrid.CurrentRow.Cells[3].Value.ToString()) == false
                && string.IsNullOrWhiteSpace(FoodGrid.CurrentRow.Cells[4].Value.ToString()) == false
                &&  string.IsNullOrWhiteSpace(FoodGrid.CurrentRow.Cells[5].Value.ToString()) == false)
            {
                productname = FoodGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                calories = double.Parse(FoodGrid.Rows[e.RowIndex].Cells[5].Value.ToString());
                carb = double.Parse(FoodGrid.Rows[e.RowIndex].Cells[4].Value.ToString());
                fats = double.Parse(FoodGrid.Rows[e.RowIndex].Cells[3].Value.ToString());
                prot = double.Parse(FoodGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void FoodGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    eatControl.EatContentClick(e);
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
                eatControl.FoodValueChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FoodGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //TODO перенест bool в контр в методи або через конструктор
            try
            {
                eatControl.FoodAddRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
