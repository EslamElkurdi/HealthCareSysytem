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
    public partial class Tests : Form
    {

        Functions con;
        public Tests()
        {
            InitializeComponent();
            con = new Functions(); 
            Showtest();
        }

        private void Showtest()
        {
            string Query = "select * from PatientTb1";
            TestList.DataSource = con.GetData(Query);
            
        }

        private void Clear() 
        {
            TestNameTb.Text = "";
            TestCostTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (TestNameTb.Text == "" ||TestCostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                string TName = TestNameTb.Text;
                int cost = Convert.ToInt32(TestCostTb.Text);

                string Query = "insert into TestTb values('{0}','{1}')";
                Query = string.Format(Query,TestNameTb, cost);
                con.SetData(Query);
                Showtest();
                Clear();
                MessageBox.Show("Test Added!!!");


            }

        }

        private void TestList_Paint(object sender, PaintEventArgs e)
        {

        }

        int key = 0;

        private void TestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TestNameTb.Text = TestList.SelectedRows[0].Cells[1].Value.ToString();
            TestCostTb.Text = TestList.SelectedRows[0].Cells[2].Value.ToString();
           
            if (TestNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditeBtn_Click(object sender, EventArgs e)
        {
            if (TestNameTb.Text == "" || TestCostTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                
                string Query = "update TestTb set TestName = '{0}',TestCost = {1} where TestCode = {2}";
                Query = string.Format(Query, TestNameTb, TestCostTb, key);
                con.SetData(Query);
                Showtest();
                Clear();
                MessageBox.Show("Test Updated!!!");


            }
        }
    }
}
