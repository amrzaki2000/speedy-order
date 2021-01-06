<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="productsinventory.aspx.cs" Inherits="DatabaseProject.productsinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <!-------------------------------------------- Customers Management Section ------------------------------------------>

        <div class="row">
            <div class="col-md-5">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                            <div class="col">
                                    <img style="width:100px; height:70px" src="imgs/products.png" />
                            </div>
                                </center>
                        </div>
                        <!------------------------------------ Upper Section ------------------------------------------------->

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Products Management</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
               <!-------------------------------------------------------------------------------------------->
              <!--------------------------- Customers Info ------------------------------------------------->
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-primary">Products Info</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Product ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Number" placeholder="Product ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:Button ID="Button2" runat="server" Text="Get Product" class="btn btn-primary btn-block" />
                                    <asp:Button ID="Button4" runat="server" Text="View All" class="btn btn-primary btn-block" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <!-------------------------------------End Customers Info----------------------------------->

                        <!------------------------------- Ban Customers ------

                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-danger">Ban Products</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Product ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="Number" placeholder="Product ID"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="Button3" runat="server" Text="Ban Product" class="btn btn-danger btn-block" />
                                    <asp:Button ID="Button5" runat="server" Text="View Banned" class="btn btn-danger btn-block" />
                                    <asp:Button ID="Button6" runat="server" Text="Unban Product" class="btn btn-danger btn-block" />
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Reason of banning</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" TextMode="Multiline" placeholder="Describe the reason to the seller"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <hr />
                                </div>
                            </div>
                        </div>   --------------------------------------->
                        <!-------------------------------------------------------------------------------------------->

                        <!-------------------------- Promo Codes ------------------------------------------------------>
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-success">Quality Control</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Product ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Number" placeholder="Product ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Admin ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Admin ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Product Description</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBoxPD" runat="server" TextMode="Multiline" placeholder="Product Description"></asp:TextBox>
                                           </div>
                                 <div class="col-md-4">
                                     <div class="form-group">
                                     <label>Quality Status</label>
                                         </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBoxQS" runat="server" TextMode="Singleline" placeholder="Quality Status"></asp:TextBox>
                                    </div>
                                            </div>
                                <div class="form-group">
                                   
                                    <asp:Button ID="Button1" runat="server" Text="Approve" class="btn btn-success btn-block" />
                                    <asp:Button ID="Button9" runat="server" Text="Disapprove" class="btn btn-success btn-block" />
                                    
                                    <asp:Button ID="Button20" runat="server" Text="View Disapproved" class="btn btn-success btn-block" />
                                </div>
                            </div>
                        </div>
                       
                        
        <!---------------------------------------- End Promo Codes ------------------------------->

                    </div>
                </div>
            </div>

            <!-------------- Customer and Promos Datatable Section ----------------------------------->
            <div class="col-md-6">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Product Details</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-stripped table-bordered table-hover" ID="ProductGridView" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
                
            </div>
            <!----------------------------------------------- End Customers and Promos Datatable Section -------------------------------------->
        </div>
    <!----------------------------------------------- End of Customers Management Section ------------------------------------------------------->
        <!--------------------------------------------------------------------------------------------------------------------------------------->
        <hr />
        <!-------------------------------------------- Seller Management Section ---------------------------------------------->

    
   <!--------------------------------- End Seller Management Section ---------------------------------->
    <hr />

   
      
        </div>

</asp:Content>
