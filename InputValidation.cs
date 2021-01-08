using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DatabaseProject
{
    public class InputValidation
    {
        Controller controlObj;

        public InputValidation()
        {
            controlObj = new Controller();
        }

        //Function to check if username already exists
        public bool CheckifUserExists(string username)
        {
            DataTable dt = controlObj.Getusername(username); //Get subscribers with passed username in a table

            if (dt == null || dt.Rows.Count < 1 ) // Checks the number of rows
            {
                return false;
            }
            else
                return true;
        }

        //Function to check if an email is previously registered
        public bool CheckifemailExists(string email, string type)
        {
            DataTable dt = controlObj.Getemail(email,type); //Get subscribers with passed email in a table

            if (dt == null || dt.Rows.Count < 1) // Checks the number of rows
            {
                return false;
            }
            else
                return true;
        }

        //Function to check for any blank inputs
        public bool Checkblank(params string[] values)
        {
            foreach(string value in values)
            {
                if (value.Length == 0)
                    return true;
            }

            return false;
        }

    }
}