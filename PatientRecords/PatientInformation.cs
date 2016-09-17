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
    public partial class PatientInformation : Form
    {
        public PatientInformation()
        {
            InitializeComponent();

            //Disable Edit capabilities since they dont exist yet
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
        }

        //OVERLOADED CONSTRUCTOR -- meant to pull up existing data
        public PatientInformation(Int32 intPID)
        {
            InitializeComponent();

            //Fill in the State dropdown box
            FillStateList();

            //Disable the add capability because they already exist
            btnAdd.Visible = false;
            btnAdd.Enabled = false;

            //Gather info about this one person and store it in a datareader
            PatientInfo temp = new PatientInfo();
            SqlDataReader dr = temp.FindOnePatient(intPID);

            //Use this info to fill out the form
            //Loop through the records store in the reader 1 record at a time
            //Since this is based on one person's ID we should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them into the appropriate text fields
                txtFname.Text = dr["Fname"].ToString();
                txtMname.Text = dr["Mname"].ToString();
                txtLname.Text = dr["Lname"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtAddress2.Text = dr["Address2"].ToString();
                txtCity.Text = dr["City"].ToString();
                cmbState.SelectedItem = dr["State"].ToString();
                txtZip.Text = dr["Zip"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtAlternatePhone.Text = dr["AlternatePhone"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtGender.Text = dr["Gender"].ToString();
                dtpBirthdate.Value = (DateTime)dr["Birthdate"];
                txtAge.Text = dr["Age"].ToString();
                cmbMaritalStatus.SelectedItem = dr["MaritalStatus"].ToString();
                txtRace.Text = dr["Race"].ToString();
                txtEthnicity.Text = dr["Ethnicity"].ToString();
                txtLanguage.Text = dr["Language"].ToString();
                txtHeight.Text = dr["Height"].ToString();
                txtWeight.Text = dr["Weight"].ToString();
                txtPrimayCareProvider.Text = dr["PrimaryCareProvider"].ToString();
                txtInsuranceProvider.Text = dr["InsuranceProvider"].ToString();
                cmbWorkStatus.SelectedItem = dr["WorkStatus"].ToString();
                txtOccupation.Text = dr["Occupation"].ToString();
                txtEmployer.Text = dr["Employer"].ToString();
                txtEmployerPhone.Text = dr["EmployerPhone"].ToString();
                txtSchool.Text = dr["School"].ToString();
                txtFieldofStudy.Text = dr["FieldofStudy"].ToString();
                txtSchoolPhone.Text = dr["SchoolPhone"].ToString();
                txtEmergencyFname.Text = dr["EmergencyFname"].ToString();
                txtEmergencyMname.Text = dr["EmergencyMname"].ToString();
                txtEmergencyLname.Text = dr["EmergencyLname"].ToString();
                cmbRelationship.SelectedItem = dr["Relationship"].ToString();
                txtEmergencyAddress.Text = dr["EmergencyAddress"].ToString();
                txtEmergencyAddress2.Text = dr["EmergencyAddress2"].ToString();
                txtEmergencyCity.Text = dr["EmergencyCity"].ToString();
                cmbEmergencyState.SelectedItem = dr["EmergencyState"].ToString();
                txtEmergencyZip.Text = dr["EmergencyZip"].ToString();
                txtEmergencyPhone.Text = dr["EmergencyPhone"].ToString();
                txtEmergencyAlternatePhone.Text = dr["EmergencyAlternatePhone"].ToString();

                //We add this one to store the ID in a new label on the form
                lblPID.Text = dr["PatientID"].ToString();
            }
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            //When Form loads fill the state dropdown
            FillStateList();
            //When form loads set State index to 0
            cmbState.SelectedIndex = 0;

            //When form loads fill the marital status drop down
            FillMaritalStatus();
            //When form loads set Marital Status index to 0
            cmbMaritalStatus.SelectedIndex = 0;

            //When form loads fill work status drop down
            FillWorkStatus();
            //When Form Loads set Work Status index to 0
            cmbWorkStatus.SelectedIndex = 0;

            //When form loads fill Relationship drop down
            FillRelationship();
            //When form loads set Relationship index to 0
            cmbRelationship.SelectedIndex = 0;

            //When form loads fill Emergency State
            FillEmergencyState();
            //When form loads set the Emergency State index to 0
            cmbEmergencyState.SelectedIndex = 0;
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

        //Filling Marital Status Dropdown
        public void FillMaritalStatus()
        {
            cmbMaritalStatus.Items.Add("Single");
            cmbMaritalStatus.Items.Add("Married");
            cmbMaritalStatus.Items.Add("Divorced");
            cmbMaritalStatus.Items.Insert(0, "Please Choose One");
        }

        //Filling Work Status Dropdown
        public void FillWorkStatus()
        {
            cmbWorkStatus.Items.Add("Employed");
            cmbWorkStatus.Items.Add("Unemployed");
            cmbWorkStatus.Items.Insert(0, "Please Choose One");
        }

        //Filling Relationship Dropdown
        public void FillRelationship()
        {
            cmbRelationship.Items.Add("Parent");
            cmbRelationship.Items.Add("Sibling");
            cmbRelationship.Items.Add("Friend");
            cmbRelationship.Items.Add("Significant Other");
            cmbRelationship.Items.Insert(0, "Please Choose One");
        }

        //Filling Emergency State Dropdown
        public void FillEmergencyState()
        {
            cmbEmergencyState.Items.Add("RI");
            cmbEmergencyState.Items.Add("CT");
            cmbEmergencyState.Items.Add("MA");
            cmbEmergencyState.Items.Add("NH");
            cmbEmergencyState.Items.Insert(0, "Please Choose One");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Clear the feedback label
            lblFeedback.Text = "";

            //Creating a Patient Ifno instance (blank)
            PatientInfo Apatient = new PatientInfo();
            //Filling in information from the form
            //Patient Demographics
            Apatient.Fname = txtFname.Text;
            Apatient.Mname = txtMname.Text;
            Apatient.Lname = txtLname.Text;
            Apatient.Address = txtAddress.Text;
            Apatient.Address2 = txtAddress2.Text;
            Apatient.City = txtCity.Text;
            Apatient.State = cmbState.SelectedItem.ToString();
            Apatient.Zip = txtZip.Text;
            Apatient.Phone = txtPhone.Text;
            Apatient.AlternatePhone = txtAlternatePhone.Text;
            Apatient.Email = txtEmail.Text;
            Apatient.Gender = txtGender.Text;
            Apatient.Birthdate = dtpBirthdate.Value;
            Apatient.Age = txtAge.Text;
            Apatient.MaritalStatus = cmbMaritalStatus.SelectedItem.ToString();
            Apatient.Race = txtRace.Text;
            Apatient.Ethnicity = txtEthnicity.Text;
            Apatient.Language = txtLanguage.Text;
            Apatient.Height = txtHeight.Text;
            Apatient.Weight = txtWeight.Text;
            Apatient.PrimaryCareProvider = txtPrimayCareProvider.Text;
            Apatient.InsuranceProvider = txtInsuranceProvider.Text;
            //Emplyoment/School Information
            Apatient.WorkStatus = cmbWorkStatus.SelectedItem.ToString();
            Apatient.Occupation = txtOccupation.Text;
            Apatient.Employer = txtEmployer.Text;
            Apatient.EmployerPhone = txtEmployerPhone.Text;
            Apatient.School = txtSchool.Text;
            Apatient.FieldofStudy = txtFieldofStudy.Text;
            Apatient.SchoolPhone = txtSchoolPhone.Text;
            //Emergency Contact Information
            Apatient.EmergencyFname = txtEmergencyFname.Text;
            Apatient.EmergencyMname = txtEmergencyMname.Text;
            Apatient.EmergencyLname = txtEmergencyLname.Text;
            Apatient.Relationship = cmbRelationship.SelectedItem.ToString();
            Apatient.EmergencyAddress = txtEmergencyAddress.Text;
            Apatient.EmergencyAddress2 = txtEmergencyAddress2.Text;
            Apatient.EmergencyCity = txtEmergencyCity.Text;
            Apatient.EmergencyState = cmbEmergencyState.SelectedItem.ToString();
            Apatient.EmergencyZip = txtEmergencyZip.Text;
            Apatient.EmergencyPhone = txtEmergencyPhone.Text;
            Apatient.EmergencyAlternatePhone = txtEmergencyAlternatePhone.Text;

            //If an error in information occurs..
            if (Apatient.Feedback.Contains("ERROR:"))
            {
                //display the error message in windows form
                lblFeedback.Text = Apatient.Feedback;
            }
            else //No error was found, ok move forward and display the data
            {
                //Fill label with the patients information
                FillLabel(Apatient);
                lblFeedback.Text = Apatient.AddRecord();
            }
        }

        public void FillLabel(PatientInfo temp)
        {
            //Sending the persons information to the label
            //Patient information
            lblFeedback.Text = temp.Fname + " ";
            lblFeedback.Text += temp.Mname + " ";
            lblFeedback.Text += temp.Lname + "\n";
            lblFeedback.Text += temp.Address + " ";
            lblFeedback.Text += temp.Address2 + " ";
            lblFeedback.Text += temp.City + " ";
            lblFeedback.Text += temp.State + " ";
            lblFeedback.Text += temp.Zip + "\n";
            lblFeedback.Text += temp.Phone + " ";
            lblFeedback.Text += temp.AlternatePhone + " ";
            lblFeedback.Text += temp.Email + " ";
            lblFeedback.Text += temp.Gender + " ";
            lblFeedback.Text += "Birthdate: " + temp.Birthdate + " ";
            lblFeedback.Text += "Age: " + temp.Age + "\n";
            lblFeedback.Text += temp.MaritalStatus + " ";
            lblFeedback.Text += temp.Race + " ";
            lblFeedback.Text += temp.Ethnicity + " ";
            lblFeedback.Text += "Preffered Languge: " + temp.Language + "\n ";
            lblFeedback.Text += "Height(in/cm): " + temp.Height + " ";
            lblFeedback.Text += "Weight(lbs/kgs): " + temp.Weight + "\n";
            lblFeedback.Text += temp.PrimaryCareProvider + "\n";
            lblFeedback.Text += "Insurance Provider: " + temp.InsuranceProvider + "\n";
            //Employer/School information
            lblFeedback.Text += temp.WorkStatus + " ";
            lblFeedback.Text += temp.Occupation + " ";
            lblFeedback.Text += temp.Employer + " ";
            lblFeedback.Text += temp.EmployerPhone + "\n";
            lblFeedback.Text += temp.School + " ";
            lblFeedback.Text += temp.FieldofStudy + " ";
            lblFeedback.Text += temp.SchoolPhone + "\n";
            //Emergency Contact Information
            lblFeedback.Text += temp.EmergencyFname + " ";
            lblFeedback.Text += temp.EmergencyMname + " ";
            lblFeedback.Text += temp.EmergencyLname + "\n";
            lblFeedback.Text += "Relationship: " + temp.Relationship + "\n";
            lblFeedback.Text += temp.EmergencyAddress + " ";
            lblFeedback.Text += temp.EmergencyAddress2 + " ";
            lblFeedback.Text += temp.EmergencyCity + " ";
            lblFeedback.Text += temp.EmergencyState + " ";
            lblFeedback.Text += temp.EmergencyZip + "\n";
            lblFeedback.Text += temp.EmergencyPhone + " ";
            lblFeedback.Text += temp.EmergencyAlternatePhone + " ";
        }

        private void FillLabel()
        {
            //Show in the feedback label when they search an unknown patient
            lblFeedback.Text = "Unknown Patient.... Lack of Data";
        }

        private void btnInsuranceInfo_Click(object sender, EventArgs e)
        {
            //Creating a new instance of Patient Information form
            InsuranceInfo temp = new InsuranceInfo();
            //ShowDialog makes it so that they can't click outside the form while it is open
            //You need to close the form in order to be able to open up another one, or click on another form.
            temp.ShowDialog();
        }

        private void btnMedicalHistory_Click(object sender, EventArgs e)
        {
            //Creating a new instance of Medical History form
            MedicalHistory temp = new MedicalHistory();
            //ShowDialog makes it so that they can't click outside the form while it is open
            //You need to close the form in order to be able to open up another one, or click on another form.
            temp.ShowDialog();
        }
    }
}
