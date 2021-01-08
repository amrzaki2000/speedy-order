using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace DatabaseProject
{
    public partial class SellerProfile : System.Web.UI.Page
    {
        Controller controlObj;
        InputValidation val;
        protected void Page_Load(object sender, EventArgs e)
        {

            controlObj = new Controller();              //Creating Controller Object
            val = new InputValidation();
            if (Session["username"] == null)            //Checking if the current session is active
            {
                Response.Write("<script>alert('Please Log in First')</script>");    //In case of inactive session, redirect the user to log-in page 
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    DataTable dt = controlObj.GetSellerInfo(Session["username"].ToString());  // Set the information of the seller profile to their current Status
                    
                    TextBox1.Text = dt.Rows[0][0].ToString();
                    TextBox4.Text = dt.Rows[0][1].ToString();
                    TextBox9.Text = dt.Rows[0][3].ToString();
                    TextBox7.Text = dt.Rows[0][4].ToString();
                    TextBox8.Text = dt.Rows[0][5].ToString();
                    TextBox25.Text = dt.Rows[0][7].ToString();
                    TextBox26.Text = dt.Rows[0][8].ToString();
                    Label1.Text = "<i class=\"fa fa-star\"></i>  " + dt.Rows[0][6].ToString();
                    Label2.Text = "Active";
                    Label2.CssClass = "badge badge-pill badge-success";


                    // Getting info in case seller is banned
                    dt = controlObj.getBanned(Session["username"].ToString());
                    if (dt != null && dt.Rows.Count >= 1)
                    {
                        TextBox28.Text = dt.Rows[0][2].ToString();
                        TextBox23.Text = dt.Rows[0][3].ToString();
                        Label2.Text = "Suspended";
                        Label2.CssClass = "badge badge-pill badge-danger";
                    }

                }
            }
           
            

        }

        //Function to update the information of a seller
        public void Update()
        {
            string username = TextBox2.Text;
            string pass = TextBox5.Text;
            string newpass = TextBox10.Text;
            string fname = TextBox1.Text;
            string lname = TextBox4.Text;
            string bdate = TextBox9.Text;
            string phone = TextBox7.Text;
            string address = TextBox8.Text;

            if (val.Checkblank(username, pass, newpass, fname, lname, bdate, phone, address))
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            else if (Session["username"].ToString() != username || Session["Password"].ToString() != pass)
                Response.Write("<script>alert('Wrong Credentials. Please enter the correct ones')</script>");
            else
            {

                int result1 = controlObj.UpdateSeller(username, fname, lname, bdate, phone, address);
                int result2 = controlObj.UpdatePassword(username, newpass);

                if (result1 == 0 && result2 == 0)
                    Response.Write("<script>alert('Information Could not be Updated')</script>");
                else
                    Response.Write("<script>alert('Information Updated Successfully')</script>");

            }
        }

        //Fuction that adds a new product to the inventory
        public void addProduct()
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string filepath = "~/imgs/Products" + filename;
            FileUpload1.SaveAs(Server.MapPath(filepath));
            string name = TextBox6.Text;
            int price = int.Parse(TextBox11.Text);
            string color = TextBox12.Text;
            string Size = DropDownList1.SelectedValue;
            int quantity = int.Parse(TextBox13.Text);
            
        }

        protected void Button1_Click(object sender, EventArgs e) //Updates user Information onclick
        {
            Update();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}