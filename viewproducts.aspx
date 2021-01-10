<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="viewproducts.aspx.cs" Inherits="DatabaseProject.viewproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--   Featured products-->
    <div class="container">
        <div class="row2 row-2">
            <h2>All Products</h2>
            <asp:GridView ID="GridView1" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="container-fluid1" style="text-align: left">
                                <div class="row">
                                    <div class="col-lg-10">
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <asp:Label ID="Label1" runat="server" CssClass="badge badge-pill badge-light" Text='<%# Eval("ProductName") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-6">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-success">Category</label>
                                                    <br />
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-warning">Size</label>
                                                    <br />
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Size") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-6">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-danger">Price</label>
                                                    <br />
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-primary">Rating</label>
                                                    <br />
                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Rating") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-success">Quantity</label>
                                                    <br />
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-info">Description</label>
                                                    <asp:Label ID="Label6" runat="server" CssClass="text-black-50 form-text font-italic" Text='<%# Eval("Description") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-6">
                                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" placeholder="Submit Your Review"></asp:TextBox>
                                            </div>
                                            <div class="col-6">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group">
                                                            <label class="badge badge-pill badge-secondary">Select Quantity</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group">
                                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" placeholder="Quantity"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="col">
                                                <div class="form-group">
                                                    <label class="badge badge-pill badge-success">Rating</label>
                                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-6">
                                                <div class="form-group">
                                                    <asp:Button ID="Button1"  CssClass="btn btn-warning btn-block" runat="server" Text="Submit Review" />
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="form-group">
                                                    <asp:Button ID="Button2" CssClass="btn btn-danger btn-block" runat="server" Text="Add to Cart" />
                                                </div>
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" SelectCommand="SELECT [ProductID], [ProductName], [Description] AS Description, [Color] AS Color, [Category] AS Category, [Size], [Price], [quantity], [Rating] AS Rating, [prodImg] FROM [Products]"></asp:SqlDataSource>
        </div>
        <script type="text/javascript">
            $(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                    "paging": true,
                    "lengthChange": true,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "responsive": true,

                });
            })
           </script>
</asp:Content>
