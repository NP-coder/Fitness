using System;
using System.Data;
using System.Windows.Forms;
using BL.Control;
using BL.Model;

namespace View
{
    public partial class main : Form
    {
        double activlevel;
        public UserControler usercontroler;

        public main(Login login)
        {
            InitializeComponent();

            usercontroler = login.userController;
            username.Text = usercontroler.CurrentUser.Name;
        }

        private void Product_Click(object sender, EventArgs e)
        {
            FoodForm foodform = new FoodForm();
            foodform.Owner = this;
            foodform.Show();
        }

        private void Exercise_Click(object sender, EventArgs e)
        {
            Activ activityform = new Activ();
            activityform.Owner = this;
            activityform.Show();
        }

        private void ActivLevel_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (ActivLevel.SelectedIndex == 0)
            {
                activlevel = 1.3;
                CaloriesMax.Text = usercontroler.HarissBenedict(activlevel).ToString();
            }
            else if (ActivLevel.SelectedIndex == 1)
            {
                activlevel = 1.55;
                CaloriesMax.Text = usercontroler.HarissBenedict(activlevel).ToString();
            }
            else if (ActivLevel.SelectedIndex == 2)
            {
                activlevel = 1.8;
                CaloriesMax.Text = usercontroler.HarissBenedict(activlevel).ToString();
            }
            else
            {
                MessageBox.Show("Зазначте ваш рівень активності", "Некоректні дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
