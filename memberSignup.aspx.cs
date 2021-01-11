using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseProject
{
    public partial class memberSignup : System.Web.UI.Page
    {
        Controller controllerObj;
        InputValidation val;

        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            val = new InputValidation();
        }
        protected void signup()
        {
            string username = TextBox2.Text.Trim();
            string email = TextBox3.Text.Trim();
            string first = TextBox1.Text.Trim();
            string last = TextBox4.Text.Trim();
            string pass = TextBox5.Text.Trim();
            string confirm_pass = TextBox6.Text.Trim();
            string phonenumber = TextBox7.Text.Trim();
            string address = TextBox8.Text.Trim();
            string bdate = TextBox9.Text.Trim();
            string type = DropDownList1.SelectedValue.Trim();
            
            if (val.Checkblank(username, email, first, last, pass, phonenumber, address, bdate, type))
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (pass != confirm_pass)
                Response.Write("<script>alert('Passwords do not match')</script>");
            else if (type != "Customer" && type != "Seller")
                Response.Write("<script>alert('Please select a valid user type')</script>");
            else if (val.CheckifUserExists(username))
                Response.Write("<script>alert('Username already exists. Please log in or choose another username')</script>");
            else
            {
                int result;
                int result2;
                if (type == "Customer")
                {
                    if (val.CheckifemailExists(email,"Customers"))
                        Response.Write("<script>alert('Email is already registered. Log in or use another email or change your user type')</script>");
                    else if(!val.isPositive(Int32.Parse(phonenumber)))
                        Response.Write("<script>alert('Please enter a valid phone number')</script>");

                    else
                    {
                        result = controllerObj.InsertCustomer(email, first, last, phonenumber, address, bdate);
                        if (result != 0)
                        {
                            result2 = controllerObj.InsertSub(username, pass, null, "Customers", null, null, type);
                            if (result2 == 0)
                                Response.Write("<script>alert('Sign-Up process was interrupted')</script>");
                            else
                            {
                                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                                Response.Redirect("userlogin.aspx");
                            }
                        }
                    }

                }
                else
                {
                    if (val.CheckifemailExists(email, "Sellers"))
                        Response.Write("<script>alert('Email is already registered. Log in or use another email or change your user type')</script>");
                    else if (!val.isPositive(Int32.Parse(phonenumber)))
                        Response.Write("<script>alert('Please enter a valid phone number')</script>");
                    else
                    {
                        result = controllerObj.InsertSeller(email, first, last, phonenumber, address, bdate);
                        if (result != 0)
                        {
                            result2 = controllerObj.InsertSub(username, pass, null, null, "Sellers", null , type);
                            if (result2 == 0)
                                Response.Write("<script>alert('Sign-Up process was interrupted')</script>");
                            else
                            {
                                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                                Response.Redirect("userlogin.aspx");

                            }
                        }
                    }
                }
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //Signup Button
        {
                signup();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }
    }
}