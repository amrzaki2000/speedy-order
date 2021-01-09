<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="SellerProfile.aspx.cs" Inherits="DatabaseProject.SellerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });

      function readURL(input) {
          if (input.files && input.files[0]) {
              var reader = new FileReader();

              reader.onload = function (e) {
                  $('#imgview').attr('src', e.target.result);
              };

              reader.readAsDataURL(input.files[0]);
          }
      }

  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">

            <div class="col-md-6">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">
                            <center>
                            <div class="col">
                                    <img style="width:100px"  src="imgs/Seller.png" />
                            </div>
                                </center>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <br />
                                    <h6>Greetings to our beloved Seller</h6>
                                    <span>Account Status - </span>
                                    <asp:Label CssClass="badge badge-pill badge-success" ID="Label2" runat="server" Text="Label">Active</asp:Label>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <br />
                                    <label>Rating - </label>
                                    <asp:Label class="badge badge-pill badge-danger" ID="Label1" runat="server" Text="Label"></asp:Label>
                                    </center>
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
                                <div class="'form-group">
                                    <label class="badge badge-pill badge-success">Profile Information</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="First Name"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Last Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Address" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col">
                                <label class="badge badge-pill badge-info">Login Credentials</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Username"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button1" runat="server" Text="Update" class="btn btn-success btn-block" OnClick="Button1_Click" />
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
                                <div class="'form-group">
                                    <label class="badge badge-pill badge-warning">Appeal to an Admin</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" TextMode="MultiLine" runat="server" placeholder="Write your Appeal"> </asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox28" TextMode="MultiLine" runat="server" placeholder="Reason of Suspension" Disabled="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <div class="row">
                        <div class="col-md-12">
                                <div class="form-group">
                                    <label>View my appeal Status</label>
                                    <asp:TextBox ID="TextBox23" runat="server" placeholder="None" Disabled="true"></asp:TextBox>
                                </div>
                            </div>
                    </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button2" runat="server" Text="Appeal" class="btn btn-warning "  />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <center>
                                    <h5>Statistics</h5>
                                        </center>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <center>
                            <div class="col">
                                    <img style="width:150px"  src="imgs/stats.png" />
                            </div>
                                </center>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <hr />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Total Income</label>
                                         <asp:TextBox ID="TextBox25" runat="server" placeholder="Income" Disabled="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label style="display:block">Total Profit</label>
                                         <asp:TextBox ID="TextBox26" runat="server" placeholder="Profit" Disabled="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label>Total Sold Products</label>
                                         <asp:TextBox ID="TextBox27" runat="server" placeholder="sold" Disabled="true"></asp:TextBox>
                                    </div>
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
                                    <h6>Product Management
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-O1R2Q0Q\SQLEXPRESS01;Initial Catalog=SpeedyOrder2;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>
                                    </h6>
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
                                    <label>Products Details</label>
                                </div>
                            </div>
                        </div>
                        

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource3" >
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

                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedyOrderConnectionString %>" SelectCommand="SELECT [ProductID], [ProductName], [Description], [Category], [Size], [Price], [Rating], [quantity], [prodImg], [Seller], [QualityStatus] FROM [Products] WHERE ([Seller] = @Seller)">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="Seller" SessionField="userID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>

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
                                    <asp:Button ID="Button3" runat="server" Text="View my Products" class="btn btn-primary btn-block" OnClick="Button3_Click1" />
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
                                    <label class="badge badge-pill badge-secondary">Adding Products</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <img id="imgview" height="150px" width="150px" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" onchange="readURL(this)" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" runat="server" placeholder="Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox11" runat="server" placeholder="Price" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Product Color</label>
                                    <asp:TextBox ID="TextBox12" runat="server" placeholder="Color" TextMode="Color"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Size</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>XS</asp:ListItem>
                                        <asp:ListItem>S</asp:ListItem>
                                        <asp:ListItem>M</asp:ListItem>
                                        <asp:ListItem>L</asp:ListItem>
                                        <asp:ListItem>XL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Quantity</label>
                                    <asp:TextBox ID="TextBox13" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Category</label>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem>T-shirts</asp:ListItem>
                                        <asp:ListItem>Shoes</asp:ListItem>
                                        <asp:ListItem>Trousers</asp:ListItem>
                                        <asp:ListItem>Socks</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox15" runat="server" placeholder="Description" TextMode="Multiline" Rows="5" Columns="30"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button4" runat="server" Text="Add my Product" class="btn btn-secondary btn-block" OnClick="Button4_Click" />
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
                                    <label class="badge badge-pill badge-info">Updating Products</label>
                                </div>
                            </div>
                        </div>
                        <!------------------------------- Products Update -------------------------------------------------------->
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Select a Product from the viewed table above </label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <img id="imgview" height="150px" width="150px" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:FileUpload ID="FileUpload2" CssClass="form-control" onchange="readURL(this)" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Products IDs</label>
                                    <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox14" runat="server" placeholder="Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox16" runat="server" placeholder="Price" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Product Color</label>
                                    <asp:TextBox ID="TextBox17" runat="server" placeholder="Color" TextMode="Color"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Size</label>
                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                        <asp:ListItem>XS</asp:ListItem>
                                        <asp:ListItem>S</asp:ListItem>
                                        <asp:ListItem>M</asp:ListItem>
                                        <asp:ListItem>L</asp:ListItem>
                                        <asp:ListItem>XL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Quantity</label>
                                    <asp:TextBox ID="TextBox18" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Category</label>
                                    <asp:DropDownList ID="DropDownList4" runat="server">
                                        <asp:ListItem>T-shirts</asp:ListItem>
                                        <asp:ListItem>Shoes</asp:ListItem>
                                        <asp:ListItem>Trousers</asp:ListItem>
                                        <asp:ListItem>Socks</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox19" runat="server" placeholder="Description" TextMode="Multiline" Rows="5" Columns="30"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button5" runat="server" Text="Update my Product" class="btn btn-info btn-block" />
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
                                    <label class="badge badge-pill badge-danger">Deleteing Products</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Select a Product from the viewed table above </label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <label>Product ID</label>
                                    <asp:TextBox ID="TextBox24" runat="server" TextMode="Number" placeholder="Product ID"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button6" runat="server" Text="Delete my Product" class="btn btn-danger btn-block" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        

    </div>
    
</asp:Content>
