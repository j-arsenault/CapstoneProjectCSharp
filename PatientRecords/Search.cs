using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientRecords
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
            txtPID.Visible = false;
            lblPatientID.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Creating a dataset to hold a dataset
            DataSet myDS;
            //Perform a search
            PatientInfo temp = new PatientInfo();
            myDS = temp.SearchPatients(txtFName.Text, txtLName.Text);

            //Display search results in gridview
            gvResults.DataSource = myDS;  //Connect the GridView to our dataset
            gvResults.DataMember = "myPatients";
        }

        private void gvResults_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strPID = gvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //MessageBox.Show(strPID);

            int intPID = Convert.ToInt32(strPID);

            //creating new instance of Form1
            PatientInformation temp = new PatientInformation(intPID);
            temp.Show();
        }
    }
}
