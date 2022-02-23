using System;
using System.Windows.Forms;
using BL.Control;

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
            ActivityForm activityform = new ActivityForm();
            activityform.Owner = this;
            activityform.Show();
        }

        private void ActivLevel_SelectedIndexChanged(object sender, EventArgs e) 
        {
            double currentcalories;
            if (ActivLevel.SelectedIndex == 0)
            {
                activlevel = 1.3;
                currentcalories = usercontroler.HarissBenedict(activlevel);
                currentcalories = currentcalories / 6;
                BelkiMax.Text = Math.Round(currentcalories / 4).ToString();
                FatsMax.Text = Math.Round(currentcalories / 9).ToString();
                UglerodMax.Text = Math.Round(currentcalories).ToString();
                CaloriesMax.Text = usercontroler.HarissBenedict(activlevel).ToString();
            }
            else if (ActivLevel.SelectedIndex == 1)
            {
                activlevel = 1.55;
                currentcalories = usercontroler.HarissBenedict(activlevel);
                currentcalories = currentcalories / 6;
                BelkiMax.Text = Math.Round(currentcalories / 4).ToString();
                FatsMax.Text = Math.Round(currentcalories / 9).ToString();
                UglerodMax.Text = Math.Round(currentcalories).ToString();
                CaloriesMax.Text = usercontroler.HarissBenedict(activlevel).ToString();
            }
            else if (ActivLevel.SelectedIndex == 2)
            {
                activlevel = 1.8;
                currentcalories = usercontroler.HarissBenedict(activlevel);
                currentcalories = currentcalories / 6;
                BelkiMax.Text = Math.Round(currentcalories / 4).ToString();
                FatsMax.Text = Math.Round(currentcalories / 9).ToString();
                UglerodMax.Text = Math.Round(currentcalories).ToString();
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
