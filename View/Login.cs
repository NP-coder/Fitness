using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL.Control;
using BL.Model;


namespace View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
          
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var name = nameField.Text;
                var gender = genderField.Text;

                var userController = new UserControler(name);

                var birth = DateTime.Parse(ageField.Text);
                var weight = Double.Parse(weightField.Text);
                var height = Double.Parse(heightField.Text);

                userController.SetNewUserData(gender, birth, weight, height);

                
            }
            catch
            {
                MessageBox.Show("Введені некоректні дані", "Помилка", MessageBoxButtons.OK,MessageBoxIcon.Error,  MessageBoxDefaultButton.Button1,      MessageBoxOptions.DefaultDesktopOnly);
            }

        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            var name = nameField2.Text;
            var userController = new UserControler(name);
            MessageBox.Show(userController.CurrentUser.ToString());
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
