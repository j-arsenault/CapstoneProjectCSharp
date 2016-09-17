using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Library to bring in a dataset
using System.Data.SqlClient; //Library to connect to SQL DB's

namespace PatientRecords
{
    //Creating a class to represent a PatientInfo object
    public class PatientInfo
    {
        //Making the variables private, no one but the class itself can access these
        //Patient Info variables
        private string fName;
        private string mName;
        private string lName;
        private string address;
        private string address2;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string alternatePhone;
        private string email;
        private string gender;
        private DateTime birthdate;
        private string age;
        private string maritalStatus;
        private string race;
        private string ethnicity;
        private string language;
        private string height;
        private string weight;
        private string primaryCareProvider;
        private string insuranceProvider;
        //Employer/School Variables
        private string workStatus;
        private string occupation;
        private string employer;
        private string employerPhone;
        private string school;
        private string fieldOfStudy;
        private string schoolPhone;
        //Emergency Contact Variables
        private string emergencyfName;
        private string emergencymName;
        private string emergencylName;
        private string relationship;
        private string emergencyAddress;
        private string emergencyAddress2;
        private string emergencyCity;
        private string emergencyState;
        private string emergencyZip;
        private string emergencyPhone;
        private string emergencyAlternatePhone;
        private string feedback;
        public Int32 PatientID = 0;

        public string Feedback
        {
            get { return feedback; }
        }

        //Creating the public variables that are the front end to the private variables
        //They will protect the private variables from getting bogus data, or giving out data to the wrong person

        public string Fname
        {
            //get returns a copy of the value stored in the private variable to the outside world
            //share a copy of this info openly
            get { return fName; }

            //set allows the private variable to get the value of the public variable if it
            //meets the validation requirements
            set
            {
                //Validating that the first name field has at least one character in it 
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the User that the first name field must have at least one character in it
                    feedback += "ERROR: Invalid First Name.. Must be at least one character.\n";
                }
                else
                {
                    fName = value;
                }
            }
        }

        //Public variable specifically for Middle Name
        public string Mname
        {
            get { return mName; }
            set { mName = value; }
        }

