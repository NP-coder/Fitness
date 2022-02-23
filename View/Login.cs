using System;
using System.Windows.Forms;
using BL.Control;

namespace View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public UserControler userController;

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameField.Text;
                string gender = comboBox1.SelectedItem.ToString();
                int age = int.Parse(ageField.Text);
                double weight = double.Parse(weightField.Text);
                double height = double.Parse(heightField.Text);

                userController = new UserControler(name, "Users");


                if (userController.NewUser == true && age > 0 && age < 150 && weight > 0&& weight < 400 && height > 0 && height < 300)
                {
                    userController.SetNewUserData(name, gender, age, weight, height);
                    this.Hide();
                    main mainform = new main(this);
                    mainform.Owner = this;
                    mainform.Show();
                }
                else
                {
                    MessageBox.Show("Користувач з таким іменем вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch
            {
                MessageBox.Show("Введені некоректні дані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }


        public void button2_Click(object sender, EventArgs e)
        {
                string name = nameField2.Text;
                userController = new UserControler(name, "Users");

                if (userController.NewUser == false)
                {
                    this.Hide();
                    main mainform = new main(this);
                    mainform.Show();
                }
                else
                {
                    MessageBox.Show("Користувача з таким іменем не існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel5.Visible = true;
            }
            else { panel5.Visible = false; }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel4.Visible = true;
            }
            else { panel4.Visible = false; }
          
        }
    }
}
