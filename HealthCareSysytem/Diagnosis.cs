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

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
