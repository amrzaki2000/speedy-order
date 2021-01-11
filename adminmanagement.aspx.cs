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
    public partial class adminmanagement : System.Web.UI.Page
    {
        Controller controllerObj;
        InputValidation val;

        protected void Page_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
            val = new InputValidation();

            if (Session["username"] == null)
            {
                Response.Redirect("adminlogin.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    GridView1.DataSource = controllerObj.SelectAllSeller();
                    GridView1.DataSource = controllerObj.SelectAllSeller();
                    GridView1.DataBind();
                }

                
            }
        }

        protected void UpdateAdmin()
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

                result = controllerObj.UpdateAdmin(username, fname, lname, phonenumber, address);
                if (result != 0)
                {
                    
                    result2 = controllerObj.UpdatesubsAdmin(username, newpass);
                    if (result2 == 0)
                        Response.Write("<script>alert('updating process was interrupted')</script>");
                    else
                    {
                        Session["Password"] = newpass;
                    }
                }

            }
        }



        protected void Button15_Click(object sender, EventArgs e)
        {
            UpdateAdmin();
        }



        protected void insertadmin()
        {
            string username = adminusername.Text.Trim();
            string fname = adminfirst.Text.Trim();
            string lname = adminlast.Text.Trim();
            string phonenumber = adminphone.Text.Trim();
            string address = adminaddress.Text.Trim();
            string pass = adminpass.Text.Trim();
            string salary = adminsalary.Text.Trim();
            string email = adminemail.Text.Trim();
            DataTable dt = controllerObj.checkforusernameexistance(username);
            if (username.Length == 0 || fname.Length == 0 || lname.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || salary.Length == 0 || pass.Length == 0 || email.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }

            else if (dt != null)
                Response.Write("<script>alert('Username already exists.')</script>");
            else
            {
                int result;
                int result2;

                if (val.CheckifemailExists(email, "Admins"))
                    Response.Write("<script>alert('Email is already registered. Log in or use another email or change your user type')</script>");
                else
                {
                    result = controllerObj.InsertAdmin(fname, lname, phonenumber, address, email, salary);

                    if (result != 0)
                    {
                        result2 = controllerObj.InsertSub(username, pass, "Admins", null, null, null, "Admin");
                        if (result2 == 0)
                            Response.Write("<script>alert('Insert process was interrupted')</script>");
                        else
                        {

                            Response.Write("<script>alert('Insert process successded')</script>");

                        }
                    }
                }

            }
        }



        protected void Insertadmin_Click(object sender, EventArgs e)
        {
            insertadmin();
        }

        protected void Insertcustomerservice()
        {
            string fname = cservicefirst.Text.Trim();
            string lname = cservicelast.Text.Trim();
            string phonenumber = cservicephone.Text.Trim();
            string address = cserviceaddress.Text.Trim();
            string salary = cservicesalary.Text.Trim();
            string email = cserviceemail.Text.Trim();
            string username = cservice_username.Text.Trim();
            string pass = cservice_pass.Text.Trim();
            string Supervisor = cservice_supervisor.Text.Trim();
            string workinghours = cservicehours.Text.Trim();


            DataTable dt = controllerObj.checkforusernameexistance(username);
            DataTable dt1 = controllerObj.checkforadminunexistance(Supervisor);


            if (username.Length == 0 || fname.Length == 0 || lname.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || salary.Length == 0 || pass.Length == 0 || email.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (dt1 == null)
                Response.Write("<script>alert(' Super visor Username not exists.')</script>");
            else if (dt != null)
                Response.Write("<script>alert('Username already exists.')</script>");
            else
            {
                int result;
                int result2;
                DataTable dt3 = controllerObj.getAdminIDfromUsername(Supervisor);
                string superid = (dt3.Rows[0][0]).ToString();
                if (val.CheckifemailExists(email, "CustomerService"))
                    Response.Write("<script>alert('Email is already registered. use another email ')</script>");
                else
                {
                    result = controllerObj.InsertCustomerService(fname, lname, phonenumber, address, email, salary, workinghours, superid);

                    if (result == 0)
                        Response.Write("<script>alert('Insert process was interrupted')</script>");
                    if (result != 0)
                    {
                        result2 = controllerObj.InsertSub(username, pass, null, null, null, "CustomerService", "CustomerService");

                        if (result2 == 0)
                            Response.Write("<script>alert('Insert process was interrupted')</script>");
                        else
                        {

                            Response.Write("<script>alert('Insert process successded')</script>");

                        }
                    }
                }

            }

        }


        protected void add_cs_Click(object sender, EventArgs e)
        {
            Insertcustomerservice();
        }

        protected void AddPromocode()
        {
            string promoid = TextBox2.Text.Trim();
            string discountprecent = TextBox4.Text.Trim();



            if (promoid.Length == 0 || discountprecent.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (Int32.Parse(TextBox4.Text) < 0)
                Response.Write("<script>alert('Please enter positive value')</script>");

            else
            {
                int result;
                result = controllerObj.AddPromocode(promoid, discountprecent);
                if (result == 0)
                    Response.Write("<script>alert('Adding process was interrupted')</script>");
                else
                {
                    Response.Write("<script>alert('Adding process successded')</script>");
                }
            }
        }

        protected void UpdatePromocode()
        {

            string promoid = TextBox2.Text.Trim();
            string discountprecent = TextBox4.Text.Trim();


            if (promoid.Length == 0 || discountprecent.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (Int32.Parse(TextBox4.Text) < 0)
                Response.Write("<script>alert('Please enter positive value')</script>");
            else
            {
                int result;
                result = controllerObj.UpdarePromocode(promoid, discountprecent);
                if (result == 0)
                    Response.Write("<script>alert('Updating process was interrupted')</script>");

                else
                {
                    Response.Write("<script>alert('Updating process successded')</script>");
                }
            }
        }


        protected void RemovePromocode()
        {
            string promoid = TextBox2.Text.Trim();



            if (promoid.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }

            else
            {
                int result;
                result = controllerObj.RemovePromocode(promoid);

                if (result == 0)
                    Response.Write("<script>alert('Removing process was interrupted')</script>");

                else
                {
                    Response.Write("<script>alert('Removing process successded')</script>");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddPromocode();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            UpdatePromocode();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            RemovePromocode();
        }

        /////=================================================================================================================
        protected void Button10_Click(object sender, EventArgs e) //Get Seller
        {
            DataTable dt = controllerObj.SelectSeller(TextBox8.Text);
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Button11_Click(object sender, EventArgs e) // view all Sellers
        {
            DataTable dt = controllerObj.SelectAllSeller();
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void Button12_Click(object sender, EventArgs e) //Ban Seller
        {
            int adID = Convert.ToInt32(Session["adminID"]);


            if (TextBox10.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('The insertion of a new Banned seller failed  Please fill in Reason of Suspension');</script>");
                return;
            }
            int result = controllerObj.BannSeller(Convert.ToInt32(Session["adminID"]), TextBox9.Text.Trim(), TextBox10.Text.Trim());
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
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


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
            DataTable dt = controllerObj.SelectOrder(TextBox11.Text.Trim());
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                OrdersGridView.DataSource = dt;
                OrdersGridView.DataBind();
            }

        }

        protected void Button16_Click(object sender, EventArgs e)// View all Orders
        {
            DataTable dt = controllerObj.SelectAllOrders();
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                OrdersGridView.DataSource = dt;
                OrdersGridView.DataBind();
            }

        }
        //                              ====================================  Customer Management  =============
        protected void Button2_Click(object sender, EventArgs e)  //Get Customer
        {
            DataTable dt = controllerObj.SelectCustomer(TextBox1.Text.Trim());
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                CustomerGridView.DataSource = dt;
                CustomerGridView.DataBind();
            }

        }

        protected void Button4_Click(object sender, EventArgs e) //Get All Customers
        {
            DataTable dt = controllerObj.SelectAllCustomers();
            CustomerGridView.DataSource = dt;
            CustomerGridView.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e) //Ban customer
        {
            //int adID = Convert.ToInt32(Session["adminID"]);


            if (TextBox7.Text.Trim().Length == 0)
            {
                Response.Write("<script>alert('The insertion of a new Banned Customer failed  Please fill in Reason of Suspension');</script>");
                return;
            }
            int result = controllerObj.BannSeller(Convert.ToInt32(Session["adminID"]), TextBox3.Text.Trim(), TextBox7.Text.Trim());
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
            if (dt == null)
            {
                Response.Write("<script>alert('Customer not found !')</script>");
            }
            else
            {
                CustomerGridView.DataSource = dt;
                CustomerGridView.DataBind();
            }
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

        protected void Button17_Click(object sender, EventArgs e)
        {
            DataTable dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10, dt11, dt12;
            dt1 = controllerObj.TotalIncome();
            dt2 = controllerObj.NumEmployees();
            dt3 = controllerObj.NumSellers();
            dt4 = controllerObj.NumCustomers();
            dt5 = controllerObj.NumProducts();
            dt6 = controllerObj.NumQuantity();
            dt7 = controllerObj.TotalSalaries();
            dt8 = controllerObj.NumOrders();
            dt9 = controllerObj.NumReturns();
            dt10 = controllerObj.NumPromo();
            dt11 = controllerObj.TotalBans();
            dt12 = controllerObj.NumPromosUsed();
            dt11 = controllerObj.TotalBans();

            if (dt1 == null)
            { TextBox25.Text = "0"; }
            else
            { TextBox25.Text = dt1.Rows[0][0].ToString(); }

            if (dt2 == null)
            { TextBox20.Text = "0"; }
            else
            { TextBox20.Text = dt2.Rows[0][0].ToString(); }

            if (dt3 == null)
            { TextBox21.Text = "0"; }
            else
            { TextBox21.Text = dt3.Rows[0][0].ToString(); }

            if (dt4 == null)
            { TextBox22.Text = "0"; }
            else
            { TextBox22.Text = dt4.Rows[0][0].ToString(); }

            if (dt5 == null)
            { TextBox23.Text = "0"; }
            else
            { TextBox23.Text = dt5.Rows[0][0].ToString(); }

            if (dt6 == null)
            { TextBox24.Text = "0"; }
            else
            { TextBox24.Text = dt6.Rows[0][0].ToString(); }

            if (dt7 == null)
            { TextBox26.Text = "0"; }
            else
            { TextBox26.Text = (Int32.Parse(dt7.Rows[0][0].ToString()) + Int32.Parse(dt7.Rows[1][0].ToString())).ToString(); }

            if (dt8 == null)
            { TextBox28.Text = "0"; }
            else
            { TextBox28.Text = dt8.Rows[0][0].ToString(); }

            if (dt9 == null)
            { TextBox29.Text = "0"; }
            else
            { TextBox29.Text = dt9.Rows[0][0].ToString(); }

            if (dt10 == null)
            { TextBox30.Text = "0"; }
            else
            { TextBox30.Text = dt10.Rows[0][0].ToString(); }

            if (dt11 == null)
            { TextBox31.Text = "0"; }
            else
            { TextBox31.Text = dt11.Rows[0][0].ToString(); }

            if (dt12 == null)
            { TextBox32.Text = "0"; }
            else
            { TextBox32.Text = dt12.Rows[0][0].ToString(); }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            int result = controllerObj.GrantPromo(TextBox6.Text.Trim(), TextBox5.Text.Trim());
            if(result == 0)
            {
                Response.Write("<script>alert('Promo code or customer ID do not exist')</script>");
            }
            else
            {
                Response.Write("<script>alert('Promo code is granted successfully')</script>");


            }
        }




        /////////////////////////////////////////////////////////////////

    }
}