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
    public partial class Diagnosis : Form
    {
        Functions Con;
        public Diagnosis()
        {
            InitializeComponent();
            Con = new Functions();
            GetPatients();
            GetTest();
            ShowDiagnosis();

        }


        private void GetCost() 
        {
            string Query = "Select * form TestTb where TestCode = {0}";
            Query = string.Format(Query, TestCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows) 
            {
                CostTb.Text = dr["TestCost"].ToString();
            }
        }

        private void ShowDiagnosis() 
        {
            string Query = "select * from DiagnosisTb1";
            diagnosisList.DataSource = Con.GetData(Query);
        }

        private void GetPatients() 
        {
            string Query = "Select * form PatientTb1";
            PatientCb.DisplayMember = Con.GetData(Query).Columns["PatName"].ToString();
            PatientCb.ValueMember = Con.GetData(Query).Columns["PatCode"].ToString();
            PatientCb.DataSource = Con.GetData(Query);
        }

        private void GetTest()
        {
            string Query = "Select * form TestTb";
            TestCb.DisplayMember = Con.GetData(Query).Columns["PatName"].ToString();
            TestCb.ValueMember = Con.GetData(Query).Columns["PatCode"].ToString();
            TestCb.DataSource = Con.GetData(Query);
        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Clear() 
        {
            CostTb.Text = "";
            ResultTb.Text = "";
            TestCb.SelectedIndex = -1;
            PatientCb.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PatientCb.SelectedIndex == -1 || CostTb.Text == "" || ResultTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                string DDate = DiagDateTb.Value.Date.ToString();
                int Patient = Convert.ToInt32(PatientCb.SelectedValue.ToString());
                int Test = Convert.ToInt32(TestCb.SelectedValue.ToString());
                int Cost = Convert.ToInt32(CostTb.Text);
                string Result = ResultTb.Text;

                string Query = "insert into DiagnosisTb1 values('{0}','{1}', '{2}', '{3}', '{4}')";
                Query = string.Format(Query, DDate, Patient, Test, Cost, Result);
                Con.SetData(Query);
                ShowDiagnosis();
                Clear();
                MessageBox.Show("Diagnosis Added!!!");
            }
        }

        private void TestCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TestCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
        }

        int key = 0;
        private void patientsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DiagDateTb.Text = diagnosisList.SelectedRows[0].Cells[1].Value.ToString();
            PatientCb.SelectedItem = diagnosisList.SelectedRows[0].Cells[2].Value.ToString();
            TestCb.SelectedItem = diagnosisList.SelectedRows[0].Cells[3].Value.ToString();
            CostTb.Text = diagnosisList.SelectedRows[0].Cells[4].Value.ToString();
            ResultTb.Text = diagnosisList.SelectedRows[0].Cells[5].Value.ToString();
           
            if (CostTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(diagnosisList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
