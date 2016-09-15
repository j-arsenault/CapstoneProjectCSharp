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
        private string socialSecNum;
        private DateTime subscriberBirthday;
        private string patientRelationship;
        private string secondaryInsurance;
        private string secondaryGroupNum;
        private string secondaryPolicyNum;
        private string secondaryCopayment;
        private string secondarySubscriberName;
        private string secondarySocialSecNum;
        private DateTime secondaryBirthday;
        private string secondaryPatientRelationship;
        private string feedback;


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
                //Validating that the first name field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the First name field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance... \n";
                }
                else
                {
                    insurance = value; //"value" is a keyword that represents the value in the public var (Fname)
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
                //Validating that the first name field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the First name field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Group Number... \n";
                }
                else
                {
                    groupNum = value; //"value" is a keyword that represents the value in the public var (Fname)
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
                //Validating that the first name field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the First name field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Policy Number... \n";
                }
                else
                {
                    policyNum = value; //"value" is a keyword that represents the value in the public var (Fname)
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
                //Validating that the first name field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the First name field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Copayment... \n";
                }
                else
                {
                    copayment = value; //"value" is a keyword that represents the value in the public var (Fname)
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
                //Validating that the first name field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the First name field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Subscriber Name... \n";
                }
                else
                {
                    subscriberName = value; //"value" is a keyword that represents the value in the public var (Fname)
                }
            }
        }

        public string SocialSecNum
        {
            //returns a copy of the value stored in the private variable to the outside world
            //right now we share a copy of this info openly.
            get { return socialSecNum; }


            set
            {
                //Validating that the first name field has at least one character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the user that the First name field must have at least one character in it
                    feedback += "ERROR: Please enter in a Primary Insurance Social Security Number... \n";
                }
                else
                {
                    socialSecNum = value; //"value" is a keyword that represents the value in the public var (Fname)
                }
            }
        }

        public DateTime SubscriberBirthday
        {
            get { return subscriberBirthday; }
            set { subscriberBirthday = value; }
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

        public DateTime SecondaryBirthday
        {
            get { return secondaryBirthday; }
            set { secondaryBirthday = value; }
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
            socialSecNum = "";
            secondarySocialSecNum = "";
        }

        //Adding a record
        public virtual string AddRecord()
        {
            //Clearing strFeedback
            string strFeedback = "";
            
            //SQL Command to add a record to the Patient Information DB
            string strSQL = "INSERT INTO PatientInfo (Insurance, GroupNum, PolicyNum, Copayment, SubscriberName, SocialSecNum, SubscriberBirthday, PatientRelationship, SecondaryInsurance, SecondaryGroupNum, SecondaryPolicyNum, SecondaryCopayment, SecondarySubscriberName, SecondarySocialSecNum, SecondaryBirthday, SecondaryPatientRelationship) VALUES (@Insurance, @GroupNum, @PolicyNum, @Copayment, @SubscriberName, @SocialSecNum, @SubscriberBirthday, @PatientRelationship, @SecondaryInsurance, @SecondaryGroupNum, @SecondaryPolicyNum, @SecondaryCopayment, @SecondarySubscriberName, @SecondarySocialSecNum, @SecondaryBirthday, @SecondaryPatientRelationship)";*/

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
            comm.Parameters.AddWithValue(@"SocialSecNum", SocialSecNum);
            comm.Parameters.AddWithValue(@"SubscriberBirthday", SubscriberBirthday.ToString());
            comm.Parameters.AddWithValue(@"PatientRelationship", PatientRelationship);
            comm.Parameters.AddWithValue(@"SecondaryInsurance", SecondaryInsurance);
            comm.Parameters.AddWithValue(@"SecondaryGroupNum", SecondaryGroupNum);
            comm.Parameters.AddWithValue(@"SecondaryPolicyNum", SecondaryPolicyNum);
            comm.Parameters.AddWithValue(@"SecondaryCopayment", SecondaryCopayment);
            comm.Parameters.AddWithValue(@"SecondarySubscriberName", SecondarySubscriberName);
            comm.Parameters.AddWithValue(@"SecondarySocialSecNum", SecondarySocialSecNum);
            comm.Parameters.AddWithValue(@"SecondaryBirthday", SecondaryBirthday.ToString());
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

    }
}
