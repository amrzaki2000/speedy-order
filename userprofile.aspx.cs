using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseProject
{
    public partial class userprofile : System.Web.UI.Page
    {
        Controller controllerObj;
        InputValidation val;

        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            val = new InputValidation();

            if (Session["username"] == null)            //Checking if the current session is active
            {
                Response.Write("<script>alert('Please Log in First')</script>");    //In case of inactive session, redirect the user to log-in page 
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                DataTable dt = controllerObj.GetCustomerInfo(Session["username"].ToString());   //Get the logged in customer info
                if (!Page.IsPostBack)
                {
                    // Set the information of the customer profile to their current Status


                    TextBox1.Text = dt.Rows[0][0].ToString();
                    TextBox4.Text = dt.Rows[0][1].ToString();
                    TextBox9.Text = dt.Rows[0][3].ToString();
                    TextBox7.Text = dt.Rows[0][4].ToString();
                    TextBox8.Text = dt.Rows[0][5].ToString();


                    Label6.Text =  dt.Rows[0][6].ToString();
                    Label7.Text = "Active";
                    Label7.CssClass = "badge badge-pill badge-success";
                    GridView1.DataBind();
                    GridView2.DataBind();
                    GridView3.DataBind();

                }

                // Getting info in case customer is banned

                dt = controllerObj.getBanned(Session["username"].ToString());
                if (dt != null && dt.Rows.Count >= 1)
                {
                    //Changing the customer badge text
                    Label7.Text = "Suspended";
                    Label7.CssClass = "badge badge-pill badge-danger";

                }
            }

        }

        // Update Customer information button
        protected void Button1_Click(object sender, EventArgs e) 
        {

            if(val.Checkblank(TextBox1.Text,TextBox4.Text, TextBox7.Text, TextBox8.Text,TextBox2.Text,TextBox5.Text))       //Check for blank fields
                Response.Write("<script>alert('Please fill the blank spaces');</script>");
            else if (!val.isPositive(Int32.Parse(TextBox7.Text)))                                                           // Check for the phone number
                Response.Write("<script>alert('Please enter a valid phone number');</script>");
           else if(Session["username"].ToString() != TextBox2.Text || Session["Password"].ToString() != TextBox5.Text)      //Check for login credentials
                Response.Write("<script>alert('Invalid login credentials');</script>");
            else
            {
                //Update Customer Profile information
                int result = controllerObj.UpdateCustomer(TextBox1.Text, TextBox4.Text, Int32.Parse(TextBox7.Text), TextBox8.Text, TextBox2.Text, TextBox5.Text);
                if (result == 0)
                {
                    Response.Write("<script>alert('Information could not be updated');</script>");              //Message on exception

                }
                else
                {
                    int result1 = controllerObj.UpdateCustomerPassword(TextBox2.Text, TextBox10.Text); //Updating the customer Password
                    if (result1 == 0)
                    {
                        Response.Write("<script>alert('Password could not be updated');</script>");  //Message on exception
                    }
                    else
                    {
                        Response.Write("<script>alert('Password is updated successfully');</script>");      //Message on success
                        Response.Redirect("userprofile.aspx");                                          //Redirect to customer profile
                    }
                }
                
                
            }
        }

        //Submit an appeal button
        protected void Button2_Click(object sender, EventArgs e) //Appeal
        {
           
            int result = controllerObj.InsertAppeal(TextBox3.Text,    Session["username"].ToString()  );        //Insert the appeal of the customer
            if (result == 0)
            {
                Response.Write("<script>alert('Your appeal could not be sumbitted');</script>"); //Message on exception
            }
            else
            {
                Response.Write("<script>alert('Your appeal is sumbitted');</script>");  // Message on success
                Response.Redirect("userprofile.aspx");                                  //Redirect to customer profile

            }

        }

        //Submit a complaint button
        protected void Button4_command(object sender, CommandEventArgs e)   //Complaining about a product
        {
            if(Session["userID"].Equals(null))                              //Check in case of inactive session
            {
                Response.Write("<script>alert('You have to log in first !');</script>");    //Redirect the user to log in page
            }
            else
            {
                int row = Convert.ToInt32(e.CommandArgument);                               //Getting the selected rowindex from the gridview
                DataTable dt = controllerObj.SelectCustomerBoughtProducts(Session["userID"].ToString()); //Getting the products that the logged in customer bought
                TextBox t1 = GridView1.Rows[row].FindControl("TextBox1") as TextBox;                    // Getting the complaint description
                
                if(val.Checkblank(t1.Text.Trim()))                                        //Checking for blank spaces
                    Response.Write("<script>alert('Please fill your complaint text first !');</script>");             //Message on exception
                else
                {
                    int result = controllerObj.InsertComplaint(dt.Rows[row][0].ToString(), dt.Rows[row][1].ToString(), Session["userID"].ToString(), "Pending",
                        t1.Text);       // Inserting a Customer Complaint to an employee
                    if(result ==0)
                        Response.Write("<script>alert('There was a problem subitting your Complaint !');</script>");    //Message on exception
                    else
                        Response.Write("<script>alert('Your complaint have been recieved. Complaint ID is sent to you by email. Use it to keep track" +
                            " of your complaint status. ');</script>");     //Message on success
                    GridView2.DataBind();
                    Response.Redirect("userprofile.aspx");              //Redirect to customer profile
                }

            }
            

        }

        protected void Button5_command(object sender, CommandEventArgs e)   //Complaining about a product
        {
            if (Session["userID"].Equals(null))                              //Check in case of inactive session
            {
                Response.Write("<script>alert('You have to log in first !');</script>");    //Redirect the user to log in page
            }
            else
            {
                int row = Convert.ToInt32(e.CommandArgument);                               //Getting the selected rowindex from the gridview

                DataTable dt = controllerObj.SelectCustomerBoughtProducts(Session["userID"].ToString()); //Getting the products that the logged in customer bought

                TextBox t1 = GridView1.Rows[row].FindControl("TextBox1") as TextBox;                    // Getting the complaint description

                if (val.Checkblank(t1.Text.Trim()))                                        //Checking for blank spaces
                    Response.Write("<script>alert('Please fill your complaint text first !');</script>");             //Message on exception
                else
                {
                    int result = controllerObj.InsertinReturned(dt.Rows[row][1].ToString(),Session["userID"].ToString(),t1.Text.Trim()) ;       // Inserting a Customer Complaint to an employee
                    if (result == 0)
                        Response.Write("<script>alert('There was a problem subitting your Complaint !');</script>");    //Message on exception
                    else
                        Response.Write("<script>alert('Your complaint have been recieved. Complaint ID is sent to you by email. Use it to keep track" +
                            " of your complaint status. ');</script>");          //Message on success
                    GridView2.DataBind();
                    Response.Redirect("userprofile.aspx");                       //Redirect to customer profile
                }

            }


        }
    }
}