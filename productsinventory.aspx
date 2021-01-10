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
              <!--------------------------- Product Info ------------------------------------------------->
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

                                    <asp:Button ID="Button2" runat="server" Text="Get Product" class="btn btn-primary btn-block" OnClick="Button2_Click" />
                                    <asp:Button ID="Button4" runat="server" Text="View All" class="btn btn-primary btn-block" OnClick="Button4_Click" />

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <!-------------------------------------End Product Info----------------------------------->

                     
                        <!-------------------------------------------------------------------------------------------->

                        <!-------------------------- Quality Control ------------------------------------------------------>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBoxPD" runat="server" TextMode="Multiline" placeholder="Product Description" ReadOnly="True"></asp:TextBox>
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
                                   <asp:Button ID="Button10" runat="server" Text="View Product Description" class="btn btn-success btn-block" OnClick="Button10_Click" />
                                    <asp:Button ID="Button1" runat="server" Text="Approve" class="btn btn-success btn-block" OnClick="Button1_Click" />
                                    <asp:Button ID="Button9" runat="server" Text="Disapprove" class="btn btn-success btn-block" OnClick="Button9_Click" />
                                    
                                    <asp:Button ID="Button8" runat="server" Text="View Approved" class="btn btn-success btn-block" OnClick="Button8_Click" />
                                    <asp:Button ID="Button20" runat="server" Text="View Disapproved" class="btn btn-success btn-block" OnClick="Button20_Click" />
                                    <asp:Button ID="Button11" runat="server" Text="View All Pending Products" class="btn btn-success btn-block" OnClick="Button11_Click" />
                                </div>
                            </div>
                        </div>
                       <!----------------------------------End of product inventory--------------------------------------------------------------->

                        <!---------------------------------------------WareHouse Branches and Location---------------------------------------------------------------->
                        <hr />
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-danger">WareHouses Branches & Locations</label>
                            </div>
                                <br />

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Product ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" TextMode="Number" placeholder="Product ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Quantity</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Number" placeholder="Product Quantity"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>WareHouse ID</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Number" placeholder="WareHouse ID" ></asp:TextBox>
                                </div>
                            </div>
                            

                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="Button5" runat="server" Text="Insert Product in WareHouse" class="btn btn-danger btn-block" OnClick="Button5_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Warehouse Name</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" TextMode="SingleLine" placeholder="WareHouse Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Warehouse Location</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" TextMode="SingleLine" placeholder="WareHouse Location"></asp:TextBox>
                                </div>
                            </div>
                            

                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="Button6" runat="server" Text="Insert new WareHouse" class="btn btn-danger btn-block" OnClick="Button6_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                 
                                       <div class="row">
                                           <!-------------------------------------->
                                           <div class="col-md-3">
                                               <div class="form-group">
                                                   <label>Product ID</label>
                                                   <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" TextMode="Singleline" placeholder="Product ID"></asp:TextBox>
                                               </div>
                                           </div>
                                           <div class="col-md-3">
                                               <div class="form-group">
                                                   <label>WareHouse ID</label>
                                                   <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" TextMode="Singleline" placeholder="WareHouse ID"></asp:TextBox>
                                               </div>
                                           </div>
                                           <div class="col-md-2">
                                               <div class="form-group">
                                                   <label>Quantity</label>
                                                   <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" TextMode="Singleline" placeholder="Quantity" ReadOnly="True"></asp:TextBox>
                                               </div>
                                           </div>
                                           <div class="col-md-4">
                                               <div class="form-group">
                                                   <label></label>
                                                   <asp:Button ID="Button7" runat="server" Text="Get Product Quantity" class="btn btn-danger btn-block" OnClick="Button7_Click" />
                                                </div>
                                           </div>
                                       </div>
                                <!----------------===============================================================================-->
                                
                                <!--------------------==================================================------------------------------->
                                <div class="form-group">
                                   
                                    <asp:Button ID="Button3" runat="server" Text="View All Products" class="btn btn-danger btn-block" OnClick="Button3_Click" />
                                    
                                </div>
                            </div>
                        </div>
                        <!---------------------------------------------WareHouse Branches and Location-------------------------------------------------->
                         
                        
                    </div>
                </div>
            </div>

                                      <!-------------- Products Datatable Section ----------------------------------->
           

            <div class="col-md-7">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <h6>Product & WareHouse Details</h6>
                                    
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
                        
                        

                        <div class="row">     <!------------------------------        Grid View ---------------------------------->
                            <div class="col">
                                <div class="form-group">
                                    <asp:GridView Cssclass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource3" >
                           <Columns>
                              <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" SortExpression="ProductID" >
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid1" style="text-align:left">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Category - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Category") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;
                                                   <span>
                                                      Size -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Size") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Price -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Price") %>'></asp:Label>
                                                   &nbsp;| Rating -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Rating") %>'></asp:Label>
                                                   &nbsp;| Quantity -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("quantity") %>'></asp:Label>
                                                   &nbsp;| Quality -
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("QualityStatus") %>'></asp:Label>
                                                </div>
                                             </div>
                                             
                                             <div class="row">
                                                <div class="col-12">
                                                   Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("Description") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("prodImg") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                        </asp:GridView>

                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>"  SelectCommand="SELECT [ProductID], [ProductName], [Description], [Category], [Size], [Price], [Rating], [quantity], [prodImg], [Seller], [QualityStatus] FROM [Products] WHERE ([Seller] = @Seller)">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="Seller" SessionField="userID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>

                                </div>
                            </div>
                        </div>
            <!----------------------------------------------- Products Datatable Section -------------------------------------->

            <!---------------------------------------------WareHouse Branches and Location-------------------->
        </div>
     <hr />
 

    
 
    <hr />
        </div>
   
      
        </div>

</asp:Content>
