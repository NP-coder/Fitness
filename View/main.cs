using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL.Control;
using System.Data.SqlClient;

namespace View
{
    public partial class main : Form
    {
        double activlevel;
        public UserControler user;
        EatControl eat;
        ExerciseControl exercise;

        public main(Login login)
        {
            InitializeComponent();
            user = login.userController;
            username.Text = user.CurrentUser.Name;
        }

        public main(Food food)
        {
            eat = food.eatControl;
            
        }

        private void Product_Click(object sender, EventArgs e)
        {
            Food foodform = new Food(this);
            foodform.Show();
        }

        private void Exercise_Click(object sender, EventArgs e)
        {
            Activity activityform = new Activity();
            activityform.Show();
        }

        private double HarissBenedict(double weight, double height, int age, double activlevel)
        {
            double result = Math.Round((655.1 + 9.563 * weight + 1.85 * height - 4.676 * age) * activlevel);
            return result;
        }

        private void ActivLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActivLevel.SelectedIndex == 0)
            {
                activlevel = 1.3;
                CaloriesMax.Text = HarissBenedict(user.CurrentUser.Weight, user.CurrentUser.Height, user.CurrentUser.Age, activlevel).ToString();
            }
            else if (ActivLevel.SelectedIndex == 1)
            {
                activlevel = 1.55;
                CaloriesMax.Text = HarissBenedict(user.CurrentUser.Weight, user.CurrentUser.Height, user.CurrentUser.Age, activlevel).ToString();
            }
            else if (ActivLevel.SelectedIndex == 2)
            {
                activlevel = 1.8;
                CaloriesMax.Text = HarissBenedict(user.CurrentUser.Weight, user.CurrentUser.Height, user.CurrentUser.Age, activlevel).ToString();
            }
            else
            {
                MessageBox.Show("Зазначте ваш рівень активності", "Некоректні дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
