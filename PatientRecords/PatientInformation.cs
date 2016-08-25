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
    public partial class PatientInformation : Form
    {
        public PatientInformation()
        {
            InitializeComponent();

            //Disable Edit capabilities since they dont exist yet
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            //When Form loads fill the state dropdown
            FillStateList();
            
            //When form loads set State index to 0
            cmbState.SelectedIndex = 0;

        }

        //Filling State Dropdown
        public void FillStateList()
        {
            cmbState.Items.Add("RI");
            cmbState.Items.Add("CT");
            cmbState.Items.Add("MA");
            cmbState.Items.Add("NH");
            cmbState.Items.Insert(0, "Please Choose One");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Creating a Patient Ifno instance (blank)
            PatientInfo Apatient = new PatientInfo();
            //Filling in information from the form
            /*Apatient.Fname = txtFname.Text;
            Apatient.Mname = txtMname.Text;
            Apatient.Lname = txtLname.Text;
            Apatient.SocialSecurity = txtSocialSecurity.Text;
            Apatient.Address = txtAddress.Text;
            Apatient.Address2 = txtAddress2.Text;
            Apatient.City = txtCity.Text;
            Apatient.State = cmbState.SelectedItem.ToString();
            Apatient.Zip = txtZip.Text;*/
        }
    }
}
