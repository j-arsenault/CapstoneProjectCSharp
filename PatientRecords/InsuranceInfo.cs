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

            //When form loads set Patient Relationship index to 0
            cmbSecondaryPatientRelationship.SelectedIndex = 0;
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

            //Filling in information from the form
            ApatientInsurance.Insurance = txtInsurance.Text;
            ApatientInsurance.GroupNum = txtGroupNum.Text;
            ApatientInsurance.PolicyNum = txtPolicyNum.Text;
            ApatientInsurance.Copayment = txtCopayment.Text;
            ApatientInsurance.SubscriberName = txtSubscriberName.Text;
            ApatientInsurance.SocialSecNum = txtSocialSecurityNum.Text;
            ApatientInsurance.SubscriberBirthday = dtpSubscriberBirthdate.Value;
            ApatientInsurance.PatientRelationship = cmbPatientRelationship.SelectedItem.ToString();

            //Secondary Insurance information --IF ANY--
            ApatientInsurance.SecondaryInsurance = txtSecondaryInsurance.Text;
            ApatientInsurance.SecondaryGroupNum = txtSecondaryGroupNum.Text;
            ApatientInsurance.SecondaryPolicyNum = txtSecondaryPolicyNum.Text;
            ApatientInsurance.SecondaryCopayment = txtSecondaryCopayment.Text;
            ApatientInsurance.SecondarySubscriberName = txtSecondarySubscriberName.Text;
            ApatientInsurance.SecondarySocialSecNum = txtSecondarySocialSecNum.Text;
            ApatientInsurance.SecondaryBirthday = dtpSecondaryBirthdate.Value;
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
            lblFeedback.Text += temp.SocialSecNum + " ";
            lblFeedback.Text += temp.SubscriberBirthday + " ";
            lblFeedback.Text += temp.PatientRelationship + "\n";
            //Employer/School information
            lblFeedback.Text += temp.SecondaryInsurance + " ";
            lblFeedback.Text += temp.SecondaryGroupNum + " ";
            lblFeedback.Text += temp.SecondaryPolicyNum + " ";
            lblFeedback.Text += temp.SecondaryCopayment + "\n";
            lblFeedback.Text += temp.SecondarySubscriberName + " ";
            lblFeedback.Text += temp.SecondarySocialSecNum + " ";
            lblFeedback.Text += temp.SecondaryBirthday + " ";
            lblFeedback.Text += temp.SecondaryPatientRelationship + "\n";
        }


    }
}
