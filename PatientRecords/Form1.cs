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
    public partial class Form1 : Form
    {
        //This is a hardcode test of the login
        //Setting AUser and UPassword equal to values
        //These values will be used to test if the login works correctly
        string AUser = "Jameson";
        string UPassword = "password";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Clear the feedback label
            lblFeedback.Text = "";

            /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             * ~~~~~~~~~~~~~~~~~~~~~===============  HARD CODED LOGIN!!=======~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             */
            //Check to see if the Username and Password entered equal the values that have been hardcoded
            //If login is valid
            //Disable/Invisible the Login Panel
            //Enable/Show the Controls Panel
            if (txtUName.Text == AUser && txtPwd.Text == UPassword)
            {
                //Make the Controls Panel available
                pnlControls.Enabled = true;
                pnlControls.Visible = true;

                //Make the Login Panel unavailable
                pnlLogin.Enabled = false;
                pnlLogin.Visible = false;
            }

            //If invalid:
            //Display the invalid login message
            //Make sure the Control Panel is still disabled
            else
            {
                //Make Controls Panel unavailable
                pnlControls.Enabled = false;
                pnlControls.Visible = false;

                //Make the Login Panel available
                pnlLogin.Enabled = true;
                pnlLogin.Visible = true;

                //Let user know the login was invalid
                lblFeedback.Text = "Sorry! Inalid Login. \nPlease enter proper Login information!";
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            //Creating a new instance of Patient Information form
            PatientInformation temp = new PatientInformation();
            //ShowDialog makes it so that they can't click outside the form while it is open
            //You need to close the form in order to be able to open up another one, or click on another form.
            temp.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Creating a new instance of the Search from
            Search temp = new Search();
            //ShowDialog makes it so that they can't click outside the form while it is open
            //You need to close the search form in order to be able to open up another one, or click on another form.
            temp.ShowDialog();
        }
    }
}
