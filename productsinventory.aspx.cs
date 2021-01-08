using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


namespace DatabaseProject
{
    public partial class productsinventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ProductGridView.DataBind();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ProductGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}