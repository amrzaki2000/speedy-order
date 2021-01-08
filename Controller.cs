using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseProject
{

    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();

        }

        public DataTable Getemail(string email, string type)
        {
            try
            {
                string query = "SELECT EMAIL FROM " + type + " WHERE EMAIL = '" + email + "';";
                return dbMan.ExecuteReader(query);

            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }

        }
        public DataTable userLogin(string userName, string password)
        {
            string query = "select * from Subscriber WHERE Username='" + userName + "' and Password=" + password + " ;";


            return dbMan.ExecuteReader(query);
        }
        public DataTable adminLogin(string userName, string password)
        {
            string query = "select * from Subscriber WHERE Username='" + userName + "' and Password=" + password + " ;";

            return dbMan.ExecuteReader(query);
        }
        public DataTable Getusername(string username)
        {
            try
            {
                string query = "SELECT * from Subscriber where username = '" + username + "' ;";
                return dbMan.ExecuteReader(query);

            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }

        }

        //************************* Insertion functions *********************************************//
        public int InsertCustomer(string email, string first, string last, string phone, string address, string birth)
        {
            try
            {
                string StoredProc = StoredProcs.customerSignup;
                Dictionary<string, object> Params = new Dictionary<string, object>();   //Getting stored proc name

                // Adding procedures parameters //
                Params.Add("@Fname", first);
                Params.Add("@Lname", last);
                Params.Add("@Email", email);
                Params.Add("@PhoneNumber", phone);
                Params.Add("@address", address);
                Params.Add("@birthdate", birth);

                return dbMan.ExecuteNonQuery(StoredProc, Params); //Executing query



            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        public int InsertSeller(string email, string first, string last, string phone, string address, string birth)
        {
            try
            {
                string StoredProc = StoredProcs.sellerSignup;
                Dictionary<string, object> Params = new Dictionary<string, object>();   //Getting stored proc name

                // Adding procedures parameters //
                Params.Add("@Fname", first);
                Params.Add("@Lname", last);
                Params.Add("@Email", email);
                Params.Add("@PhoneNumber", phone);
                Params.Add("@address", address);
                Params.Add("@birthdate", birth);

                return dbMan.ExecuteNonQuery(StoredProc, Params); //Executing query
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        public int InsertSub(string username, string pass, string adminID, string customerID, string employeeID, string sellerID, string usertype)
        {
            try
            {
                string query = "INSERT into Subscriber(Username,Password,CustomerID,AdminID,SellerID,EmployeeID,UserType) " +
                    "values('" + username + "','" + pass + "',IDENT_CURRENT('" + customerID + "'),IDENT_CURRENT('" + adminID + "'),IDENT_CURRENT('" + sellerID + "'),IDENT_CURRENT('" + employeeID + "'),'" + usertype + "');";

                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }







        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }
}