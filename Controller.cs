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

        //Function to insert a user in subscriber table
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
        //                 _--------------------------Hannah 8Jan
        public DataTable GetSellerID(string username)         //Function returning a table carrying the information of a Seller
        {
            try
            {
                string query = "select SellerID from Subscriber where Username='"+ username +"';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }

        public DataTable GetAllsellerProd(int sellerID )         //Function returning a table carrying the information of a Seller
        {
            try
            {
                string query = "select * from Products where Seller= " + sellerID + ";";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }

        //-----------------------------Abdelrahmannn------------------------
        public int UpdateCustomer(string Fname, string Lname, int phoneNumber, string Address, string UserName, string Password)
        {
            string query = "UPDATE Customers SET Fname='" + Fname + "', Lname='" + Lname + "', PhoneNumber=" + phoneNumber + ", Address='" + Address + "'WHERE Customers.CustomerID in (SELECT CustomerID FROM Subscriber WHERE Username='" + UserName + "'AND Password='" + Password + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateCustomerPassword(string UserName, string newPassword)
        {
            string query = "UPDATE Subscriber SET Password='" + newPassword + "'WHERE Username='" + UserName + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int InsertAppeal(string Appeal, string username)
        {
            string query = "UPDATE Banned SET AppealDescription='" + Appeal + "' WHERE Bannedsub='" + username + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectSeller(string username)
        {
            string query = "SELECT Sellers.SellerID,Fname,Lname,Email,PhoneNumber,Address,Rating,Profit,Income FROM Sellers,Subscriber WHERE Sellers.SellerID=Subscriber.SellerID AND Username='" + username + "';";
            return dbMan.ExecuteReader(query);

        }
        public DataTable SelectAllSeller()
        {
            string query = "SELECT * FROM Sellers ;";
            return dbMan.ExecuteReader(query);
        }
        public int BannSeller(int BanningAdmin, string BannedSub, string ReasonOfSusbension)
        {
            string query = "INSERT INTO Banned (BanningAdmin, BannedSub, ReasonOfSusbension, AppealStatus,AppealDescription) Values (" + BanningAdmin + ",'" + BannedSub + "','" + ReasonOfSusbension + "',null,null);";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectAllBannedSellers()
        {
            //string query = "SELECT *FROM Banned ;";
            string query = "SELECT BanningAdmin, BannedSub, ReasonOfSusbension AppealStatus,AppealDescription FROM Banned,Subscriber WHERE BannedSub = UserName AND UserType = 'Seller'";

            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectAllBannedCustomers()
        {
            //string query = "SELECT *FROM Banned ;";
            string query = "SELECT BanningAdmin, BannedSub, ReasonOfSusbension AppealStatus,AppealDescription FROM Banned,Subscriber WHERE BannedSub = UserName AND UserType = 'Customer'";

            return dbMan.ExecuteReader(query);
        }
        public int UnBannSeller(string SellerUser)
        {
            string query = "DELETE FROM Banned WHERE BannedSub='" + SellerUser + "' ;";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable SelectOrder(string OrderID)
        {
            string query = "SELECT * FROM Orders WHERE OrderID='" + OrderID + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectAllOrders()
        {
            string query = "SELECT * FROM Orders;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectCustomer(string username)
        {
            string query = "SELECT Customers.CustomerID,Fname,Lname,Email,PhoneNumber,Address,Points FROM Customers,Subscriber WHERE Customers.CustomerID=Subscriber.CustomerID AND Username='" + username + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectAllCustomers()
        {
            string query = "SELECT * FROM Customers ;";
            return dbMan.ExecuteReader(query);
        }

    }
}