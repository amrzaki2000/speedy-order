<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminmanagement.aspx.cs" Inherits="DatabaseProject.adminmanagement" %>

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
                                    <img style="width:100px;" src="imgs/customer.png" />
                            </div>
                                </center>
                        </div>
                        <!------------------------------------ Upper Section ------------------------------------------------->

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Customer Management</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
               <!-------------------------------------------------------------------------------------------->
              <!--------------------------- Customers Info ------------------------------------------------->
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-primary">Customers Info</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Customer ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Number" placeholder="Customer ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:Button ID="Button2" runat="server" Text="Get Customer" class="btn btn-primary btn-block" />
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

                        <!------------------------------- Ban Customers --------------------------------------------->

                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-danger">Ban Customers</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Customer ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="Number" placeholder="Customer ID"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="Button3" runat="server" Text="Ban Customer" class="btn btn-danger btn-block" />
                                    <asp:Button ID="Button5" runat="server" Text="View Banned" class="btn btn-danger btn-block" />
                                    <asp:Button ID="Button6" runat="server" Text="Unban Customer" class="btn btn-danger btn-block" />
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Reason of Suspension</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" TextMode="Multiline" placeholder="Describe the reason to the customer"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <hr />
                                </div>
                            </div>
                        </div>
                        <!-------------------------------------------------------------------------------------------->

                        <!-------------------------- Promo Codes ------------------------------------------------------>
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-success">Promo Codes</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Promo ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" TextMode="Number" placeholder="Promo ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Discount</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Discount Percentage"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button1" runat="server" Text="Add Promo" class="btn btn-success btn-block" />
                                    <asp:Button ID="Button9" runat="server" Text="Update Promo" class="btn btn-success btn-block" />
                                    <asp:Button ID="Button8" runat="server" Text="Delete Promo" class="btn btn-success btn-block" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Customer ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Number" placeholder="CustomerID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Promo ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Number" placeholder="Promo Code"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button7" runat="server" Text="Grant Promo" class="btn btn-success btn-block" />
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
                                    <h6>Customers Details</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-stripped table-bordered table-hover" ID="CustomerGridView" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Promos Details</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-stripped table-bordered table-hover" ID="PromoGridView" runat="server"></asp:GridView>
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

     <div class="row">
         <div class="col-md-5">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                            <div class="col">
                                    <img style="width:100px;" src="imgs/seller.png" />
                            </div>
                                </center>
                        </div>
                        <!------------------------------------ Upper Section ------------------------------------------------->

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Seller Management</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
               <!-------------------------------------------------------------------------------------------->
              <!--------------------------- Sellers Info ------------------------------------------------->
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-primary">Sellers Info</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Seller ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" TextMode="Number" placeholder="Seller ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:Button ID="Button10" runat="server" Text="Get Seller" class="btn btn-primary btn-block" />
                                    <asp:Button ID="Button11" runat="server" Text="View All" class="btn btn-primary btn-block" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <!-------------------------------------End Sellers Info----------------------------------->

                        <!------------------------------- Ban Sellers --------------------------------------------->

                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-danger">Ban Sellers</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Seller ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" TextMode="Number" placeholder="Seller ID"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="Button12" runat="server" Text="Ban Seller" class="btn btn-danger btn-block" />
                                    <asp:Button ID="Button13" runat="server" Text="View Banned" class="btn btn-danger btn-block" />
                                    <asp:Button ID="Button14" runat="server" Text="Unban Seller" class="btn btn-danger btn-block" />
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Reason of Suspension</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" TextMode="Multiline" placeholder="Describe the reason to the seller"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
         <div class="col-md-6">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                <center>
                                    <h6>Sellers Details</h6>
                                    </center>
                                    </div>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-stripped table-bordered table-hover" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            

     </div>
    </div>
   <!--------------------------------- End Seller Management Section ---------------------------------->
    <hr />

    <!----------------------------------------- Order Details ---------------------------------------->
        <div class="row">
         <div class="col-md-5">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                            <div class="col">
                                    <img style="width:100px;" src="imgs/promo.png" />
                            </div>
                                </center>
                        </div>
                        <!------------------------------------ Upper Section ------------------------------------------------->

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Order Info.</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
               <!-------------------------------------------------------------------------------------------->
              <!--------------------------- Sellers Info ------------------------------------------------->

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Order ID</label>
                                   
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" TextMode="Number" placeholder="Order ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                      <asp:Button ID="Button20" runat="server" Text="Get Order" class="btn btn-primary btn-block" />

                                     <asp:Button ID="Button16" runat="server" Text="View All" class="btn btn-primary btn-block" />
                                </div>
                            </div>
                        </div>
 
                    </div>
                </div>
            </div>
         <div class="col-md-6">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                <center>
                                    <h6>Orders Details</h6>
                                    </center>
                                    </div>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-stripped table-bordered table-hover" ID="OrdersGridView" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            

     </div>
    </div>
</asp:Content>
