using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSysytem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");

            }
            else if (UserNameTb.Text == "Admin" && PasswordTb.Text == "Password")
            {
                Patients obj = new Patients();
                obj.Show();
                this.Hide();
            }
            else {
                UserNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }
    }
}
