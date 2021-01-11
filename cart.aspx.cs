using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DatabaseProject
{
    public partial class cart : System.Web.UI.Page
    {
        Controller controlObj;
        static double discountpercent;
        static long final;
        static int shipping;
        protected void Page_Load(object sender, EventArgs e)
        {
            controlObj = new Controller();

            if (Session["userID"] == null)
                Response.Redirect("userlogin.aspx");
            
            if (!Page.IsPostBack)
            {
                

                GridView1.DataBind();
                discountpercent = 0;
                UpdateMoney();
            }
        }
        

        public long calcTotalPrice()
        {
            
            
                DataTable dt = controlObj.getCustomertotalprice(Session["userID"].ToString());
                
                if ( dt != null)
                {


                    long total_price = Convert.ToInt64(dt.Rows[0][0]);
                    return total_price;
                }
                
                return 0;
            
        }

        public long calcTotalPoints()
        {
            DataTable dt = controlObj.getCustomerpoints(Session["userID"].ToString());
            if (dt != null)
            {
                return Convert.ToInt64( dt.Rows[0][0] );
            }
            else
                return 0;
        }


        public void clearCart()
        {
            
            controlObj.clearCustomerCart(Session["userID"].ToString());
            Response.Redirect("cart.aspx");
            
        }

        public void UpdateCustomerPoints()
        {
            controlObj.updatecustomerpoints(calcTotalPoints().ToString(), Session["userID"].ToString());
        }


        public void UpdateProductsQuantity()
        {
            DataTable dt = controlObj.SelectCustomerCart(Session["userID"].ToString());
            if(dt != null)
            {
                foreach(DataRow row in dt.Rows)
                {
                    string quantity = row[2].ToString();
                    string productid = row[0].ToString();
                    controlObj.UpdateProductQ(productid, quantity);
                    controlObj.UpdateWarehouseQ(productid, quantity);
                }
            }
            
        }

        public void UpdateSellersMoney()
        {
            DataTable dt = controlObj.SelectCustomerCart(Session["userID"].ToString());
            if(dt!=null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    double income =Convert.ToDouble( row[2]) * Convert.ToDouble( row[4]);
                    double profit = income * 0.9;
                    controlObj.updateprofitandincome(row[1].ToString(), income.ToString(), profit.ToString());
                }
            }
        }

        public void InsertCartintoOrder()
        {
            DataTable dt = controlObj.SelectCustomerCart(Session["userID"].ToString());
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    controlObj.InsertOrderContent(row[1].ToString(), row[2].ToString());
                }
            }
        }



        public void UpdateStatus()
        {
            DataTable dt = controlObj.SelectCustomerCart(Session["userID"].ToString());
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string productid = row[1].ToString();
                    DataTable dt1 = controlObj.GetProduct(productid);
                    if (dt1.Rows[0][8].ToString() == "0")
                        controlObj.setOutofStock(productid);
                }
            }

        }

        protected void Button1_Command(object sender, CommandEventArgs e)
        {

            int row = Convert.ToInt32(e.CommandArgument);
            DataTable dt = controlObj.SelectAllinCartProd();
            string customer_id = Session["userID"].ToString();
            string productid = dt.Rows[row][1].ToString();

            int result = controlObj.DeletefromCart(productid, customer_id);
            if (result == 0)
                Response.Write("<script>alert('Product could not be deleted')</script>");
            else
            {
                Response.Write("<script>alert('Product is removed from cart')</script>");
                GridView1.DataBind();
                UpdateMoney();
            }
        }

        public void UpdateMoney()
        {
            if (GridView1.Rows.Count > 0)
                shipping = 10;
            else
                shipping = 0;

            long total = calcTotalPrice();
            final = total + shipping - (long)(total*discountpercent);
            Label2.Text = "  +  " + total.ToString() + " $";
            Label4.Text = "  +  "+shipping.ToString()+" $";
            Label5.Text = "  -  " + (total*discountpercent).ToString() + " $";
            Label6.Text = final.ToString() + ".00  $";
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string code = TextBox1.Text;
            DataTable dt = controlObj.getPromo(code);
            if(dt == null)
                Response.Write("<script>alert('Please enter correct promo code')</script>");
            else
            {
                if (dt.Rows[0][3].ToString() == "true")
                    Response.Write("<script>alert('You have used this code already')</script>");
                else
                {
                    controlObj.UseCustomerPromo(code, Session["userID"].ToString());
                    discountpercent = Convert.ToDouble(dt.Rows[0][2]) / 100;

                    UpdateMoney(); 
                }

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                Response.Write("<script>alert('No Products were added in the cart')</script>");
            }
            else
            {
                int res1 = controlObj.InsertOrder(DateTime.Now.ToString(), final.ToString(), "10", "Shipping", null, Session["userID"].ToString());
                if (res1 == 0)
                    Response.Write("<script>alert('There was a problem creating the order. Please try again later')</script>");
                else
                {
                    InsertCartintoOrder();
                    UpdateCustomerPoints();
                    UpdateProductsQuantity();
                    UpdateSellersMoney();
                    UpdateStatus();
                    clearCart();
                    Response.Write("<script>alert('Thank you for shopping with us :)')</script>");

                }
            }
            

        }
    }
}