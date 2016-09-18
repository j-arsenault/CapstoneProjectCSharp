using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Library to connect to SQLs DB

namespace PatientRecords
{
    public partial class Form1 : Form
    {
        //This is a hardcode test of the login
        //Setting AUser and UPassword equal to values
        //These values will be used to test if the login works correctly
        string AUser = "";
        string UPassword = "";

        public Form1()
        {
            InitializeComponent();
            //Hides password in the password textbox
            txtPwd.PasswordChar = '*';
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
            /*
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
             */
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //~~~~~~~~~~~~~~~ -=------ DATA DRIVEN LOGIN W/ ADMIN LEVELS! ------- ~~~~~~~~~~~~~~~~~
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Check to see if the user/pw combo exists within our DB table

            //If login is valid
            //Disable/Invisible the Login Panel
            //Enable/Show the controls panel
            //1 is the highest admin and 10 is a basic user (5 and less is allowed access)

            int intLevel = EmployeeLogin(txtUName.Text, txtPwd.Text);
            if (intLevel <= 5 && intLevel != 0)
            {
                //Make controls available to the user
                pnlControls.Enabled = true;
                pnlControls.Visible = true;

                //Make the login unavailable
                pnlLogin.Enabled = false;
                pnlLogin.Visible = false;

                //Alert user they have successfully logged in
                MessageBox.Show("You're now logged in!");
            }
            //If Invalid:
            //Display invalid login message
            //Make sure the Control Panel is disabled still
            else
            {
                //Make controls unavailable
                pnlControls.Enabled = false;
                pnlControls.Visible = false;

                //Make login available
                pnlLogin.Visible = true;
                pnlLogin.Enabled = true;

                //Let user know their attempt to login didn't succeed
                lblFeedback.Text = "Sorry... Invalid Login, Please Try Again!";
            }
        }

        private int EmployeeLogin(string strUName, string strPWD)
        {
            //Declare a variable to hold the admin level
            int intAdminLevel = 0;

            //Create a datareader to return filled
            SqlDataReader dr;

            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();

            //Write a Select Statement to peform Search
            string strSQL = "SELECT MyLevel FROM UserLogin WHERE (UName = @UName AND PWD = @PWD)";
            //Set parameters
            comm.Parameters.AddWithValue("@UName", strUName);
            comm.Parameters.AddWithValue("@PWD", strPWD);

            //Create DB tools and configure
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = MyTools.GetConnected();

            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;                //Tell the command what connection to use
            comm.CommandText = strSQL;             //Tell the command what to say

            //Get the data
            //Open the DB connection
            conn.Open();
            dr = comm.ExecuteReader(); //Fill the datareader

            while (dr.Read())
            {
                //Change the admin level to whatever the employees level is.. else it remains zero
                intAdminLevel = Convert.ToInt16(dr["MyLevel"].ToString());
            }

            //Close the connection
            conn.Close();

            //return the person's admin level
            return intAdminLevel;
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
