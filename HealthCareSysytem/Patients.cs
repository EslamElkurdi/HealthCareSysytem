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
    public partial class Patients : Form
    {
        Functions con;
        public Patients()
        {
            InitializeComponent();
            con = new Functions();
            ShowPatients();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void ShowPatients()
        {
            string Query = "select * from PatientTb1";
            patientsList.DataSource = con.GetData(Query);

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatName.Text == "" || PatPhoneTb.Text == "" || PatAddTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                string Patient = PatName.Text;
                string Gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString();
                string phone = PatPhoneTb.Text;
                string address = PatAddTb.Text;
                string Query = "insert into PatientTb1 values('{0}','{1}', '{2}', '{3}', '{4}')";
                Query = string.Format(Query, Patient, Gender, BDate, phone, address);
                con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Added!!!");


            }
        }

        int key = 0;
        private void patientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatName.Text = patientsList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = patientsList.SelectedRows[0].Cells[2].Value.ToString();
            DOBTb.Text = patientsList.SelectedRows[0].Cells[3].Value.ToString();
            PatPhoneTb.Text = patientsList.SelectedRows[0].Cells[4].Value.ToString();
            PatAddTb.Text = patientsList.SelectedRows[0].Cells[5].Value.ToString();
            // Console.WriteLine("OUTPUT:>>>>>>" + patientsList.SelectedRows[0].Cells[0].Value.ToString());
            //PatName.Text = patientsList.SelectedRows[1].Cells[1].Value.ToString();
            if (PatName.Text == "") 
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(patientsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PatName.Text == "" || PatPhoneTb.Text == "" || PatAddTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                string Patient = PatName.Text;
                string Gender = GenCb.SelectedItem.ToString();
                string BDate = DOBTb.Value.Date.ToString();
                string phone = PatPhoneTb.Text;
                string address = PatAddTb.Text;
                string Query = "update PatientTb1 set PatName = '{0}',PatGen = '{1}',PatDOB = '{2}',PatPhone = '{3}',PatAdd = '{4}' where PatCode = {5}";
                Query = string.Format(Query, Patient, Gender, BDate, phone, address, key);
                con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Updated!!!");


            }
        }

        private void Clear() 
        {
            PatName.Text = "";
            GenCb.SelectedIndex = -1;
            PatPhoneTb.Text = "";
            PatAddTb.Text = "";
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select a ptient!!");
            }
            else
            {
               
                string Query = "delete from PatientTb1 where PatCode = {0}";
                Query = string.Format(Query, key);
                con.SetData(Query);
                ShowPatients();
                Clear();
                MessageBox.Show("Patient Deleted!!!");


            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Patients obj = new Patients();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tests obj = new Tests();
            obj.Show();
            this.Hide();
        }

        // Finish
        private void pictureBox4_Click(object sender, EventArgs e)
        {
             Diagnosis obj = new Diagnosis();
            obj.Show();
            this.Hide();
        }
    }
}
