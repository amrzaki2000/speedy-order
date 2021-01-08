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

            if (username.Length == 0 || email.Length == 0 || first.Length == 0 || last.Length == 0 || pass.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || bdate.Length == 0 || type.Length == 0)
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
                    else
                    {
                        result = controllerObj.InsertCustomer(email, first, last, phonenumber, address, bdate);
                        if (result != 0)
                        {
                            result2 = controllerObj.InsertSub(username, pass, null, "Customers", null, null, type);
                            if (result2 == 0)
                                Response.Write("<script>alert('Sign-Up process was interrupted')</script>");
                        }
                    }

                }
                else
                {
                    if (val.CheckifemailExists(email, "Sellers"))
                        Response.Write("<script>alert('Email is already registered. Log in or use another email or change your user type')</script>");
                    else
                    {
                        result = controllerObj.InsertSeller(email, first, last, phonenumber, address, bdate);
                        if (result != 0)
                        {
                            result2 = controllerObj.InsertSub(username, pass, null, null, null, "Sellers", type);
                            if (result2 == 0)
                                Response.Write("<script>alert('Sign-Up process was interrupted')</script>");
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