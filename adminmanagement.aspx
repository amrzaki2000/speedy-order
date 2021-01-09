<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminmanagement.aspx.cs" Inherits="DatabaseProject.adminmanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!--------------------------------------- Profile Informaion --------------------------------------------------->
        <div class="row">
            <div class="col-md-6">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                            <div class="col">
                                    <img src="imgs/admin.png" />
                            </div>
                                </center>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <center>
                                    <h6>Greetings to our beloved Admin</h6>
                                    </center>
                                </div>
                                
                            </div>
                        </div>

                        <hr/>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Phone Number"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Address" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox16" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                      <label class="badge badge-pill badge-info">Login Credentials</label>
                              </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server" placeholder="Username" TextMode="Password"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox19" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button15" runat="server" Text="Update" class="btn btn-success btn-block" />
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
                                    <h6>Admins and Customer Service Management</h6>
                                    </center>
                                </div>
                                
                            </div>
                        </div>

                        <hr/>


                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label class="badge badge-pill badge-danger">Admin management</label>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminfirst" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminlast" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminphone" runat="server" placeholder="Phone Number"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminaddress" runat="server" placeholder="Address" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminemail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminsalary" runat="server" placeholder="Salary" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                      <label class="badge badge-pill badge-info">Login Credentials</label>
                              </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminusername" runat="server" placeholder="Username"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="adminpass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Insertadmin" runat="server" Text="Insert Admin" class="btn btn-danger btn-block" />
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
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                   <label class="badge badge-pill badge-primary">Customer Service Management</label>
                                </div>
                                
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservicefirst" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservicelast" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservicephone" runat="server" placeholder="Phone Number"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cserviceaddress" runat="server" placeholder="Address" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cserviceemail" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservicesalary" runat="server" placeholder="Salary" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservice_supervisor" runat="server"  placeholder="Supervisor Username"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservicehours" runat="server" placeholder="Working Hours" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                      <label class="badge badge-pill badge-info">Login Credentials</label>
                              </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservice_username" runat="server" placeholder="Username"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="cservice_pass" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="add_cs" runat="server" Text="Insert Customer Service Employee" class="btn btn-primary btn-block" />
                                </div>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>






        <!-------------------------------------- End Profile Information ------------------------------------------------>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <hr />
                </div>
            </div>
        </div>


        <!-------------------------------------------- Customers Management Section ------------------------------------------>

        <div class="row">
            <div class="col-md-6">
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
                                    <label>Customer Username</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="SingleLine" placeholder="Customer Username"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:Button ID="Button2" runat="server" Text="Get Customer" class="btn btn-primary btn-block" OnClick="Button2_Click" />
                                    <asp:Button ID="Button4" runat="server" Text="View All" class="btn btn-primary btn-block" OnClick="Button4_Click" />

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
                                    <label>Customer Username</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="SingleLine" placeholder="Customer Username"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="Button3" runat="server" Text="Ban Customer" class="btn btn-danger btn-block" OnClick="Button3_Click" />
                                    <asp:Button ID="Button5" runat="server" Text="View Banned Customers" class="btn btn-danger btn-block" OnClick="Button5_Click" />
                                    <asp:Button ID="Button6" runat="server" Text="Unban Customer" class="btn btn-danger btn-block" OnClick="Button6_Click" />
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
                                    <label>Seller Username</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Seller Username"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">

                                    <asp:Button ID="Button10" runat="server" Text="Get Seller" class="btn btn-primary btn-block" OnClick="Button10_Click" />
                                    <asp:Button ID="Button11" runat="server" Text="View All" class="btn btn-primary btn-block" OnClick="Button11_Click" />

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
                                    <label>Seller Username</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" TextMode="SingleLine" placeholder="Seller Username"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="Button12" runat="server" Text="Ban Seller" class="btn btn-danger btn-block" OnClick="Button12_Click" />
                                    <asp:Button ID="Button13" runat="server" Text="View Banned Sellers" class="btn btn-danger btn-block" OnClick="Button13_Click" />
                                    <asp:Button ID="Button14" runat="server" Text="Unban Seller" class="btn btn-danger btn-block" OnClick="Button14_Click" />
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
              <!--------------------------- Orders Info ------------------------------------------------->

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Order ID</label>
                                   
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" TextMode="Number" placeholder="Order ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                      <asp:Button ID="Button20" runat="server" Text="Get Order" class="btn btn-primary btn-block" OnClick="Button20_Click" />
                                     <asp:Button ID="Button16" runat="server" Text="View All" class="btn btn-primary btn-block" OnClick="Button16_Click" />
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
