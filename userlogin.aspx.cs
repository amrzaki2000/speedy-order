using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DatabaseProject
{
    public partial class userlogin : System.Web.UI.Page
    {
        Controller controllerObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            // select * from Subscriber WHERE Username='SellerTrial' and Password=123 and SellerID=111 and UserType='Seller'
            try
            {
                string userType = "a";
               
                DataTable dt = controllerObj.userLogin(username.Text.Trim(), TextBox1.Text.Trim());

               // Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                if (dt==null)
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
                else if (dt.Rows[0][6].ToString().ToLower() == "customer" || dt.Rows[0][6].ToString().ToLower() == "seller"  )
                {
                    Response.Write("<script>alert('Login Successful, Hello " + username.Text.Trim() + "');</script>");
                    userType=dt.Rows[0][5].ToString();
                    Session["username"] = username.Text.Trim();
                    Session["userType"] = userType;
                    Session["role"] = "user";
                    Response.Redirect("WebForm1.aspx");
                    
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