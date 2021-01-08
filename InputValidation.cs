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

    }
}