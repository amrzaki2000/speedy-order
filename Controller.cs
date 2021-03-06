﻿using System;
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
            catch (Exception exp)
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
                string query = "select Fname,Lname,Email, PhoneNumber, Address, Salary, WorkingHours, SuperID from CustomerService as c,Subscriber as s " +
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

        //Function to get a specific Product
        public DataTable GetProduct(string id)
        {
            try
            {
                string query = "SELECT * FROM Products WHERE ProductID = " + id + ";";
                return dbMan.ExecuteReader(query);
            }
            catch
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }

        //                 _--------------------------Hannah 8Jan
        public DataTable GetSellerID(string username)         //Function returning a table carrying the information of a Seller
        {
            try
            {
                string query = "select SellerID from Subscriber where Username='" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }
        public DataTable GetCustomerID(string username)         //Function returning a table carrying the information of a Seller
        {
            try
            {
                string query = "select CustomerID from Subscriber where Username='" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }
        }
        public DataTable GetAllsellerProd(string sellerID)         //Function returning a table carrying the information of a Seller
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

        public DataTable SelectOrder(string OrderID)
        {
            try
            {
                string query = "SELECT OrderID,DateCreated, TotalOrderPrice, ShippingPrice,OrderStatus, [DateDelivered ] as Datedelivered, CustomerID FROM Orders WHERE OrderID='" + OrderID + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }
        public DataTable SelectAllOrders()
        {
            try
            {
                string query = "SELECT OrderID,DateCreated, TotalOrderPrice, ShippingPrice,OrderStatus, [DateDelivered ] as Datedelivered, CustomerID FROM Orders;";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }
        public DataTable SelectCustomer(string username)
        {
            try
            {
                string query = "SELECT Customers.CustomerID,Fname,Lname,Email,PhoneNumber,Address,Points FROM Customers,Subscriber WHERE Customers.CustomerID=Subscriber.CustomerID AND Username='" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }
        public DataTable SelectAllCustomers()
        {
            try
            {
                string query = "SELECT * FROM Customers ;";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }

        public DataTable SelectSeller(string username)
        {
            try
            {
                string query = "SELECT Sellers.SellerID,Fname,Lname,Email,PhoneNumber,Address,Rating,Profit,Income FROM Sellers,Subscriber WHERE Sellers.SellerID=Subscriber.SellerID AND Username='" + username + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }
        public DataTable SelectAllSeller()
        {
            try
            {
                string query = "SELECT * FROM Sellers ;";
                return dbMan.ExecuteReader(query);

            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }

        public DataTable SelectAllProducts()
        {
            try
            {
                string query = "SELECT * FROM PRODUCTS;";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }
        }

       
        public DataTable SelectAllinCartProd()
        {
            try
            {
                string query = "SELECT * FROM Incart  ;";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }
        }

        public DataTable getPromo(string promo)
        {
            try
            {
                string query = "Select CustomerID,p.PromoID,DiscountPrecentage, isused from promocodes as p, usedpromocodes as u " +
                    " where u.promoid = '" + promo + "'  and p.promoid = '" + promo + "' ;";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }
        }

        public DataTable UseCustomerPromo(string promoid,string customerid)
        {
            try
            {
                string query = "Update UsedPromoCodes set isused = 'true' where customerid = " + customerid + " and promoid = '" + promoid + "' ;";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }
        }

        public DataTable SelectCustomerCart(string customer)
        {
            try
            {
                string query = "SELECT * FROM Incart where customerid = "+customer+" ;";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }
        }


        public DataTable getCustomertotalprice(string customerid)
        {
            try
            {
                string query = "select Sum(price*quantity) from incart group by customerid having customerid = " + customerid + ";";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                return null;
            }

        }

        public DataTable getCustomerpoints(string customerid)
        {
            try
            {
                string query = "select Sum((price*quantity)/5) from incart group by customerid having customerid = " + customerid + ";";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                return null;
            }

        }

        public DataTable SelectCustomerBoughtProducts(string customerid)
        {
            try
            {
                string query = "Select o.OrderID, p.ProductID,ProductName,Category,Size,Price,Rating,os.quantity,prodImg from Orders as o, Products as p, OrderContent as os" +
                    " where o.orderid = os.orderid and p.productid = os.productid and o.customerid = " + customerid + " ;";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                return null;
            }
        }

        public DataTable SelectPendingReturned()
        {
            try
            {
                string query = "SELECT * from Returned WHERE status = 'pending' ;";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                return null;
            }
        }

        public DataTable SelectAllReturnedProducts()
        {
            try
            {
                string query = "SELECT* FROM Returned";
                return dbMan.ExecuteReader(query);
            }

            catch (Exception exp)
            {
                return null;
            }

        }

        public DataTable SelectQualityStatusProducts(string status)
        {
            try
            {
                string query = "SELECT* FROM Products WHERE QualityStatus = '"+status+"' ";
                return dbMan.ExecuteReader(query);
            }

            catch (Exception exp)
            {
                return null;
            }

        }

        public DataTable SelectAllWarehousesProducts()
        {
            try
            {
                string query = "SELECT* FROM WarehouseProducts;";
                return dbMan.ExecuteReader(query);
            }

            catch (Exception exp)
            {
                return null;
            }

        }


        public int GrantPromo(string promoid, string customerid)
        {
            try
            {
                string query = "Insert into UsedPromoCodes values('"+promoid+"',"+customerid+", 'false');";
                return dbMan.ExecuteNonQuery(query);
            }

            catch (Exception exp)
            {
                return 0;
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

        public int InsertComplaint(string order, string product, string customer,string status,string des)
        {
            try
            {
                string query = "Insert into Complaints values( "+order+", "+product+","+customer+", null, '"+status+"', '"+des+"',null );";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception exp)
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
        public int InsertCustomerService(string fname, string lname, string phone, string address, string email, string salary, string workinghours, string superid)
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

        //Function for adding new product by a seller
        public int InsertProd(string name, string descp, string color, string category, string size, string price, string rating, string quantity, string qadmin, string status, string sellerID, string prodimg)
        {
            try
            {
                string query = "Insert into Products values ('" + name + "','" + descp + "','" + color + "','" + category + "','" + size + "'," +
                    " " + price + ", " + rating + "," + quantity + "," + qadmin + ", '" + status + "', " + sellerID + ",'" + prodimg + "');";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }
        public int InsertAppeal(string Appeal, string username)
        {
            try
            {
                string query = "UPDATE Banned SET AppealDescription='" + Appeal + "' WHERE Bannedsub='" + username + "';";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return 0;
            }

        }


        /////Function Add Promocode////////
        public int AddPromocode(string promoid, string discountprecent)
        {
            try
            {
                string StoredProc = StoredProcs.AddPromocode;
                Dictionary<string, object> Params = new Dictionary<string, object>();
                Params.Add("@promoid", promoid);
                Params.Add("@discountprecent", discountprecent);
                return dbMan.ExecuteNonQuery(StoredProc, Params);
            }
            catch(Exception exp)
            {
                return 0;
            }
        }


        //Function Add product to cart
        public int AddtoCart(string customerid, string productid,string quantity, string prodimg, string price)
        {
            try
            {
                string query = "Insert into Incart values(" + customerid + ", " + productid + ", " + quantity + ", '"+prodimg+"', "+price+" );";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        //Function for inserting a review of a product
        public int AddReview(string customerID, string productID,string rating,string descp)
        {
            try
            {
                string query = "Insert into productreviews values(" + customerID + ", " + productID + "," + rating + ",'" + descp + "');";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception exp)
            {
                return 0;
            }
        }


        public int InsertOrder(string DateCreated, string TotalOrderPrice, string ShippingPrice, string OrderStatus, string DateDelivered, string CustomerID)
        {
            try
            {
                string query = "INSERT INTO Orders (DateCreated,TotalOrderPrice,ShippingPrice,OrderStatus,[DateDelivered ],CustomerID) Values ('" + DateCreated + "'," + TotalOrderPrice + "," + ShippingPrice + ",'" + OrderStatus + "','" + DateDelivered + "'," + CustomerID + ");";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception exp)
            {
                return 0;
            }

        }

        public int InsertOrderContent(string ProductID, string Quantity)
        {
            try
            {
                string query = "INSERT INTO [OrderContent ](OrderID,ProductID,[Quantity ]) Values (IDENT_Current('orders')," + ProductID + "," + Quantity + ");";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception exp)
            {
                return 0;
            }

        }

        public int InsertinReturned(string productID, string customerID, string reason)
        {
            try
            {
                string query = "INSERT into Returned values('" + customerID + "','" + productID + "','" + reason + "',Pending);";
                return dbMan.ExecuteNonQuery(query);
            }
            catch
            {
                return 0;
            }
        }


        /*************************************************************************************************/

        /******************** Updating Functions **************************************/

        //Function for updating seller profile

        public int UpdateSeller(string username, string fname, string lname, string bdate, string phone, string address)
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
                string query = "Update Subscriber set Password = '" + newpass + "' where username = '" + username + "' ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }
        public int UpdateCustomer(string Fname, string Lname, int phoneNumber, string Address, string UserName, string Password)
        {
            try
            {
                string query = "UPDATE Customers SET Fname='" + Fname + "', Lname='" + Lname + "', PhoneNumber=" + phoneNumber + ", Address='" + Address + "'WHERE Customers.CustomerID in (SELECT CustomerID FROM Subscriber WHERE Username='" + UserName + "'AND Password='" + Password + "');";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return 0;
            }

        }
        public int UpdateCustomerPassword(string UserName, string newPassword)
        {
            try
            {
                string query = "UPDATE Subscriber SET Password='" + newPassword + "'WHERE Username='" + UserName + "';";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return 0;
            }

        }

        public int UpdateProd(string name, string descp, string color, string category, string size, string price, string quantity, string ProductID, string prodimg)
        {
            try
            {
                string query = "Update Products set ProductName = '" + name + "', Description = '" + descp + "' , color = '" + color + "', category = '" + category + "'  " +
                    " , size = '" + size + "' , price = " + price + " , quantity = " + quantity + ", prodImg = '" + prodimg + "' where ProductID = " + ProductID + " ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        public int updatecustomerpoints(string points, string customerid)
        {
            try
            {
                string query = "Update Customers set Points='" + points + "' where CustomerID='" + customerid + "' ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }


        public int UpdateProductQ(string productID, string quantity)
        {
            try
            {
                string query = "Update Products set quantity=quantity-" + quantity + " where ProductID=" + productID + " ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch
            {
                return 0;
            }
        }

        public int updateprofitandincome(string productid, string income, string profit)
        {
            try
            {
                string query = "Update sellers set Income=Income+" + income + ", profit=profit+" + profit + "  where sellerid in  ( select seller from products where ProductID = " + productid + " );";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }

        }

        public int UpdateWarehouseQ(string productID,string quantity)
        {
            try
            {
                string query = "update WarehouseProducts set QuantityinWarehouse = QuantityinWarehouse - "+quantity+" where productID = ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }

        }

        public int setOutofStock(string productID)
        {
            try
            {
                string query = "update products set QualityStatus = 'Out of Stock'  where productID = "+productID+" ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }

        }
        public int BannSeller(int BanningAdmin, string BannedSub, string ReasonOfSusbension)
        {
            try
            {
                string query = "INSERT INTO Banned (BanningAdmin, BannedSub, ReasonOfSusbension, AppealStatus,AppealDescription) Values (" + BanningAdmin + ",'" + BannedSub + "','" + ReasonOfSusbension + "',null,null);";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return 0;
            }

        }

        public DataTable SelectAllBannedSellers()
        {
            try
            {
                //string query = "SELECT *FROM Banned ;";
                string query = "SELECT BanningAdmin, BannedSub, ReasonOfSusbension, AppealStatus,AppealDescription FROM Banned,Subscriber WHERE BannedSub = UserName AND UserType = 'Seller'";

                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }
        public DataTable SelectAllBannedCustomers()
        {
            try
            {
                //string query = "SELECT *FROM Banned ;";
                string query = "SELECT BanningAdmin, BannedSub, ReasonOfSusbension, AppealStatus,AppealDescription FROM Banned,Subscriber WHERE BannedSub = UserName AND UserType = 'Customer'";

                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return null;
            }

        }
        public int UnBannSeller(string SellerUser)
        {
            try
            {
                string query = "DELETE FROM Banned WHERE BannedSub='" + SellerUser + "' ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return 0;
            }

        }


        // Delete product
        public int DeleteProd(string id)
        {
            try
            {
                string query = "Delete from Products where ProductID = " + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            catch
            {
                Console.WriteLine("There was a problem accessing the database");
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

        public int UpdatesubsAdmin(string username, string pass)
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

        public DataTable AVG_AllProductReviews(string id)
        {
            try
            {
                string query = "Select AVG(Rating) from ProductReviews where ProductID = " + id + " ;";
                return dbMan.ExecuteReader(query);
            }
            catch(Exception exp)
            {
                return null;
            }
        }

        public int UpdateProductRating(string id, string rating)
        {
            try
            {
                string query = "Update Products set rating =" + rating + " where productid = " + id + ";";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception exp)
            {
                return 0;
            }
        }

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
            string query = "select AdminID from Subscriber where Username='" + username + "' ;";
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

        public int ComplaintReply(string response, string complaintID, string employeeid)
        {
            try
            {
                string query = "UPDATE Complaints  SET [Respond]='" + response + "',[Status]='Replied' ,EmployeeID='" + employeeid + "' WHERE [ComplaintID]='" + complaintID + "';";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeletefromCart(string productid, string customerid)
        {
            try
            {
                string query = "DELETE FROM Incart WHERE PRODUCTID = " + productid + " and CUSTOMERID = " + customerid + " ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch(Exception exp)
            {
                return 0;
            }
        }

        public int clearCustomerCart(string customerid)
        {
            try
            {
                string query = "DELETE FROM Incart WHERE CustomerID = " + customerid + ";";
                return dbMan.ExecuteNonQuery(query); 
            }
            catch(Exception exp)
            {
                return 0;
            }
        }


        //===================================================================Product Inventory
       
        public DataTable getquantityofProductofwarehouses(string productid)
        {
            
            string query0 = "select * from WarehouseProducts where ProductID='" + productid + "' ;  ";
            DataTable dt= dbMan.ExecuteReader(query0);
            if (dt == null)
            {
                return dt;
            }
            else
            {
                string query = "Select sum(QuantityinWarehouse) FROM WarehouseProducts where ProductID='" + productid + "';";
                return dbMan.ExecuteReader(query);
            }
        }


        public DataTable getquantityofproduct(string productid)
        {
            string query = "select quantity from Products where ProductID='" + productid + "' ;";
            return dbMan.ExecuteReader(query);
        }

        public int insertproductinwarehouse(string productid, string warehouseid, string quantity)
        {
            try
            {
                string query = "insert into WarehouseProducts (WarehouseID,ProductID,QuantityinWarehouse) values('" + warehouseid + "','" + productid + "','" + quantity + "' );";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable checkforproductidExcistance(string productid)
        {
            string query = "select * from Products WHERE ProductID='" + productid + "'  ;";
            return dbMan.ExecuteReader(query);

        }

        public DataTable checkforwarehouseExcistance(string warehouseid)
        {
            string query = "select * from Warehouse WHERE WarehouseID='" + warehouseid + "'  ;";
            return dbMan.ExecuteReader(query);

        }

        public int Insertwarehouse(string warehousename, string warehouselocation)
        {
            try
            {
                string query = "INSERT into Warehouse(WarehouseName,WarehouseLocation) " +
                    "values('" + warehousename + "','" + warehouselocation + "');";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }
        public DataTable getquantityofProductofwarehouse(string productid, string warehouseid)
        {
            try
            {
                string query = "Select QuantityinWarehouse FROM WarehouseProducts where ProductID='" + productid + "'and WarehouseID='" + warehouseid + "';";
                return dbMan.ExecuteReader(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Couldn't Connect to database");
                return null;
            }

        }
        public int UpdateQualityStatus(string prodid, string newStatus, string adminid)
        {
            try
            {
                string query = "Update Products set QualityStatus = '" + newStatus + "' , Quality_Control_Admin='"+adminid+"' where ProductID = '" + prodid + "' ;";
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        public DataTable checkforComplaintIDexistance(string complaintID)            //Function to check if login credintials are right
        {
            string query = "select * from Complaints WHERE ComplaintID='" + complaintID + "'  ;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable checkreturnProductExistence(string customerID, string productID)            //Function to check if login credintials are right
        {
            string query = "select * from Returned WHERE CustomerID='" + customerID + "' and ProductID='" + productID + "' ;";
            return dbMan.ExecuteReader(query);
        }
        public int ReturnProduct(string customerID, string prodID)
        {
            try
            {
                string query = "UPDATE Returned SET Status= 'Returned' WHERE ProductID='" + prodID + "' and CustomerID='" + customerID + "' ;";
                string query2 = "UPDATE Products SET quantity= (quantity+1) WHERE ProductID='" + prodID + "' ;";
                dbMan.ExecuteNonQuery(query2);
                return dbMan.ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a problem with the database");
                return 0;
            }

        }


        /////////////////////////////////////////////// Statistical queries //////////////////////////////////////////////////////

        public DataTable TotalIncome()
        {

            try
            {
                string query = "Select SUM(TotalOrderPrice) from Orders";

                return dbMan.ExecuteReader(query);
            }
            catch
            {
                return null;
            }
        }
        public DataTable NumEmployees()
        {
            string query = "Select COUNT(Username) from Subscriber where UserType='Seller' OR UserType='Customer'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumSellers()
        {
            string query = "Select COUNT(Fname) from Sellers";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumCustomers()
        {
            string query = "Select COUNT(Fname) from Sellers";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumProducts()
        {
            string query = "Select COUNT(ProductID) from Products";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumQuantity()
        {
            string query = "Select SUM(quantity) from Products";
            return dbMan.ExecuteReader(query);
        }
        public DataTable TotalSalaries()
        {
            string query = "Select SUM(Salary) from CustomerService UNION Select SUM(Salary) from Admins";
            return dbMan.ExecuteReader(query);
        }

        public DataTable NumOrders()
        {
            string query = "Select COUNT(OrderID) from Orders";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumReturns()
        {
            string query = "Select COUNT(CustomerID) from Returned";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumPromo()
        {
            string query = "Select COUNT(PromoID) from PromoCodes";
            return dbMan.ExecuteReader(query);
        }
        public DataTable NumPromosUsed()
        {
            string query = "Select COUNT(PromoID) from UsedPromoCodes";
            return dbMan.ExecuteReader(query);
        }
        public DataTable TotalBans()
        {
            string query = "Select COUNT(BanningAdminID) from Banned";
            return dbMan.ExecuteReader(query);
        }
    }



}

///


