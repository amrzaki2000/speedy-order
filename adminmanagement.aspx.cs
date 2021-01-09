using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public partial class adminmanagement : System.Web.UI.Page
    {
        Controller controllerObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            GridView1.DataBind();
            if(Session["username"] ==null)
            {
                Response.Redirect("adminlogin.aspx");
            }
        }

        protected void Button10_Click(object sender, EventArgs e) //Get Seller
        {
            DataTable dt = controllerObj.SelectSeller(TextBox8.Text);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }

        protected void Button11_Click(object sender, EventArgs e) // view all Sellers
        {
            DataTable dt = controllerObj.SelectAllSeller();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }

        protected void Button12_Click(object sender, EventArgs e) //Ban Seller
        {
            int adID = Convert.ToInt32(Session["adminID"]);
           
         
          if(TextBox10.Text.Trim().Length == 0)
          {
                Response.Write("<script>alert('The insertion of a new Banned seller failed  Please fill in Reason of Suspension');</script>");
                return;
          }
           int result = controllerObj.BannSeller(Convert.ToInt32(Session["adminID"]), TextBox9.Text, TextBox10.Text);
          if (result == 0)
          {
                Response.Write("<script>alert('The insertion of a new Banned seller failed');</script>");
          }
          else
          {
                
                Response.Write("<script>alert('The row is inserted successfully!');</script>");

          }
        }

        protected void Button13_Click(object sender, EventArgs e)  //view Banned sellers
        {
            DataTable dt = controllerObj.SelectAllBannedSellers();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void Button14_Click(object sender, EventArgs e)     //UnBannn seller
        {
            int result = controllerObj.UnBannSeller(TextBox9.Text);
            if (result == 0)
            {
                Response.Write("<script>alert('UnBan Seller failed');</script>");
            }
            else
            {
                Response.Write("<script>alert('Seller is unbanned successfully!');</script>");
            }

        }

        protected void Button20_Click(object sender, EventArgs e) //Get Order
        {
            DataTable dt = controllerObj.SelectOrder(   TextBox11.Text  );
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void Button16_Click(object sender, EventArgs e)// View all Orders
        {
            DataTable dt = controllerObj.SelectAllOrders();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }
        //                              ====================================  Customer Management  =============
        protected void Button2_Click(object sender, EventArgs e)  //Get Customer
        {
            DataTable dt = controllerObj.SelectCustomer(TextBox1.Text);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e) //Get All Customers
        {
            DataTable dt = controllerObj.SelectAllCustomers();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e) //Ban customer
        {
            //int adID = Convert.ToInt32(Session["adminID"]);
           
            
            if (TextBox7.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('The insertion of a new Banned Customer failed  Please fill in Reason of Suspension');</script>");
                return;
            }
            int result = controllerObj.BannSeller(Convert.ToInt32(Session["adminID"]), TextBox3.Text, TextBox7.Text);
            if (result == 0)
            {
                Response.Write("<script>alert('The insertion of a new Banned customer failed');</script>");
            }
            else
            {

                Response.Write("<script>alert(Customer is banned successfully!');</script>");

            }
        }

        protected void Button5_Click(object sender, EventArgs e) //view  All Banned customer
        {
            DataTable dt = controllerObj.SelectAllBannedCustomers();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)  // unBan Customer
        {
            int result = controllerObj.UnBannSeller(TextBox3.Text);
            if (result == 0)
            {
                Response.Write("<script>alert('UnBan Customer failed');</script>");
            }
            else
            {
                Response.Write("<script>alert('Customer is unbanned successfully!');</script>");
            }
        }
    }
}