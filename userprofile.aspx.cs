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


        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            if (Session["username"] == null)            //Checking if the current session is active
            {
                Response.Write("<script>alert('Please Log in First')</script>");    //In case of inactive session, redirect the user to log-in page 
                Response.Redirect("userlogin.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)  //updateee
        {
            
            int result = controllerObj.UpdateCustomer(TextBox1.Text, TextBox4.Text, Int32.Parse(TextBox7.Text), TextBox8.Text, TextBox2.Text, TextBox5.Text);
            if (result == 0)
            {
                Response.Write("<script>alert('No Rows are updated');</script>");
            }
            else
            {
                Response.Write("<script>alert('he row is updated successfully');</script>");
            }
            int result1 = controllerObj.UpdateCustomerPassword(TextBox2.Text, TextBox10.Text); //subscriber
            if (result1 == 0)
            {
                Response.Write("<script>alert('No Rows are updated');</script>");
            }
            else
            {
                Response.Write("<script>alert('he row is updated successfully');</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e) //Appeal
        {
            //int userID =Int32.Parse( Session["userID"]  ) ;
            // Convert.ToInt32(Session["userID"])
            int result = controllerObj.InsertAppeal(TextBox3.Text,    Session["username"].ToString()  );
            if (result == 0)
            {
                Response.Write("<script>alert('The insertion of a new supplier failed');</script>");
            }
            else
            {
                Response.Write("<script>alert('TThe row is inserted successfully!');</script>");

            }

        }
    }
}