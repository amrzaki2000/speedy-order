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


        ///////******************* Database Retrival Functions ********************************//////////////////
        public DataTable Getemail(string email, string type)
        {
            try
            {
                string query = "SELECT EMAIL FROM " + type + " WHERE EMAIL = '" + email + "';"; // Getting the email of a user from the database
                return dbMan.ExecuteReader(query);

            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }

        }
        public DataTable userLogin(string userName, string password)            //Function to check if login credintials are right
        {
            string query = "select * from Subscriber WHERE Username='" + userName + "' and Password='" + password + "' ;";
            return dbMan.ExecuteReader(query);
        }
 
        public DataTable Getusername(string username)           //Function to get the username of a user
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

        public DataTable GetCustomerInfo(string username)       //Function returning a table carrying the information of a Customer
        {
            try
            {
                string query = "select Fname,Lname,Email,BirthDate, PhoneNumber, Address, Points from Customers as c,Subscriber as s " +
                    " where c.CustomerID = s.CustomerID and s.Username = '" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }

        public DataTable GetSellerInfo(string username)         //Function returning a table carrying the information of a Seller
        {
            try
            {
                string query = "select Fname,Lname,Email,BirthDate, PhoneNumber, Address, Rating, Profit, Income from Sellers as c,Subscriber as s " +
                    " where c.SellerID = s.SellerID and s.Username = '" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }
        public DataTable GetAdminInfo(string username)              //Function returning a table carrying the information of an Admin
        {
            try
            {
                string query = "select Fname,Lname,Email,BirthDate, PhoneNumber, Address, Salary from Admins as c,Subscriber as s " +
                    " where c.AdminID = s.AdminID and s.Username = '" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }

        public DataTable GetEmployeeInfo(string username)           //Function returning a table carrying the information of an Employee
        {
            try
            {
                string query = "select Fname,Lname,Email,BirthDate, PhoneNumber, Address, Salary, WorkingHours, SuperID from Admins as c,Subscriber as s " +
                    " where c.EmployeeID = s.EmployeeID and s.Username = '" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }


        //Function to return User Banning Information
        public DataTable getBanned(string username)
        {
            try
            {
                string query = "SELECT * FROM BANNED WHERE BannedSub = '" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }
        //************************* Insertion functions *********************************************//
        
        // Function for inserting a Customer
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

        //Function for inserting a Seller
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

        ///Insert Admin/////
        public int InsertAdmin(string fname, string lname, string phone, string address, string email, string salary)
        {
            try
            {
                string StoredProc = StoredProcs.InsertAdmin;
                Dictionary<string, object> Params = new Dictionary<string, object>();   //Getting stored proc name

                // Adding procedures parameters //
                Params.Add("@Fname", fname);
                Params.Add("@Lname", lname);
                Params.Add("@Email", email);
                Params.Add("@PhoneNumber", phone);
                Params.Add("@address", address);
                Params.Add("@salary", salary);

                return dbMan.ExecuteNonQuery(StoredProc, Params); //Executing query
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        ////////Insert Customer Service////////
        public int InsertCustomerService(string fname, string lname, string phone, string address, string email, string salary,string workinghours,string superid)
        {
            try
            {
                string StoredProc = StoredProcs.InsertCustomerService;
                Dictionary<string, object> Params = new Dictionary<string, object>();   //Getting stored proc name

                // Adding procedures parameters //
                Params.Add("@Fname", fname);
                Params.Add("@Lname", lname);
                Params.Add("@PhoneNumber", phone);
                Params.Add("@address", address);
                Params.Add("@Email", email);
                Params.Add("@workinghours", workinghours);
                Params.Add("@superid", superid);
                Params.Add("@salary", salary);

                return dbMan.ExecuteNonQuery(StoredProc, Params); //Executing query
            }
            catch (Exception exp)
            {
                return 0;
            }
        }




        //Function to insert a user in subscriber table
        public int InsertSub(string username, string pass, string adminID, string customerID, string sellerID, string employeeID, string usertype)
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



        /////Function Add Promocode////////
        public int AddPromocode(string promoid,string discountprecent)
        {
            try
            {
                string StoredProc = StoredProcs.AddPromocode;
                Dictionary<string, object> Params = new Dictionary<string, object>();
                Params.Add("@promoid", promoid);
                Params.Add("@discountprecent", discountprecent);
                return dbMan.ExecuteNonQuery(StoredProc, Params);
            }
            catch
            {
                return 0;
            }
        }




        /*************************************************************************************************/

        /******************** Updating Functions **************************************/

        //Function for updating seller profile

        public int UpdateSeller(string username, string fname, string lname,string bdate, string phone, string address)
        {
            try
            {
                string query = "Update Sellers Set Fname = '" + fname + "', Lname = '" + lname + "' , PhoneNumber = " + phone + ", " +
                    " BirthDate = '" + bdate + "', address = '" + address + "' where SellerID in (select SellerID from subscriber where username = '" + username + "') ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        public int UpdatePassword(string username, string newpass)
        {
            try
            {
                string query = "Update Subscriber set Password = '"+newpass+"' where username = '"+username+"' ;";
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

        public int UpdateAdmin(string username, string fname, string lname, string phone, string address)
        {
            try
            {
                string StoredProc = StoredProcs.updateadmin;
                Dictionary<string, object> Params = new Dictionary<string, object>();   //Getting stored proc name

                // Adding procedures parameters //
                Params.Add("@username", username);
                Params.Add("@Fname", fname);
                Params.Add("@Lname", lname);
                Params.Add("@PhoneNumber", phone);
                Params.Add("@Address", address);

                return dbMan.ExecuteNonQuery(StoredProc, Params); //Executing query
            }
            catch (Exception exp)
            {
                return 0;

            }
        }

        public int UpdatesubsAdmin(string username,string pass)
        {
            try
            {
                string StoredProc = StoredProcs.updatesubsAdmin;
                Dictionary<string, object> Params = new Dictionary<string, object>();   //Getting stored proc name

                // Adding procedures parameters //
                Params.Add("@username", username);
                Params.Add("@newpassword", pass);
               

                return dbMan.ExecuteNonQuery(StoredProc, Params); //Executing query
            }
            catch (Exception exp)
            {
                return 0;

            }
        }
        ///////Update customer service//////////
        public int UpdateCustomerService(string Fname, string Lname, string phoneNumber, string Address, string UserName)
        {
            string query = "UPDATE CustomerService SET Fname='" + Fname + "', Lname='" + Lname + "', PhoneNumber=" + phoneNumber + ", [Address]='" + Address + "' WHERE CustomerService.EmployeeID in (SELECT EmployeeID FROM Subscriber WHERE Username='" + UserName + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateCustomerServicePassword(string UserName, string newPassword)
        {
            string query = "UPDATE Subscriber SET Password='" + newPassword + "'WHERE Username='" + UserName + "';";
            return dbMan.ExecuteNonQuery(query);
        }
         ////update promocode/////
            public int RemovePromocode(string promoid)
        {
            try
            {
                string StoredProc = StoredProcs.RemovePromocode;
                Dictionary<string, object> Params = new Dictionary<string, object>();
                Params.Add("@promoid", promoid);
                return dbMan.ExecuteNonQuery(StoredProc, Params);
            }
            catch
            {
                return 0;
            }
        }


        //*************Removing functions////////////////
        public int UpdarePromocode(string promoid, string discountprecent)
        {
            try
            {
                string StoredProc = StoredProcs.UpdatePromocode;
                Dictionary<string, object> Params = new Dictionary<string, object>();
                Params.Add("@promoid", promoid);
                Params.Add("@discountprecent", discountprecent);
                return dbMan.ExecuteNonQuery(StoredProc, Params);
            }
            catch
            {
                return 0;
            }
        }



        public DataTable getpassfromusername(string username)
        {

            string StoredProc = StoredProcs.getpassfromusername;
            Dictionary<string, object> Params = new Dictionary<string, object>();
            Params.Add("@username", username);
            return dbMan.ExecuteReader(StoredProc, Params);

        }
        public DataTable checkforusernameexistance(string userName)            //Function to check if login credintials are right
        {
            string query = "select * from Subscriber WHERE Username='" + userName + "'  ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable checkforCustomeridexistance(string customerid)            //Function to check if login credintials are right
        {
            string query = "select * from Customers WHERE CustomerID='" + customerid + "'  ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable checkforOrderIDexistance(string Orderid)            //Function to check if login credintials are right
        {
            string query = "select * from Orders WHERE OrderID='" + Orderid + "'  ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable checkforadminunexistance(string userName)            //Function to check if login credintials are right
        {
            string query = "select * from Subscriber WHERE UserType='Admin' and  Username='" + userName + "'  ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAdminIDfromUsername(string username)
        {
            string query="select AdminID from Subscriber where Username='" + username + "' ;";
                 return dbMan.ExecuteReader(query);
        }


        public DataTable SelectAllComplaints()
        {
            string query = "SELECT *FROM [Complaints ] ;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectPendingComplaints()
        {
            string query = "SELECT *FROM [Complaints ] WHERE Status='pending' ;";
            return dbMan.ExecuteReader(query);
        }

        public int ComplaintReply(string resbond, string orderid, string ID,string employeeid)
        {
            try
            {
                string query = "UPDATE Complaints  SET [Respond]='" + resbond + "',[Status]='Replied' ,EmployeeID='"+employeeid+"' WHERE [OrderID]='" + orderid + "' AND CustomerID='" + ID + "';";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
















    }
}