        //Public variable specifically for Last Name
        public string Lname
        {
            get { return lName; }
            set 
            {
                //Validating that the Last name field has at least 1 character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback label telling the user to enter at least 1 character in the last name field
                    feedback += "ERROR: Invalid Last Name... must be at least one character. \n";
                }
                else
                {
                    lName = value;
                }
            }
        }

        //Public variable specifically for Address
        public string Address
        {
            get { return address; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //feedback label telling the user to enter a street address
                    feedback += "ERROR: Please enter in a street address! \n";
                }
                else
                {
                    address = value;
                }
            }
        }

        //Public variable specifically for Address 2
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        //Public variable specifically for City
        public string City
        {
            get { return city; }
            set
            {
                //Validating if someone has filled in a City
                if (!Validation.IsItFilledIn(value))
                {
                    //feedback label telling the user to enter in a City
                    feedback += "ERROR: Please enter in a City! \n";
                }
                else
                {
                    city = value;
                }
            }
        }

        //Public variable specifically for State
        public string State
        {
            get { return state; }
            set
            {
                //Validating if a state is selected based on length
                if (Validation.IsValidLength(value, 2))
                {
                    //Feedback alerting Invalid State, please select one
                    feedback += "ERROR: Invalid State Selected! Please choose a state. \n";
                }
                else
                {
                    state = value;
                }
            }
        }

        //Public variable specifically for Zip code
        public string Zip
        {
            get { return zip; }
            set
            {
                //Validation checking if zip code is empty, and if so alert user to enter a zip code
                if (!Validation.IsItFilledIn(value))
                {
                    feedback += "ERROR: Please enter a zip code!\n";
                }
                //Validating if the zip code text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the zip code is the proper length
                    if (Validation.IsValidLength(value, 5))
                    {
                        //Feedback alerting an Invalid Zip Code, with description of how many characters allowed
                        feedback += "ERROR: Invalid Zip Code! Must be 5 characters.\n";
                    }
                    else
                    {
                        zip = value;
                    }
                }
            }
        }

        //Public variable specifically for Phone
        public string Phone
        {
            get { return phone; }
            set
            {
                //Validation to check if phone number text box is empty, and if so alert them to enter a phone number
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback alerting that the User needs to fill in a phone number
                    feedback += "ERROR: Please enter a Phone Number!  EX: (555) 555-0000 \n";
                }
                //Validating if the phone number text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the phone number given is between 7-10 characters long
                    if (Validation.IsWithinRange(value, 7, 10))
                    {
                        //Feedback alerting user of invalid phone number, and showing an example of an acceptable phone number
                        feedback += "ERROR: Invalid Phone Number!  EX: (555) 555-0000 \n";
                    }
                    else
                    {
                        phone = value;
                    }
                }
            }
        }

        //Public variable specifically for Alternate Phone
        public string AlternatePhone
        {
            get { return alternatePhone; }
            set
            {
                //Validation to check if phone number text box is empty, and if so alert them to enter a phone number
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback alerting that the User needs to fill in a phone number
                    feedback += "ERROR: Please enter an Alternate Phone Number!  EX: (555) 555-0000 \n";
                }
                //Validating if the phone number text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the phone number given is between 7-10 characters long
                    if (Validation.IsWithinRange(value, 7, 10))
                    {
                        //Feedback alerting user of invalid phone number, and showing an example of an acceptable phone number
                        feedback += "ERROR: Invalid Alternate Phone Number!  EX: (555) 555-0000 \n";
                    }
                    else
                    {
                        alternatePhone = value;
                    }
                }
            }
        }

        //Public variable specifically for email
        public string Email
        {
            get { return email; }
            set
            {
                //Validation to check if email text box is empty, and if so alert them to enter an email
                if (!Validation.IsItFilledIn(value))
                {
                    //feedback alerting that the user needs to fill in the email address text box
                    feedback += "ERROR: Please enter an email address. EX: test@test.com \n";
                }
                //Validating if the email text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating the given email
                    if (Validation.IsValidEmail(value) == false)
                    {
                        //Feedback prompting user to correct their email entry
                        feedback += "ERROR: Your email is invalid! Please enter it again! \n";
                    }
                    else
                    {
                        email = value;
                    }
                }
            }
        }

        //Public variable for Gender
        public string Gender
        {
            get { return gender; }
            set
            {
                //Validating if user has filled in the Gender textbox
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback telling user to enter in a gender
                    feedback += "ERROR: Please enter in a gender. \n";
                }
                else
                {
                    gender = value;
                }
            }
        }

        //Public variable for Birthdate
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        //Public variable for Age
        public string Age
        {
            get { return age; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in an Age! \n";
                }
                else
                {
                    age = value;
                }
            }
        }

        //Public variable for MaritalStatus
        public string MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }

        //Public variable for Race
        public string Race
        {
            get { return race; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in a Race! \n";
                }
                else
                {
                    race = value;
                }
            }
        }

        //Public variable for Ethnicity
        public string Ethnicity
        {
            get { return ethnicity; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in an Ethnicity! \n";
                }
                else
                {
                    ethnicity = value;
                }
            }
        }

        //Public variable for Language
        public string Language
        {
            get { return language; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in a Preffered Language! \n";
                }
                else
                {
                    language = value;
                }
            }
        }

        //Public variable for Height
        public string Height
        {
            get { return height; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in a Height! \n";
                }
                else
                {
                    height = value;
                }
            }
        }

        //Public variable for Weight
        public string Weight
        {
            get { return weight; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in a Weight! \n";
                }
                else
                {
                    weight = value;
                }
            }
        }

        //Public variable for PrimaryCareProvider
        public string PrimaryCareProvider
        {
            get { return primaryCareProvider; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in a Primary Care Provider! \n";
                }
                else
                {
                    primaryCareProvider = value;
                }
            }
        }

        //Public variable for InsuranceProvider
        public string InsuranceProvider
        {
            get { return insuranceProvider; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in an Insurance Provider! \n";
                }
                else
                {
                    insuranceProvider = value;
                }
            }
        }

        //Public variable for WorkStatus
        public string WorkStatus
        {
            get { return workStatus; }
            set { workStatus = value; }
        }

        //Public variable for Occupation
        public string Occupation
        {
            get { return occupation; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in an Occupation! \n";
                }
                else
                {
                    occupation = value;
                }
            }
        }
        //Public variable for Employer
        public string Employer
        {
            get { return employer; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback label telling the user to enter in a street address
                    feedback += "ERROR: Please enter in an Employer! \n";
                }
                else
                {
                    employer = value;
                }
            }
        }

        //Public variable for EmployerPhone
        public string EmployerPhone
        {
            get { return employerPhone; }
            set
            {
                //Validation to check if phone number text box is empty, and if so alert them to enter a phone number
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback alerting that the User needs to fill in a phone number
                    feedback += "ERROR: Please enter an Employer Phone Number!  EX: (555) 555-0000 \n";
                }
                //Validating if the phone number text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the phone number given is between 7-10 characters long
                    if (Validation.IsWithinRange(value, 7, 10))
                    {
                        //Feedback alerting user of invalid phone number, and showing an example of an acceptable phone number
                        feedback += "ERROR: Invalid Employer Phone Number!  EX: (555) 555-0000 \n";
                    }
                    else
                    {
                        employerPhone = value;
                    }
                }
            }
        }

        //Public variable for School
        public string School
        {
            get { return school; }
            set
            {
                //Validating that the Last name field has at least 1 character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback label telling the user to enter at least 1 character in the last name field
                    feedback += "ERROR: Invalid School... must be at least one character. \n";
                }
                else
                {
                    school = value;
                }
            }
        }

        //Public variable for FieldofStudy
        public string FieldofStudy
        {
            get { return fieldOfStudy; }
            set
            {
                //Validating that the Last name field has at least 1 character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback label telling the user to enter at least 1 character in the last name field
                    feedback += "ERROR: Invalid Field of Study... must be at least one character. \n";
                }
                else
                {
                    fieldOfStudy = value;
                }
            }
        }

        //Public variable for SchoolPhone
        public string SchoolPhone
        {
            get { return schoolPhone; }
            set
            {
                //Validation to check if phone number text box is empty, and if so alert them to enter a phone number
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback alerting that the User needs to fill in a phone number
                    feedback += "ERROR: Please enter a School Phone Number!  EX: (555) 555-0000 \n";
                }
                //Validating if the phone number text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the phone number given is between 7-10 characters long
                    if (Validation.IsWithinRange(value, 7, 10))
                    {
                        //Feedback alerting user of invalid phone number, and showing an example of an acceptable phone number
                        feedback += "ERROR: Invalid School Phone Number!  EX: (555) 555-0000 \n";
                    }
                    else
                    {
                        schoolPhone = value;
                    }
                }
            }
        }

        //Public variable for EmergencyFname
        public string EmergencyFname
        {
            //get returns a copy of the value stored in the private variable to the outside world
            //share a copy of this info openly
            get { return emergencyfName; }

            //set allows the private variable to get the value of the public variable if it
            //meets the validation requirements
            set
            {
                //Validating that the first name field has at least one character in it 
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback prompting the User that the first name field must have at least one character in it
                    feedback += "Error: Invalid Emergency Contact First Name.. Must be at least one character.\n";
                }
                else
                {
                    emergencyfName = value;
                }
            }
        }

        //Public variable for EmergencyMname
        public string EmergencyMname
        {
            get { return emergencymName; }
            set { emergencymName = value; }
        }

        //Public variable for EmergencyLname
        public string EmergencyLname
        {
            get { return emergencylName; }
            set
            {
                //Validating that the Last name field has at least 1 character in it
                if (Validation.IsItFilledIn(value, 1) == false)
                {
                    //Feedback label telling the user to enter at least 1 character in the last name field
                    feedback += "ERROR: Invalid Emergency Contact Last Name... must be at least one character. \n";
                }
                else
                {
                   emergencylName = value;
                }
            }
        }

        //Public variable for Relationship
        public string Relationship
        {
            get { return relationship; }
            set { relationship = value; }
        }

        //Public variable for EmergencyAddress
        public string EmergencyAddress
        {
            get { return emergencyAddress; }
            set
            {
                //Validating if someone has filled in the street address
                if (!Validation.IsItFilledIn(value))
                {
                    //feedback label telling the user to enter a street address
                    feedback += "ERROR: Please enter in an Emergency Contact Address! \n";
                }
                else
                {
                    emergencyAddress = value;
                }
            }
        }

        //Public variable for EmergencyAddress2
        public string EmergencyAddress2
        {
            get { return emergencyAddress2; }
            set { emergencyAddress2 = value; }
        }

        //Public variable for EmergencyCity
        public string EmergencyCity
        {
            get { return emergencyCity; }
            set
            {
                //Validating if someone has filled in a City
                if (!Validation.IsItFilledIn(value))
                {
                    //feedback label telling the user to enter in a City
                    feedback += "ERROR: Please enter in an Emergency Contact City! \n";
                }
                else
                {
                    emergencyCity = value;
                }
            }
        }

        //Public variable for EmergencyState
        public string EmergencyState
        {
            get { return emergencyState; }
            set
            {
                //Validating if a state is selected based on length
                if (Validation.IsValidLength(value, 2))
                {
                    //Feedback alerting Invalid State, please select one
                    feedback += "ERROR: Invalid Emergency Contact State Selected! Please choose a state. \n";
                }
                else
                {
                    emergencyState = value;
                }
            }
        }

        //Public variable for EmergencyZip
        public string EmergencyZip
        {
            get { return emergencyZip; }
            set
            {
                //Validation checking if zip code is empty, and if so alert user to enter a zip code
                if (!Validation.IsItFilledIn(value))
                {
                    feedback += "ERROR: Please enter a Emergency Contact Zip code!\n";
                }
                //Validating if the zip code text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the zip code is the proper length
                    if (Validation.IsValidLength(value, 5))
                    {
                        //Feedback alerting an Invalid Zip Code, with description of how many characters allowed
                        feedback += "ERROR: Invalid Emergency Contact Zip Code! Must be 5 characters.\n";
                    }
                    else
                    {
                        emergencyZip = value;
                    }
                }
            }
        }

        //Public variable for EmergencyPhone
        public string EmergencyPhone
        {
            get { return emergencyPhone; }
            set
            {
                //Validation to check if phone number text box is empty, and if so alert them to enter a phone number
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback alerting that the User needs to fill in a phone number
                    feedback += "ERROR: Please enter a Emergency Contact Phone Number!  EX: (555) 555-0000 \n";
                }
                //Validating if the phone number text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the phone number given is between 7-10 characters long
                    if (Validation.IsWithinRange(value, 7, 10))
                    {
                        //Feedback alerting user of invalid phone number, and showing an example of an acceptable phone number
                        feedback += "ERROR: Invalid Emergency Contact Phone Number!  EX: (555) 555-0000 \n";
                    }
                    else
                    {
                        emergencyPhone = value;
                    }
                }
            }
        }

        //Public variable for EmergencyAlternatePhone
        public string EmergencyAlternatePhone
        {
            get { return emergencyAlternatePhone; }
            set
            {
                //Validation to check if phone number text box is empty, and if so alert them to enter a phone number
                if (!Validation.IsItFilledIn(value))
                {
                    //Feedback alerting that the User needs to fill in a phone number
                    feedback += "ERROR: Please enter a Emergency Contact Alternate Phone Number!  EX: (555) 555-0000 \n";
                }
                //Validating if the phone number text box is filled in
                else if (Validation.IsItFilledIn(value))
                {
                    //Validating if the phone number given is between 7-10 characters long
                    if (Validation.IsWithinRange(value, 7, 10))
                    {
                        //Feedback alerting user of invalid phone number, and showing an example of an acceptable phone number
                        feedback += "ERROR: Invalid Emergency Contact Alternate Phone Number!  EX: (555) 555-0000 \n";
                    }
                    else
                    {
                        emergencyAlternatePhone = value;
                    }
                }
            }
        }

        //Default Constructor
        public PatientInfo()
        {
            //Start by giving feedback, phone, alt phone an empty string
            feedback = "";
            phone = "";
            alternatePhone = "";
            employerPhone = "";
            schoolPhone = "";
            emergencyPhone = "";
            emergencyAlternatePhone = "";
        }

        //Adding a record
        public virtual string AddRecord()
        {
            //Clearing strFeedback
            string strFeedback = "";
            
            //SQL Command to add a record to the Patient Information DB
            string strSQL = "INSERT INTO Patients (Fname, Mname, Lname, Address, Address2, City, State, Zip, Phone, AlternatePhone, Email, Gender, Birthdate, Age, MaritalStatus, Race, Ethnicity, Language, Height, Weight, PrimaryCareProvider, InsuranceProvider, WorkStatus, Occupation, Employer, EmployerPhone, School, FieldofStudy, SchoolPhone, EmergencyFname, EmergencyMname, EmergencyLname, Relationship, EmergencyAddress, EmergencyAddress2, EmergencyCity, EmergencyState, EmergencyZip, EmergencyPhone, EmergencyAlternatePhone) VALUES (@Fname, @Mname, @Lname, @Address, @Address2, @City, @State, @Zip, @Phone, @AlternatePhone, @Email, @Gender, @Birthdate, @Age, @MaritalStatus, @Race, @Ethnicity, @Language, @Height, @Weight, @PrimaryCareProvider, @InsuranceProvider, @WorkStatus, @Occupation, @Employer, @EmployerPhone, @School, @FieldofStudy, @SchoolPhone, @EmergencyFname, @EmergencyMname, @EmergencyLname, @Relationship, @EmergencyAddress, @EmergencyAddress2, @EmergencyCity, @EmergencyState, @EmergencyZip, @EmergencyPhone, @EmergencyAlternatePhone)";

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
            comm.Parameters.AddWithValue(@"Fname", Fname);
            comm.Parameters.AddWithValue(@"Mname", Mname);
            comm.Parameters.AddWithValue(@"Lname", Lname);
            comm.Parameters.AddWithValue(@"Address", Address);
            comm.Parameters.AddWithValue(@"Address2", Address2);
            comm.Parameters.AddWithValue(@"City", City);
            comm.Parameters.AddWithValue(@"State", State);
            comm.Parameters.AddWithValue(@"Zip", Zip);
            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"AlternatePhone", AlternatePhone);
            comm.Parameters.AddWithValue(@"Email", Email);
            comm.Parameters.AddWithValue(@"Gender", Gender);
            comm.Parameters.AddWithValue(@"Birthdate", Birthdate.ToString());
            comm.Parameters.AddWithValue(@"Age", Age);
            comm.Parameters.AddWithValue(@"MaritalStatus", MaritalStatus);
            comm.Parameters.AddWithValue(@"Race", Race);
            comm.Parameters.AddWithValue(@"Ethnicity", Ethnicity);
            comm.Parameters.AddWithValue(@"Language", Language);
            comm.Parameters.AddWithValue(@"Height", Height);
            comm.Parameters.AddWithValue(@"Weight", Weight);
            comm.Parameters.AddWithValue(@"PrimaryCareProvider", PrimaryCareProvider);
            comm.Parameters.AddWithValue(@"InsuranceProvider", InsuranceProvider);
            comm.Parameters.AddWithValue(@"WorkStatus", WorkStatus);
            comm.Parameters.AddWithValue(@"Occupation", Occupation);
            comm.Parameters.AddWithValue(@"Employer", Employer);
            comm.Parameters.AddWithValue(@"EmployerPhone", EmployerPhone);
            comm.Parameters.AddWithValue(@"School", School);
            comm.Parameters.AddWithValue(@"FieldofStudy", FieldofStudy);
            comm.Parameters.AddWithValue(@"SchoolPhone", SchoolPhone);
            comm.Parameters.AddWithValue(@"EmergencyFname", EmergencyFname);
            comm.Parameters.AddWithValue(@"EmergencyMname", EmergencyMname);
            comm.Parameters.AddWithValue(@"EmergencyLname", EmergencyLname);
            comm.Parameters.AddWithValue(@"Relationship", Relationship);
            comm.Parameters.AddWithValue(@"EmergencyAddress", EmergencyAddress);
            comm.Parameters.AddWithValue(@"EmergencyAddress2", EmergencyAddress2);
            comm.Parameters.AddWithValue(@"EmergencyCity", EmergencyCity);
            comm.Parameters.AddWithValue(@"EmergencyState", EmergencyState);
            comm.Parameters.AddWithValue(@"EmergencyZip", EmergencyZip);
            comm.Parameters.AddWithValue(@"EmergencyPhone", EmergencyPhone);
            comm.Parameters.AddWithValue(@"EmergencyAlternatePhone", EmergencyAlternatePhone);

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

        //Function called Search Patients
        //Used for searching all the records
        public DataSet SearchPatients(string myFirst, string myLast)
        {
            //Create an empty dataset (a copy of your DB or table)
            DataSet ds = new DataSet();

            //Time to populate the dataset
            //Use conn to get DB connection
            SqlConnection conn = new SqlConnection();
            //Creating an sql command.
            SqlCommand comm = new SqlCommand();
            //Creating DataAdapter to act as the translator between comm and the dataset
            SqlDataAdapter da = new SqlDataAdapter();

            //Sql command to add a record to the persons db 
            string strSQL = "SELECT PatientID, Fname, Mname, Lname, Address, Address2 FROM Patients WHERE 0=0";

            //Create the who what and where of the DB
            string strConn = MyTools.GetConnected();

            //Start Populating properties for our data objects
            conn.ConnectionString = strConn; //set the connection string

            comm.Connection = conn; //Point the comm towards which connection to use

            //If it is filled in, use it.
            if (myFirst.Length > 0) //use it as criteria if it is filled in
            {
                strSQL += " AND Fname LIKE @FName";
                comm.Parameters.AddWithValue("@FName", "%" + myFirst + "%");
            }

            //If it is filled in, use it.
            if (myLast.Length > 0)  //use it as criteria if its filled in
            {
                strSQL += " AND Lname LIKE @LName";
                comm.Parameters.AddWithValue("@LName", "%" + myLast + "%");
            }

            comm.CommandText = strSQL;  //tell comm what to say

            da.SelectCommand = comm;    //which command object to translate for

            //The data adapter is ready to get the data
            conn.Open();


            da.Fill(ds, "myPatients");


            //Close the connection
            conn.Close();

            //RECOMMEND USING A TRY CATCH

            //Return the data to be shared
            return ds;
        }

        public SqlDataReader FindOnePatient(int intPID)
        {
            //Create and Initialize the DB tools we need to use
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //The Connection String being used
            //Create the who what and where of the DB
            string strConn = MyTools.GetConnected();

            //The SQL Command string to pull up one person's data
            string strSQL = "SELECT PatientID, Fname, Mname, Lname, Address, Address2, City, State, Zip, Phone, AlternatePhone, Email, Gender, Birthdate, Age, MaritalStatus, Race, Ethnicity, Language, Height, Weight, PrimaryCareProvider, InsuranceProvider, WorkStatus, Occupation, Employer, EmployerPhone, School, FieldofStudy, SchoolPhone, EmergencyFname, EmergencyMname, EmergencyLname, Relationship, EmergencyAddress, EmergencyAddress2, EmergencyCity, EmergencyState, EmergencyZip, EmergencyPhone, EmergencyAlternatePhone FROM Patients WHERE PatientID = @PatientID;";

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


        //Method that will update one persons record specified by the ID
        //It will return an integer meant for feedback for how many records were updated
        public Int32 UpdatePatient()
        {
            //Creating a variable to hold the integer of # of records effected
            Int32 intRecords = 0;

            //Create SQL command string
            string strSQL = "UPDATE Patients SET Fname = @Fname, Mname = @Mname, Lname = @Lname, Address = @Address, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Phone = @Phone, AlternatePhone = @AlternatePhone, Email = @Email, Gender = @Gender, Birthdate = @Birthdate, Age = @Age, MaritalStatus = @MaritalStatus, Race = @Race, Ethnicity = @Ethnicity, Language = @Language, Height = @Height, Weight = @Weight, PrimaryCareProvider = @PrimaryCareProvider, InsuranceProvider = @InsuranceProvider, WorkStatus = @WorkStatus, Occupation = @Occupation, Employer = @Employer, EmployerPhone = @EmployerPhone, School = @School, FieldofStudy = @FieldofStudy, SchoolPhone = @SchoolPhone, EmergencyFname = @EmergencyFname, EmergencyMname = @EmergencyMname, EmergencyLname = @EmergencyLname, Relationship = @Relationship, EmergencyAddress = @EmergencyAddress, EmergencyAddress2 = @EmergencyAddress2, EmergencyCity = @EmergencyCity, EmergencyState = @EmergencyState, EmergencyZip = @EmergencyZip, EmergencyPhone = @EmergencyPhone, EmergencyAlternatePhone = @EmergencyAlternatePhone WHERE PatientID = @PatientID;";


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
            comm.Parameters.AddWithValue("@Fname", Fname);
            comm.Parameters.AddWithValue("@Mname", Mname);
            comm.Parameters.AddWithValue("@Lname", Lname);
            comm.Parameters.AddWithValue(@"Address", Address);
            comm.Parameters.AddWithValue(@"Address2", Address2);
            comm.Parameters.AddWithValue(@"City", City);
            comm.Parameters.AddWithValue(@"State", State);
            comm.Parameters.AddWithValue(@"Zip", Zip);
            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"AlternatePhone", AlternatePhone);
            comm.Parameters.AddWithValue(@"Email", Email);
            comm.Parameters.AddWithValue(@"Gender", Gender);
            comm.Parameters.AddWithValue(@"Birthdate", Birthdate.ToString());
            comm.Parameters.AddWithValue(@"Age", Age);
            comm.Parameters.AddWithValue(@"MaritalStatus", MaritalStatus);
            comm.Parameters.AddWithValue(@"Race", Race);
            comm.Parameters.AddWithValue(@"Ethnicity", Ethnicity);
            comm.Parameters.AddWithValue(@"Language", Language);
            comm.Parameters.AddWithValue(@"Height", Height);
            comm.Parameters.AddWithValue(@"Weight", Weight);
            comm.Parameters.AddWithValue(@"PrimaryCareProvider", PrimaryCareProvider);
            comm.Parameters.AddWithValue(@"InsuranceProvider", InsuranceProvider);
            comm.Parameters.AddWithValue(@"WorkStatus", WorkStatus);
            comm.Parameters.AddWithValue(@"Occupation", Occupation);
            comm.Parameters.AddWithValue(@"Employer", Employer);
            comm.Parameters.AddWithValue(@"EmployerPhone", EmployerPhone);
            comm.Parameters.AddWithValue(@"School", School);
            comm.Parameters.AddWithValue(@"FieldofStudy", FieldofStudy);
            comm.Parameters.AddWithValue(@"SchoolPhone", SchoolPhone);
            comm.Parameters.AddWithValue(@"EmergencyFname", EmergencyFname);
            comm.Parameters.AddWithValue(@"EmergencyMname", EmergencyMname);
            comm.Parameters.AddWithValue(@"EmergencyLname", EmergencyLname);
            comm.Parameters.AddWithValue(@"Relationship", Relationship);
            comm.Parameters.AddWithValue(@"EmergencyAddress", EmergencyAddress);
            comm.Parameters.AddWithValue(@"EmergencyAddress2", EmergencyAddress2);
            comm.Parameters.AddWithValue(@"EmergencyCity", EmergencyCity);
            comm.Parameters.AddWithValue(@"EmergencyState", EmergencyState);
            comm.Parameters.AddWithValue(@"EmergencyZip", EmergencyZip);
            comm.Parameters.AddWithValue(@"EmergencyPhone", EmergencyPhone);
            comm.Parameters.AddWithValue(@"EmergencyAlternatePhone", EmergencyAlternatePhone);
            comm.Parameters.AddWithValue("@PatientID", PatientID);

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

    }
}
