using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientRecords
{
    class Validation
    {
        //Validating that the length is greater than 0
        static public bool IsItFilledIn(string temp)
        {
            bool result = false;

            if (temp.Length > 0)
            {
                result = true;
            }

            return result;
        }

        //Validating that the length is greater than or equal to the minimum length set
        static public bool IsItFilledIn(string temp, int minlen)
        {
            bool result = false;

            if (temp.Length >= minlen)
            {
                result = true;
            }
            return result;
        }

        //Validating that the string length is between the minimum and maximum lengths allowed
        static public bool IsWithinRange(string temp, int minlength, int maxlength)
        {
            bool result = false;

            if (temp.Length != minlength && temp.Length != maxlength)
            {
                result = true;
            }
            return result;
        }

        //Validating that the integer length is between the minimum and maximum lengths allowed
        static public bool IsWithinRange(int temp, int minlength, int maxlength)
        {
            bool result = false;

            if (temp < minlength || temp > maxlength)
            {
                result = true;
            }
            return result;
        }

        //Validating that a selected start date is before the selected end date
        static public bool IsValidStartDate(DateTime temp, DateTime start)
        {
            bool result = false;

            if (temp > start)
            {
                result = true;
            }
            return result;
        }

        //Validating the Length based on just a maximum length
        static public bool IsValidLength(string temp, int maxlen)
        {
            bool result = false;

            if (temp.Length < maxlen || temp.Length > maxlen)
            {
                result = true;
            }

            return result;
        }

        //Validating the Email
        static public bool IsValidEmail(string temp)
        {
            //assume it is true, but check to see if something makes it false
            bool result = true;

            //look for the position of "@"
            int atLocation = temp.IndexOf("@");
            int NextatLocation = temp.IndexOf("@", atLocation + 1);

            //look for position of last period
            int periodLocation = temp.LastIndexOf(".");

            //calculations to figure out how many characters are between the last "." and the "@" symbol.
            int calculations = temp.LastIndexOf(".") - temp.IndexOf("@") - 1;

            //check for minimum length
            if (temp.Length < 8)
            {
                result = false;
            }
            else if (atLocation < 2) //making sure there are 2 characters infront of the "@" symbol
            {
                result = false;
            }
            else if (periodLocation + 2 >= (temp.Length)) //making sure there are atleast 2 characters after the period
            {
                result = false;
            }
            else if (calculations < 2) //making sure there are at least 2 characters between the "@" symbol, and the last "."
            {
                result = false;
            }

            return result;
        }
    }
}
