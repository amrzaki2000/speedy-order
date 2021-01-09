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
        }




        protected void UpdateCustomerservice()
        {
            string username = TextBox17.Text.Trim();
            string fname = TextBox12.Text.Trim();
            string lname = TextBox13.Text.Trim();
            string phonenumber = TextBox14.Text.Trim();
            string address = TextBox15.Text.Trim();
            string oldpass = TextBox18.Text.Trim();
            string newpass = TextBox19.Text.Trim();
            DataTable dt = controllerObj.checkforusernameexistance(username);
            DataTable dt1 = controllerObj.getpassfromusername(username);
            DataTable dt3 = controllerObj.userLogin(username, oldpass);
            if (username.Length == 0 || fname.Length == 0 || lname.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || oldpass.Length == 0 || newpass.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (dt == null)
                Response.Write("<script>alert('Username incorrect')</script>");
            else if (oldpass != Session["Password"].ToString())
                Response.Write("<script>alert('old password in correct')</script>");
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
                        Response.Write("<script>alert('updating process succeeded')</script>");
                }

            }
        }




        protected void Button15_Click(object sender, EventArgs e)
        {
            UpdateCustomerservice();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectAllComplaints();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectPendingComplaints();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }


        protected void customerserviceReply()
        {
            string Customerid = TextBox2.Text.Trim();
            string OrderID = TextBox3.Text.Trim();
            string Reply = TextBox1.Text.Trim();
            DataTable dt = controllerObj.checkforCustomeridexistance(Customerid);
            DataTable dt2 = controllerObj.checkforOrderIDexistance(OrderID);
            if (Customerid.Length == 0 || OrderID.Length == 0 || Reply.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (dt == null)
                Response.Write("<script>alert('Customer ID not exist')</script>");
            else if (dt2 == null)
                Response.Write("<script>alert('Order ID not exist')</script>");
            else
            {
                int result = controllerObj.ComplaintReply(Reply, OrderID, Customerid,Session["EmployeeID"].ToString());
                if (result != 0)

                    Response.Write("<script>alert('your reply sent ')</script>");
                else
                    Response.Write("<script>alert('replying process was interrupted')</script>");


            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            customerserviceReply();
        }
    }
}