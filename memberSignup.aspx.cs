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
        //string strcon = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        /*public memberSignup()
        {
            InitializeComponent();
        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
        }

        protected void Button1_Click(object sender, EventArgs e) //Signup Button
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {  /*
                SqlConnection MyConnectionString = new SqlConnection(strcon);
                if (MyConnectionString.State == ConnectionState.Closed)
                {
                    MyConnectionString.Open();
                }*/
                if(DropDownList1.Text=="Seller")
                {
                    //SqlCommand cmd = new SqlCommand("insert into Sellers(SellerID,Fname,Lname,PhoneNumber,Address,Email,Rating,Profit,Income) values()", MyConnectionString);
                    //CountTextBox.Text = controllerObj.CountEmployee(Int16.Parse(PNOCOUNTTEXTBOX.Text)).ToString();
                    int result = controllerObj.InsertSeller(300, TextBox1.Text, TextBox4.Text, 123, "address"," Email@yahoo.com",5,500,900);
                }
                else
                {

                }
            }
            catch(Exception ex)
            {

            }

        }
    }
}