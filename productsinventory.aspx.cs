using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DatabaseProject
{
    public partial class productsinventory : System.Web.UI.Page
    {
        Controller controlObj;
        InputValidation val;
        protected void Page_Load(object sender, EventArgs e)
        {
            controlObj = new Controller();              //Creating Controller Object
            val = new InputValidation();
            GridView1.DataBind();
            GridView1.Visible = false;
        }

        

        /*
        public void addProduct()
        {
            
            string name = TextBox6.Text.Trim();
           
            string quantity = TextBox13.Text.Trim();
            

            if (val.Checkblank(filename, name, price.ToString(), color, Size, quantity.ToString(), category, Description))
                Response.Write("<script>alert('Please do not leave any blank spaces')</script>");
            else if (!(val.isPositive(int.Parse(price)) && val.isPositive(int.Parse(quantity))))
                Response.Write("<script>alert('Please enter valid quantity and price')</script>");
            else
            {
                string filepath = "~/imgs/Products/" + filename;
                FileUpload1.SaveAs(Server.MapPath(filepath));
                DataTable dt = controlObj.GetSellerID(Session["username"].ToString());
                if (dt != null)
                {
                    int result = controlObj.InsertProd(name, Description, color, category, Size, price, "0", quantity, "null", "Pending Approval", dt.Rows[0][0].ToString(), filepath);
                    if (result != 0)
                        Response.Write("<script>alert('Product Inserted Successfully')</script>");
                    else
                        Response.Write("<script>alert('There was a problem inserting the product')</script>");
                }
                else
                    Response.Write("<script>alert('Seller ID not found in the database')</script>");
            }

        }*/

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ProductGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //================================================================================================= Product Info========================
        protected void Button2_Click(object sender, EventArgs e)  // get product 
        {
            /* public void GetProduct(string id)
             {
                 DataTable dt = controlObj.GetProduct(id);
                 if (dt == null)
                 {
                     Response.Write("<script>alert('Please enter a valid id')</script>");
                 }
             }*/
            string id = TextBox1.Text.Trim();
            DataTable dt = controlObj.GetProduct(id);
            if (dt == null)
            {
                Response.Write("<script>alert('Please enter a valid id')</script>");
            }
            else
            {
               
                GridView1.Visible = true;
                SqlDataSource3.SelectCommand = "SELECT * FROM Products WHERE ProductID = " + id + ";";
                GridView1.DataBind();
            }

        }

        protected void Button4_Click(object sender, EventArgs e)    //view all products
        {
            GridView1.Visible = true;
            SqlDataSource3.SelectCommand = "SELECT * FROM Products ;";
            GridView1.DataBind();
        }
        //================================================================================================= Quality Control========================

        protected void Button11_Click(object sender, EventArgs e) // view all pending
        {
            SqlDataSource3.SelectCommand = "SELECT * FROM Products WHERE QualityStatus = 'Pending' OR QualityStatus = 'pending' ;";
        }
        protected void Button20_Click(object sender, EventArgs e) // view disapproved
        {
            SqlDataSource3.SelectCommand = "SELECT * FROM Products WHERE QualityStatus = 'Disapproved' OR QualityStatus = 'disapproved' ;";

        }
        protected void Button8_Click(object sender, EventArgs e) // view approved
        {
            SqlDataSource3.SelectCommand = "SELECT * FROM Products WHERE QualityStatus = 'Approved' OR QualityStatus = 'approved' ;";

        }
        protected void Button10_Click(object sender, EventArgs e) //view product description
        {
            string prodid=TextBox2.Text.Trim();
            if (prodid.Length == 0 || (Int32.Parse(prodid) < 0) )
            {
                Response.Write("<script>alert('Please enter a valid id')</script>");
            }
            else
            {
                DataTable dt = controlObj.GetProduct(prodid);
                if(dt==null)
                {
                    Response.Write("<script>alert('No products found')</script>");
                }
                else
                {
                    string prodDescription= dt.Rows[0][2].ToString();
                    TextBoxPD.Text = prodDescription;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e) //approve
        {
            string prodid = TextBox2.Text.Trim();
            string adminid = TextBox4.Text.Trim();
            
            if (prodid.Length == 0 || adminid.Length == 0 || (Int32.Parse(adminid) < 0) || (Int32.Parse(prodid) < 0) )
            {
                Response.Write("<script>alert('Please enter valid Product and Admin IDs')</script>");
            }
            else
            {
                int result = controlObj.UpdateQualityStatus(prodid, "Approved", adminid);
                if (result==0)
                {
                    Response.Write("<script>alert('Update Failed')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Updated Successfuly')</script>");
                }
            }
        }
        protected void Button9_Click(object sender, EventArgs e) //Disapprove
        {
            string prodid = TextBox2.Text.Trim();
            string adminid = TextBox4.Text.Trim();

            if (prodid.Length == 0 || adminid.Length == 0 || (Int32.Parse(adminid) < 0) || (Int32.Parse(prodid) < 0))
            {
                Response.Write("<script>alert('Please enter valid Product and Admin IDs')</script>");
            }
            else
            {
                int result = controlObj.UpdateQualityStatus(prodid, "Disapproved", adminid);
                if (result == 0)
                {
                    Response.Write("<script>alert('Update Failed')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Updated Successfuly')</script>");
                }
            }
        }

        //===================================================================================  WareHouse     ================================

        protected void insertproductinwarehouse()
        {
            string quantity3 = "a";
            string productid = TextBox3.Text.Trim();
            quantity3 = TextBox5.Text.Trim();
            string warehouseid = TextBox6.Text.Trim();

            DataTable dt2 = controlObj.checkforproductidExcistance(productid);
            DataTable dt3 = controlObj.checkforwarehouseExcistance(warehouseid);

            if (productid.Length == 0 || quantity3.Length == 0 || warehouseid.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }


            else if (dt2 == null)
                Response.Write("<script>alert('productid not exists.')</script>");
            else if (dt3 == null)
                Response.Write("<script>alert('warehouse not exists.')</script>");
            else
            {

                DataTable dt = controlObj.getquantityofproduct(productid);
                DataTable dt1 = controlObj.getquantityofProductofwarehouses(productid);

                string quantity1 = "a";
                quantity1 = dt.Rows[0][0].ToString();
                int quantity1i = Int32.Parse(quantity1);
                int quantity2i;

                if (dt1 == null)
                {
                    quantity2i = 0;
                }
                else
                {
                    string quantity2 = "a";
                    quantity2 = dt1.Rows[0][0].ToString();
                    quantity2i = Int32.Parse(quantity2);
                }
                int sum1 = quantity1i - quantity2i;
                int sum2 = sum1 - Int32.Parse(quantity3);

                if (sum2 <= 0)
                {
                    Response.Write("<script>alert('Quantity is too large.')</script>");
                }

                else
                {
                    int result;

                    result = controlObj.insertproductinwarehouse(productid, warehouseid, quantity3);

                    if (result == 0)

                        Response.Write("<script>alert('Insert process was interrupted')</script>");
                    else
                    {

                        Response.Write("<script>alert('Insert process successded')</script>");

                    }
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)   //insert pnew warehouse
        {
            
            string warehouseName = TextBox13.Text.Trim();
            string warehouseLocation = TextBox14.Text.Trim();
            //string warehouseid = TextBox6.Text.Trim();
            if (warehouseName.Length == 0 || warehouseLocation.Length == 0 )
            {
                Response.Write("<script>alert('Please fill in all requirments')</script>");
            }
            
            else
            {
                int result = controlObj.Insertwarehouse(warehouseName, warehouseLocation);
                if(result==0)
                {
                    Response.Write("<script>alert('Insertion Failed')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Warehouse is inserted successfuly')</script>");
                }
            }



            
        }

        protected void Button5_Click(object sender, EventArgs e) // insert prod in warehouse
        {
            insertproductinwarehouse();
        }
        protected int getquantitytproductinwarehouse()
        {
            string productid = TextBox8.Text.Trim();
            string warehouseid = TextBox11.Text.Trim();
            int quantity;

            DataTable dt2 = controlObj.checkforproductidExcistance(productid);
            DataTable dt3 = controlObj.checkforwarehouseExcistance(warehouseid);
            if (productid.Length == 0 || warehouseid.Length == 0)
            {
                Response.Write("<script>alert('Please do not leave any blank fields')</script>");
            }
            else if (dt2 == null)
                Response.Write("<script>alert('productid not exists.')</script>");
            else if (dt3 == null)
                Response.Write("<script>alert('warehouse not exists.')</script>");
            else
            {

                DataTable result = controlObj.getquantityofProductofwarehouse(productid, warehouseid);
                if (result == null)
                {
                    Response.Write("<script>alert('Error')</script>");
                }
                else
                {

                    string quantity1 = "a";
                    quantity1 = result.Rows[0][0].ToString();
                    int quantity1i = Int32.Parse(quantity1);

                    return quantity1i;

                }


            }
            return 0;

        }
        protected void Button7_Click(object sender, EventArgs e) //get product quantity
        {
            int ans = getquantitytproductinwarehouse();
            TextBox7.Text = ans.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)  //view all products
        {
            SqlDataSource3.SelectCommand = "SELECT * FROM WarehouseProducts ;";
        }

        
    }
}