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

                DataTable dt = controlObj.GetSellerInfo(Session["username"].ToString()); ;
                
                if (!Page.IsPostBack)
                {
                      // Set the information of the seller profile to their current Status
                    
                    TextBox1.Text = dt.Rows[0][0].ToString();
                    TextBox4.Text = dt.Rows[0][1].ToString();
                    TextBox9.Text = dt.Rows[0][3].ToString();
                    TextBox7.Text = dt.Rows[0][4].ToString();
                    TextBox8.Text = dt.Rows[0][5].ToString();
                    

                    Label1.Text = "<i class=\"fa fa-star\"></i>  " + dt.Rows[0][6].ToString();
                    Label2.Text = "Active";
                    Label2.CssClass = "badge badge-pill badge-success";

                }

                TextBox25.Text = dt.Rows[0][7].ToString();
                TextBox26.Text = dt.Rows[0][8].ToString();

                // Getting info in case seller is banned

                dt = controlObj.getBanned(Session["username"].ToString());
                if (dt != null && dt.Rows.Count >= 1)
                {
                    TextBox28.Text = dt.Rows[0][2].ToString();
                    TextBox23.Text = dt.Rows[0][3].ToString();
                    Label2.Text = "Suspended";
                    Label2.CssClass = "badge badge-pill badge-danger";

                }
                GridView1.Visible = false;

                dt = controlObj.GetAllsellerProd(Session["userID"].ToString());
                DropDownList5.DataSource = dt;
                DropDownList5.DataMember = ;
                DropDownList5.DataBind();


            }



        }

        //Function to update the information of a seller
        public void Updateprofile()
        {
            string username = TextBox2.Text.Trim();
            string pass = TextBox5.Text.Trim();
            string newpass = TextBox10.Text.Trim();
            string fname = TextBox1.Text.Trim();
            string lname = TextBox4.Text.Trim();
            string bdate = TextBox9.Text.Trim();
            string phone = TextBox7.Text.Trim();
            string address = TextBox8.Text.Trim();

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
            string name = TextBox6.Text.Trim();
            string price = TextBox11.Text.Trim();
            string color = TextBox12.Text.Trim();
            string Size = DropDownList1.SelectedValue.Trim();
            string quantity = TextBox13.Text.Trim();
            string category = DropDownList2.SelectedValue.Trim();
            string Description = TextBox15.Text.Trim();

            if (val.Checkblank(filename, name, price.ToString(), color, Size, quantity.ToString(), category, Description))
                Response.Write("<script>alert('Please do not leave any blank spaces')</script>");
            else if( !( val.isPositive(int.Parse(price)) && val.isPositive(int.Parse(quantity)) ) )
                Response.Write("<script>alert('Please enter valid quantity and price')</script>");
            else
            {
                string filepath = "~/imgs/Products/" + filename;
                FileUpload1.SaveAs(Server.MapPath(filepath));
                DataTable dt = controlObj.GetSellerID(Session["username"].ToString());
                if (dt != null)
                {
                    int result = controlObj.InsertProd(name, Description, color, category, Size, price, "0", quantity, "null", "Pending Approval",dt.Rows[0][0].ToString(), filepath);
                    if(result !=0)
                        Response.Write("<script>alert('Product Inserted Successfully')</script>");
                    else
                        Response.Write("<script>alert('There was a problem inserting the product')</script>");
                }
                else
                    Response.Write("<script>alert('Seller ID not found in the database')</script>");
            }

        }

        public void Updateproduct()
        {

        }
        protected void Button1_Click(object sender, EventArgs e) //Updates user Information onclick
        {
            Updateprofile();
        }

      
        protected void Button4_Click(object sender, EventArgs e)
        {
            addProduct();
            GridView1.DataBind();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            
            GridView1.Visible = true;
        }
    }
}