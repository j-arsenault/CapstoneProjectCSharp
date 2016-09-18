using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PatientRecords
{
    public partial class InsuranceInfo : Form
    {
        public InsuranceInfo()
        {
            InitializeComponent();
        }

        private void InsuranceInfo_Load(object sender, EventArgs e)
        {
            //When form loads fill Relationship drop downs
            FillRelationship();
            //When form loads set Patient Relationship index to 0
            cmbPatientRelationship.SelectedIndex = 0;

            //When form loads fill Relationship drop downs
            FillSecondaryRelationship();
            //When form loads set Patient Relationship index to 0
            cmbSecondaryPatientRelationship.SelectedIndex = 0;

            //Disable edit buttons
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
        }


        //OVERLOADED CONSTRUCTOR -- meant to pull up existing data
        public InsuranceInfo(Int32 intPID)
        {
            InitializeComponent();

            //Fill in the Relationship dropdown box
            FillRelationship();

            //When form loads fill Relationship drop downs
            FillSecondaryRelationship();

            //Disable the add capability because they already exist
            btnAdd.Visible = false;
            btnAdd.Enabled = false;

            //Gather info about this one person and store it in a datareader
            PatientInsurance temp = new PatientInsurance();
            SqlDataReader dr = temp.FindOnePatientInsurance(intPID);

            //Use this info to fill out the form
            //Loop through the records store in the reader 1 record at a time
            //Since this is based on one person's ID we should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them into the appropriate text fields
                txtInsurance.Text = dr["Insurance"].ToString();
                txtGroupNum.Text = dr["GroupNum"].ToString();
                txtPolicyNum.Text = dr["PolicyNum"].ToString();
                txtCopayment.Text = dr["Copayment"].ToString();
                txtSubscriberName.Text = dr["SubscriberName"].ToString();
                txtSubscriberSocialSecurityNum.Text = dr["SubscriberSocialSecNum"].ToString();
                dtpSubscriberBirthdate.Value = (DateTime)dr["SubscriberBirthdate"];
                cmbPatientRelationship.SelectedItem = dr["PatientRelationship"].ToString();


                txtSecondaryInsurance.Text = dr["SecondaryInsurance"].ToString();
                txtSecondaryGroupNum.Text = dr["SecondaryGroupNum"].ToString();
                txtSecondaryPolicyNum.Text = dr["SecondaryPolicyNum"].ToString();
                txtSecondaryCopayment.Text = dr["SecondaryCopayment"].ToString();
                txtSecondarySubscriberName.Text = dr["SecondarySubscriberName"].ToString();
                txtSecondarySocialSecNum.Text = dr["SecondarySocialSecNum"].ToString();
                dtpSecondarySubscriberBirthdate.Value = (DateTime)dr["SecondarySubscriberBirthdate"];
                cmbSecondaryPatientRelationship.SelectedItem = dr["SecondaryPatientRelationship"].ToString();

                //We add this one to store the ID in a new label on the form
                lblPID.Text = dr["PatientID"].ToString();
            }
        }

        //Filling Relationship Dropdown
        public void FillRelationship()
        {
            //Primary Insurance Patient Relationship drop down options
            cmbPatientRelationship.Items.Add("Self");
            cmbPatientRelationship.Items.Add("Parent");
            cmbPatientRelationship.Items.Add("Sibling");
            cmbPatientRelationship.Items.Add("Friend");
            cmbPatientRelationship.Items.Add("Significant Other");
            cmbPatientRelationship.Items.Insert(0, "Please Choose One");
        }

        //Filling Relationship Dropdown
        public void FillSecondaryRelationship()
        {
            //Secondary Insurance Patient Relationship drop down options
            cmbSecondaryPatientRelationship.Items.Add("Self");
            cmbSecondaryPatientRelationship.Items.Add("Parent");
            cmbSecondaryPatientRelationship.Items.Add("Sibling");
            cmbSecondaryPatientRelationship.Items.Add("Friend");
            cmbSecondaryPatientRelationship.Items.Add("Significant Other");
            cmbSecondaryPatientRelationship.Items.Insert(0, "Please Choose One");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Clear the feedback label
            lblFeedback.Text = "";

            //Creating a new Patient Insurance instance (blank)
            PatientInsurance ApatientInsurance = new PatientInsurance();

            //ApatientInsurance.PatientID = ;

            //Filling in information from the form
            ApatientInsurance.Insurance = txtInsurance.Text;
            ApatientInsurance.GroupNum = txtGroupNum.Text;
            ApatientInsurance.PolicyNum = txtPolicyNum.Text;
            ApatientInsurance.Copayment = txtCopayment.Text;
            ApatientInsurance.SubscriberName = txtSubscriberName.Text;
            ApatientInsurance.SubscriberSocialSecNum = txtSubscriberSocialSecurityNum.Text;
            ApatientInsurance.SubscriberBirthdate = dtpSubscriberBirthdate.Value;
            ApatientInsurance.PatientRelationship = cmbPatientRelationship.SelectedItem.ToString();

            //Secondary Insurance information --IF ANY--
            ApatientInsurance.SecondaryInsurance = txtSecondaryInsurance.Text;
            ApatientInsurance.SecondaryGroupNum = txtSecondaryGroupNum.Text;
            ApatientInsurance.SecondaryPolicyNum = txtSecondaryPolicyNum.Text;
            ApatientInsurance.SecondaryCopayment = txtSecondaryCopayment.Text;
            ApatientInsurance.SecondarySubscriberName = txtSecondarySubscriberName.Text;
            ApatientInsurance.SecondarySocialSecNum = txtSecondarySocialSecNum.Text;
            ApatientInsurance.SecondarySubscriberBirthdate = dtpSecondarySubscriberBirthdate.Value;
            ApatientInsurance.SecondaryPatientRelationship = cmbSecondaryPatientRelationship.SelectedItem.ToString();

            //If an error in information occurs..
            if (ApatientInsurance.Feedback.Contains("ERROR:"))
            {
                //display the error message in windows form
                lblFeedback.Text = ApatientInsurance.Feedback;
            }
            else //No error was found, ok move forward and display the data
            {
                //Fill label with the patients information
                FillLabel(ApatientInsurance);
                lblFeedback.Text = ApatientInsurance.AddRecord();
            }
        }

        public void FillLabel(PatientInsurance temp)
        {
            //Sending the persons information to the label
            //Patient information
            lblFeedback.Text = temp.Insurance + " ";
            lblFeedback.Text += temp.GroupNum + " ";
            lblFeedback.Text += temp.PolicyNum + "\n";
            lblFeedback.Text += temp.Copayment + " ";
            lblFeedback.Text += temp.SubscriberName + " ";
            lblFeedback.Text += temp.SubscriberSocialSecNum + " ";
            lblFeedback.Text += temp.SubscriberBirthdate + " ";
            lblFeedback.Text += temp.PatientRelationship + "\n";
            //Employer/School information
            lblFeedback.Text += temp.SecondaryInsurance + " ";
            lblFeedback.Text += temp.SecondaryGroupNum + " ";
            lblFeedback.Text += temp.SecondaryPolicyNum + " ";
            lblFeedback.Text += temp.SecondaryCopayment + "\n";
            lblFeedback.Text += temp.SecondarySubscriberName + " ";
            lblFeedback.Text += temp.SecondarySocialSecNum + " ";
            lblFeedback.Text += temp.SecondarySubscriberBirthdate + " ";
            lblFeedback.Text += temp.SecondaryPatientRelationship + "\n";
        }

        private void FillLabel()
        {
            //Show in the feedback label when they search an unknown person
            lblFeedback.Text = "Unknown Patient.... Lack of Data";
        }


        //Button click to update the record in the form
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Create a person so we can use the update method
            PatientInsurance temp = new PatientInsurance();

            //Fill in the data from form
            temp.Insurance = txtInsurance.Text;
            temp.GroupNum = txtGroupNum.Text;
            temp.PolicyNum = txtPolicyNum.Text;
            temp.Copayment = txtCopayment.Text;
            temp.SubscriberName = txtSubscriberName.Text;
            temp.SubscriberSocialSecNum = txtSubscriberSocialSecurityNum.Text;
            temp.SubscriberBirthdate = dtpSubscriberBirthdate.Value;
            temp.PatientRelationship = cmbPatientRelationship.SelectedItem.ToString();
            temp.SecondaryInsurance = txtSecondaryInsurance.Text;
            temp.SecondaryGroupNum = txtSecondaryGroupNum.Text;
            temp.SecondaryPolicyNum = txtSecondaryPolicyNum.Text;
            temp.SecondaryCopayment = txtSecondaryCopayment.Text;
            temp.SecondarySubscriberName = txtSecondarySubscriberName.Text;
            temp.SecondarySocialSecNum = txtSecondarySocialSecNum.Text;
            temp.SecondarySubscriberBirthdate = dtpSecondarySubscriberBirthdate.Value;
            temp.SecondaryPatientRelationship = cmbSecondaryPatientRelationship.SelectedItem.ToString();
            temp.PatientID = Convert.ToInt32(lblPID.Text);

            //Checking to see all validation has been met
            // and if any ERRORS have happened
            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else if (temp.Insurance.Length > 0)
            {
                FillLabel(temp);
                //Perform the update and store the #of records effected
                Int32 intRecords = temp.UpdatePatientInfo();
                //Display feedback to the user
                lblFeedback.Text = intRecords.ToString() + " Records Updated.";
            }
            else
            {
                FillLabel();
            }
        }


    }
}
