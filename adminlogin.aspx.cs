using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DatabaseProject
{
    public partial class adminlogin : System.Web.UI.Page
    {
        Controller controllerObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userType = "a";
                DataTable dt = controllerObj.userLogin(username.Text.Trim(), TextBox1.Text.Trim());

                // Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                if (dt == null)
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
                
                else if (dt.Rows[0][6].ToString().ToLower() == "admin")
                {
                    Response.Write("<script>alert('Login Successful, Hello "+ username.Text.Trim() + "');</script>");
                    userType = dt.Rows[0][6].ToString();
                    Session["username"] = username.Text.Trim();
                    Session["Password"] = TextBox1.Text.Trim();
                    Session["userType"] = userType;
                    Session["role"] = "admin";
                    Session["adminID"] = dt.Rows[0][2].ToString();
                    Response.Redirect("adminmanagement.aspx");
                }
                else if (dt.Rows[0][6].ToString().ToLower() == "customerservice")
                {
                    Response.Write("<script>alert('Login Successful, Hello " + username.Text.Trim() + "');</script>");
                    userType = dt.Rows[0][6].ToString();
                    Session["username"] = username.Text.Trim();
                    Session["Password"] = TextBox1.Text.Trim();
                    Session["userType"] = userType;
                    Session["role"] = "customerservice";
                    Session["userID"] = dt.Rows[0][5].ToString();
                    Response.Redirect("Customerservice.aspx");
                }

            }
            catch (Exception ex)
            {
                //  Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.Write("<script>alert('Invalid credentials ERROR');</script>");
            }
        }
    }
}