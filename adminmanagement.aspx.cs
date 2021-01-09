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
            DataTable dt3 = controllerObj.userLogin(username,oldpass);
            if (username.Length == 0 || fname.Length == 0 || lname.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || oldpass.Length == 0 || newpass.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if(dt==null)
                Response.Write("<script>alert('Username incorrect')</script>");
            else if (oldpass!=Session["Password"].ToString())
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
            if (username.Length == 0 || fname.Length == 0 || lname.Length == 0 || phonenumber.Length == 0 || address.Length == 0 || salary.Length == 0 || pass.Length == 0||email.Length==0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }

            else if (dt!=null)
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
                            result2 = controllerObj.InsertSub(username, pass, "Admins",null , null, null,"Admin");
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
            else if(dt1==null)
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
                    
                    if(result==0)
                        Response.Write("<script>alert('Insert process was interrupted')</script>");
                    if (result != 0)
                    {
                        result2 = controllerObj.InsertSub(username, pass, null, null, null, "CustomerService", "CustomerService");

                        if (result2 == 0 )
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

          

            if (promoid.Length == 0 || discountprecent.Length == 0 )
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
            else if(Int32.Parse(TextBox4.Text) < 0)
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
    }
}