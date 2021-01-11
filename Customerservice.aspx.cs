using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseProject
{
    public partial class Customerservice : System.Web.UI.Page
    {

        Controller controllerObj;
        InputValidation val;
        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            val = new InputValidation();
            if (Session["EmployeeID"] == null)
            {
                Response.Write("<script>alert('Please Log in First')</script>");    //In case of inactive session, redirect the user to log-in page 
                Response.Redirect("adminlogin.aspx");                              // Redirect to employee login page
            }
            else
            {
                DataTable dt = controllerObj.GetEmployeeInfo(Session["username"].ToString());   //Get the logged in employee info
                if ( !Page.IsPostBack)
                {
                    // Set the information of the customer profile to their current Status


                    TextBox12.Text = dt.Rows[0][0].ToString();
                    TextBox13.Text = dt.Rows[0][1].ToString();
                    TextBox14.Text = dt.Rows[0][3].ToString();
                    TextBox15.Text = dt.Rows[0][4].ToString();
                    GridView1.DataBind();

                }
            }


        }

        // Function used to update the information of a customer service employee
        protected void UpdateCustomerservice()
        {
            //Intialize our variables
            string username = TextBox17.Text.Trim();
            string fname = TextBox12.Text.Trim();
            string lname = TextBox13.Text.Trim();
            string phonenumber = TextBox14.Text.Trim();
            string address = TextBox15.Text.Trim();
            string oldpass = TextBox18.Text.Trim();
            string newpass = TextBox19.Text.Trim();
            DataTable dt = controllerObj.checkforusernameexistance(username);
      
            
            //Validate employee inputs
            if (username.Length == 0 || fname.Length == 0 || lname.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || oldpass.Length == 0 || newpass.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if( Int64.Parse(phonenumber) < 0)
                Response.Write("<script>alert('Please enter a valid 10 numbers phone number')</script>");
            else if (dt == null)
                Response.Write("<script>alert('Username incorrect')</script>");
            else if ( Session["username"].ToString() != username ||  oldpass != Session["Password"].ToString())
                Response.Write("<script>alert('Login credentials are incorrect')</script>");
            else
            {
                int result;
                int result2;

                result = controllerObj.UpdateCustomerService(fname,lname,phonenumber,address,username);
                if (result != 0)
                {
                    result2 = controllerObj.UpdateCustomerServicePassword(username, newpass);
                    if (result2 == 0)
                        Response.Write("<script>alert('updating process was interrupted')</script>");
                    else
                    {
                        Session["Password"] = newpass;
                        Response.Write("<script>alert('updating process succeeded')</script>");
                        Response.Redirect("customerservice.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('updating process was interrupted')</script>");
                }

            }
        }




        //Updating the employee info on button click event
        protected void Button15_Click(object sender, EventArgs e)
        {
            UpdateCustomerservice();
        }


        //Selecting all complaints in the database on button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = controllerObj.SelectAllComplaints();                               //Update the data source of the gridview
            GridView1.DataBind();                                                                   //Refresh the gridview

        }

        //Selecting Pending complaints in the database on button click event

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = controllerObj.SelectPendingComplaints();                                 //Update the data source of the gridview
            GridView1.DataBind();                                                                           //Refresh the gridview
        }


        //Function to reply to a complaint
        protected void customerserviceReply()
        {
            string complaintID = TextBox2.Text.Trim();          //Our customerID
            string Reply = TextBox1.Text.Trim();                //Our Reply
            DataTable dt = controllerObj.checkforComplaintIDexistance(complaintID);     //Select the required complaint in a datatable 
            if (val.Checkblank(complaintID,Reply))
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");  
            }
            else if (dt == null)                                                               //In case the datatable does not exist
                Response.Write("<script>alert('Customer ID does not exist')</script>");
            else
            {
                int result = controllerObj.ComplaintReply(Reply, complaintID,Session["EmployeeID"].ToString());     //Updating the complaint in the database with our reply
                if (result != 0)
                {
                    Response.Write("<script>alert('Your reply is sent ')</script>");
                    Response.Redirect("Customerservice.aspx");                           //Redirect to the customer service profile 


                }
                else
                    Response.Write("<script>alert('Replying process was interrupted')</script>");


            }
        }


        protected void Button3_Click(object sender, EventArgs e)  //Replying to a customer complaint on button click event
        {
            customerserviceReply();
        }

        protected void Button5_Click(object sender, EventArgs e) //View pending returned products
        {

            GridView1.DataSource = controllerObj.SelectPendingReturned();
            GridView1.DataBind();

        }

        protected void Button6_Click(object sender, EventArgs e)  //View all Returned Products
        {
            GridView1.DataSource = controllerObj.SelectAllReturnedProducts();   //Select all returned products from the database
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e) // Return product
        {
            string CustomerID = TextBox4.Text.Trim();
            string ProductID = TextBox3.Text.Trim();
            DataTable dt = controllerObj.checkreturnProductExistence(CustomerID, ProductID);        //Check if the product is in to be returned products
            if (val.Checkblank(CustomerID,ProductID))                                              //Check for blank spaces
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>"); 
            }
            else if (dt == null)
            {
                Response.Write("<script>alert('Item doesn't exist in returns')</script>");
            }
            else 
            {
                int result = controllerObj.ReturnProduct(CustomerID, ProductID);        //Return the product
                if (result==0)
                {
                    Response.Write("<script>alert('Returning process Failed')</script>");
                }
                else
                {
                    dt = controllerObj.GetProduct(ProductID);
                    controllerObj.updateprofitandincome(ProductID, "-" + dt.Rows[0][6], "-" + dt.Rows[0][6]);
                    Response.Write("<script>alert('Product Returned Successfuly')</script>");
                    Response.Redirect("Customerservice.aspx");                           //Redirect to the customer service profile 

                }
            }

        }

        
    }
}