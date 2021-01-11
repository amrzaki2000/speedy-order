using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DatabaseProject
{
    public partial class viewproducts : System.Web.UI.Page
    {
        Controller controlObj;
        InputValidation val;
        protected void Page_Load(object sender, EventArgs e)
        {
            controlObj = new Controller();
            val = new InputValidation();

            if (!Page.IsPostBack)
            {
                GridView1.DataBind();
                
            }
        }

        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void Button2_Command(object sender, CommandEventArgs e)
        {
            
            if ( Session["usertype"] == null ||  Session["usertype"].ToString().ToLower() != "customer")
            {
                Response.Write("<script>alert('Please create a customer account first')</script>");
            }
            else
            {
                int row = Convert.ToInt32(e.CommandArgument);
                TextBox t2 = GridView1.Rows[row].FindControl("TextBox2") as TextBox;
                string quantity = t2.Text.Trim();

                DataTable dt = controlObj.SelectAllProducts();
                dt = controlObj.GetProduct(dt.Rows[row][0].ToString());

                if (val.Checkblank(quantity) || !val.isPositive(Int32.Parse(quantity)))
                    Response.Write("<script>alert('Please select valid product quantity ')</script>");
                else if (int.Parse(dt.Rows[0][8].ToString()) < int.Parse(quantity))
                    Response.Write("<script>alert('Required quantity not available')</script>");
                else
                {
                    string product_id = dt.Rows[0][0].ToString();
                    int result = controlObj.AddtoCart(Session["userID"].ToString(), product_id, quantity, dt.Rows[0][12].ToString(), dt.Rows[0][6].ToString());
                    if (result == 0)
                        Response.Write("<script>alert('Product already in cart')</script>");
                    else
                    {
                        Response.Write("<script>alert('Product was added to cart successfully')</script>");
                        
                    }

                }
            }


        }


        protected void Button1_Command(object sender, CommandEventArgs e)
        {

            if (Session["usertype"] == null || Session["usertype"].ToString().ToLower() != "customer")
            {
                Response.Write("<script>alert('Please create a customer account first')</script>");
            }
            else
            {
                int row = Convert.ToInt32(e.CommandArgument);
                TextBox t1 = GridView1.Rows[row].FindControl("TextBox1") as TextBox;
                DropDownList d1 = GridView1.Rows[row].FindControl("DropdownList1") as DropDownList;
                string descp = t1.Text.Trim();
                string rating = d1.SelectedValue.Trim();

                DataTable dt = controlObj.SelectAllProducts();
                dt = controlObj.GetProduct(dt.Rows[row][0].ToString());

                if (val.Checkblank(descp))
                    Response.Write("<script>alert('Please let us know how you found this product ')</script>");
                else
                {
                    string product_id = dt.Rows[0][0].ToString();
                    int result = controlObj.AddReview(Session["userID"].ToString(), product_id, rating, descp);
                    if (result == 0)
                        Response.Write("<script>alert('You have already reviewed this product')</script>");
                    else
                    {
                        Response.Write("<script>alert('Your Review has been submitted ! Thank you :)')</script>");
                        string avg = controlObj.AVG_AllProductReviews(product_id).Rows[0][0].ToString();
                        controlObj.UpdateProductRating(product_id, avg);
                        d1.Visible = false;
                        t1.Visible = false;
                        Label l1 = GridView1.Rows[row].FindControl("Label7") as Label;
                        l1.Visible = false;
                        GridView1.DataBind();
                    }

                }
                
            }


        }
    }
}