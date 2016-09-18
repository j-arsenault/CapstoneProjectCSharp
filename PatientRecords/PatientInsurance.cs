using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Library to bring in a dataset
using System.Data.SqlClient; //Library to connect to SQL DB's

namespace PatientRecords
{
    //Creating a class to represent a Patient Insurance Object
    public class PatientInsurance
    {
        //Making the variables private, no one but the class itself can access
        private string insurance;
        private string groupNum;
        private string policyNum;
        private string copayment;
        private string subscriberName;
        private string subscriberSocialSecNum;
        private DateTime subscriberBirthdate;
        private string patientRelationship;
        private string secondaryInsurance;
        private string secondaryGroupNum;
        private string secondaryPolicyNum;
        private string secondaryCopayment;
        private string secondarySubscriberName;
        private string secondarySocialSecNum;
        private DateTime secondarySubscriberBirthdate;
        private string secondaryPatientRelationship;
        private string feedback;
        public Int32 PatientID = 0;
        public Int32 InsuranceID = 0;

        //These are public variables that are the front-end to the private variables.
        //They protect the private variables from getting bogus information, or giving out data to the wrong person
        public string Feedback
        {
            get { return feedback; }
        }

        public string Insurance
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return insurance; }


            set
            {
                //Validating that the Insurance field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the Insurance field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance... \n";
                }
                else
                {
                    insurance = value; //"value" is a keyword that represents the value in the public var (Insurance)
                }
            }
        }

        public string GroupNum
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return groupNum; }


            set
            {
                //Validating that the GroupNum field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the GroupNum field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Group Number... \n";
                }
                else
                {
                    groupNum = value; //"value" is a keyword that represents the value in the public var (GroupNum)
                }
            }
        }

        public string PolicyNum
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return policyNum; }


            set
            {
                //Validating that the PolicyNum field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the PolicyNum field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Policy Number... \n";
                }
                else
                {
                    policyNum = value; //"value" is a keyword that represents the value in the public var (PolicyNum)
                }
            }
        }

        public string Copayment
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return copayment; }


            set
            {
                //Validating that the Copayment field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the Copayment field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Copayment... \n";
                }
                else
                {
                    copayment = value; //"value" is a keyword that represents the value in the public var (Copayment)
                }
            }
        }

        public string SubscriberName
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return subscriberName; }


            set
            {
                //Validating that the SubscriberName field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the SubscriberName field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Subscriber Name... \n";
                }
                else
                {
                    subscriberName = value; //"value" is a keyword that represents the value in the public var (SubscriberName)
                }
            }
        }

        public string SubscriberSocialSecNum
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return subscriberSocialSecNum; }


            set
            {
                //Validating that the SubscriberSocialSecNum field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the SubscriberSocialSecNum field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Social Security Number... \n";
                }
                else
                {
                    subscriberSocialSecNum = value; //"value" is a keyword that represents the value in the public var (SubscriberSocialSecNum)
                }
            }
        }

        public DateTime SubscriberBirthdate
        {
            get { return subscriberBirthdate; }
            set { subscriberBirthdate = value; }
        }

        public string PatientRelationship
        {
            get { return patientRelationship; }
            set { patientRelationship = value; }
        }

        public string SecondaryInsurance
        {
            get { return secondaryInsurance; }
            set { secondaryInsurance = value; }
        }

        public string SecondaryGroupNum
        {
            get { return secondaryGroupNum; }
            set { secondaryGroupNum = value; }
        }

        public string SecondaryPolicyNum
        {
            get { return secondaryPolicyNum; }
            set { secondaryPolicyNum = value; }
        }

        public string SecondaryCopayment
        {
            get { return secondaryCopayment; }
            set { secondaryCopayment = value; }
        }

        public string SecondarySubscriberName
        {
            get { return secondarySubscriberName; }
            set { secondarySubscriberName = value; }
        }

        public string SecondarySocialSecNum
        {
            get { return secondarySocialSecNum; }
            set { secondarySocialSecNum = value; }
        }

        public DateTime SecondarySubscriberBirthdate
        {
            get { return secondarySubscriberBirthdate; }
            set { secondarySubscriberBirthdate = value; }
        }

        public string SecondaryPatientRelationship
        {
            get { return secondaryPatientRelationship; }
            set { secondaryPatientRelationship = value; }
        }

        //Default Constructor
        public PatientInsurance()
        {
            //Start by giving feedback an empty string
            feedback = "";
            subscriberSocialSecNum = "";
            secondarySocialSecNum = "";
        }

        //Adding a record
        public virtual string AddRecord()
        {
            //Clearing strFeedback
            string strFeedback = "";
            
            //SQL Command to add a record to the Patient Information DB
            string strSQL = "INSERT INTO PatientInsurance (Insurance, GroupNum, PolicyNum, Copayment, SubscriberName, SubscriberBirthdate, SubscriberSocialSecNum, PatientRelationship, SecondaryInsurance, SecondaryGroupNum, SecondaryPolicyNum, SecondaryCopayment, SecondarySubscriberName, SecondarySubscriberBirthdate, SecondarySocialSecNum, SecondaryPatientRelationship) VALUES (@Insurance, @GroupNum, @PolicyNum, @Copayment, @SubscriberName, @SubscriberBirthdate, @SubscriberSocialSecNum, @PatientRelationship, @SecondaryInsurance, @SecondaryGroupNum, @SecondaryPolicyNum, @SecondaryCopayment, @SecondarySubscriberName, @SecondarySubscriberBirthdate, @SecondarySocialSecNum, @SecondaryPatientRelationship)";

            //creating database connection 
            SqlConnection conn = new SqlConnection();
            //Create the who what and where of the DB
            string strConn = MyTools.GetConnected();
            //Creating the connection string using the oldedb conn variable and equaling it to the information gathered from connectionstring website
            conn.ConnectionString = strConn;

            //creating database command connection
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; //Commander knows what to say
            comm.Connection = conn;   //Getting the connection

            //Fill in the parameters (has to be created in same sequence as they are used in SQL Statement).
            comm.Parameters.AddWithValue(@"Insurance", Insurance);
            comm.Parameters.AddWithValue(@"GroupNum", GroupNum);
            comm.Parameters.AddWithValue(@"PolicyNum", PolicyNum);
            comm.Parameters.AddWithValue(@"Copayment", Copayment);
            comm.Parameters.AddWithValue(@"SubscriberName", SubscriberName);
            comm.Parameters.AddWithValue(@"SubscriberBirthdate", SubscriberBirthdate.ToString());
            comm.Parameters.AddWithValue(@"SubscriberSocialSecNum", SubscriberSocialSecNum);
            comm.Parameters.AddWithValue(@"PatientRelationship", PatientRelationship);
            comm.Parameters.AddWithValue(@"SecondaryInsurance", SecondaryInsurance);
            comm.Parameters.AddWithValue(@"SecondaryGroupNum", SecondaryGroupNum);
            comm.Parameters.AddWithValue(@"SecondaryPolicyNum", SecondaryPolicyNum);
            comm.Parameters.AddWithValue(@"SecondaryCopayment", SecondaryCopayment);
            comm.Parameters.AddWithValue(@"SecondarySubscriberName", SecondarySubscriberName);
            comm.Parameters.AddWithValue(@"SecondarySubscriberBirthdate", SecondarySubscriberBirthdate.ToString());
            comm.Parameters.AddWithValue(@"SecondarySocialSecNum", SecondarySocialSecNum);
            comm.Parameters.AddWithValue(@"SecondaryPatientRelationship", SecondaryPatientRelationship);
            
            try
            {
                //open a connection to the database
                conn.Open();

                //Giving strFeedback the number of records added
                strFeedback = comm.ExecuteNonQuery().ToString() + " Records Added";

                //close the database
                conn.Close();
            }
            catch (Exception err)
            {
                //If we catch an error........
                //Put the error message into strFeedback
                strFeedback = "ERROR: " + err.Message;
            }
            return strFeedback;
        }


        //Method that will update one persons record specified by the ID
        //It will return an integer meant for feedback for how many records were updated
        public Int32 UpdatePatientInfo()
        {
            //Creating a variable to hold the integer of # of records effected
            Int32 intRecords = 0;

            //Create SQL command string
            string strSQL = "UPDATE PatientInsurance SET Insurance = @Insurance, GroupNum = @GroupNum, PolicyNum = @PolicyNum, Copayment = @Copayment, SubscriberName = @SubscriberName, SubscriberBirthdate = @SubscriberBirthdate, SubscriberSocialSecNum = @SubscriberSocialSecNum, PatientRelationship = @PatientRelationship, SecondaryInsurance = @SecondaryInsurance, SecondaryGroupNum = @SecondaryGroupNum, SecondaryPolicyNum = @SecondaryPolicyNum, SecondaryCopayment = @SecondaryCopayment, SecondarySubscriberName = @SecondarySubscriberName, SecondarySubscriberBirthdate = @SecondarySubscriberBirthdate, SecondarySocialSecNum = @SecondarySocialSecNum, SecondaryPatientRelationship = @SecondaryPatientRelationship, PatientID = @PatientID WHERE InsuranceID = @InsuranceID;";

            //Create connection to the DB
            SqlConnection conn = new SqlConnection();

            //Connection string to the DB
            //The Connection String being used
            //Create the who what and where of the DB
            string strConn = MyTools.GetConnected();
            conn.ConnectionString = strConn;

            //Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = conn;  //Getting the connection

            //Fill in the parameters
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //~~~~~~~HAS TO BE IN THE SAME SEQUENCE AS THEY ARE USED IN THE SQL STATEMENT~~~~~~~~~~~~
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            comm.Parameters.AddWithValue("@Insurance", Insurance);
            comm.Parameters.AddWithValue("@GroupNum", GroupNum);
            comm.Parameters.AddWithValue("@PolicyNum", PolicyNum);
            comm.Parameters.AddWithValue(@"Copayment", Copayment);
            comm.Parameters.AddWithValue(@"SubscriberName", SubscriberName);
            comm.Parameters.AddWithValue(@"SubscriberBirthdate", SubscriberBirthdate.ToString());
            comm.Parameters.AddWithValue(@"SubscriberSocialSecNum", SubscriberSocialSecNum);
            comm.Parameters.AddWithValue(@"PatientRelationship", PatientRelationship);
            comm.Parameters.AddWithValue(@"SecondaryInsurance", SecondaryInsurance);
            comm.Parameters.AddWithValue(@"SecondaryGroupNum", SecondaryGroupNum);
            comm.Parameters.AddWithValue(@"SecondaryPolicyNum", SecondaryPolicyNum);
            comm.Parameters.AddWithValue(@"SecondaryCopayment", SecondaryCopayment);
            comm.Parameters.AddWithValue(@"SecondarySubscriberName", SecondarySubscriberName);
            comm.Parameters.AddWithValue(@"SecondarySubscriberBirthdate", SecondarySubscriberBirthdate.ToString());
            comm.Parameters.AddWithValue(@"SecondarySocialSecNum", SecondarySocialSecNum);
            comm.Parameters.AddWithValue(@"SecondaryPatientRelationship", SecondaryPatientRelationship);
            comm.Parameters.AddWithValue("@PatientID", PatientID);
            comm.Parameters.AddWithValue(@"InsuranceID", InsuranceID);

            try
            {
                //Open the DB connection
                conn.Open();

                //Run the update and store number of records effected
                intRecords = comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
            }
            finally
            {
                //Close the DB connection
                conn.Close();
            }


            //Return # of records updated.
            return intRecords;

        }

        
        public SqlDataReader FindOnePatientInsurance(int intPID)
        {
            //Create and Initialize the DB tools we need to use
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //The Connection String being used
            //Create the who what and where of the DB
            string strConn = MyTools.GetConnected();

            //The SQL Command string to pull up one person's data
            string strSQL = "SELECT InsuranceID, PatientID, Insurance, GroupNum, PolicyNum, Copayment, SubscriberName, SubscriberBirthdate, SubscriberSocialSecNum, PatientRelationship, SecondaryInsurance, SecondaryGroupNum, SecondaryPolicyNum, SecondaryCopayment, SecondarySubscriberName, SecondarySubscriberBirthdate, SecondarySocialSecNum, SecondaryPatientRelationship FROM PatientInsurance WHERE PatientID = @PatientID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = strSQL;
            comm.Parameters.AddWithValue("@PatientID", intPID);

            //Open the DataBase Connection and Yell our SQL command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader(); //Return the dataset to be used by others (the calling form) 
        }
        
    }
}
