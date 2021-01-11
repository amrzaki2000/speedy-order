<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="DatabaseProject.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <!--Cart items details-->
    <div class="small-container cart-page">
        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" CssClass="table table-striped " AutoGenerateColumns="False" runat="server" DataSourceID="SqlDataSource1">
                    <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="container-fluid1" style="text-align: left">
                                <div class="row">
                                   
                                    <div class="col-lg-2">
                                        <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("prodImg") %>' />
                                    </div>
                                    <div class="col-lg-2" style="text-align:center">
                                        <div class="form-group">

                                        <label class="badge badge-pill badge-primary" style="display:block">Quantity</label>
                                            <asp:Label ID="Label1" Font-Size="Large" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                                                </div>
                                        </div>
                                     <div class="col-lg-2" style="text-align:center">
                                        <div class="form-group">

                                        <label class="badge badge-pill badge-warning" style="display:block">Price per piece</label>
                                        <i class="fa fa-money-bill" style="color:lightgreen"></i>
                                            <asp:Label ID="Label3" runat="server" Font-Size="Large" Text='<%# Eval("price") %>'></asp:Label>
                                                </div>
                                        </div>
                                </div>
                                <div class="row">
                                    <div class="col-6">
                                    </div>
                                    <div class="col-4">
                                        <div class="form-group">
                                            <asp:Button ID="Button1" CssClass="btn btn-danger btn-block text-center" Font-Size="Small" runat="server" Text="Remove from cart"  OnCommand="Button1_Command" CommandArgument='<%# Container.DataItemIndex %>'/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                <hr style="border-top: solid 5px #151d54" />
                
                <div class="row">
                    <div class="col-6" style ="border-right:solid 5px #151d54">
                        <div class="form-group">
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-block btn-primary" runat="server" OnClick="LinkButton1_Click">Buy Now <i class="fa fa-arrow-right"></i></asp:LinkButton>
                            <br />
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox1" runat="server" placeholder ="Enter Promo Code"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-group">
                                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-block btn-success" runat="server" OnClick="LinkButton2_Click">Use Promo <i class="fa fa-gift"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label ID="Label7"  runat="server" Text="Products Price = "></asp:Label>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label ID="Label2" Font-Size="Large" CssClass="badge badge-pill badge-dark" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label ID="Label8"  runat="server" Text="Shipping Price = "></asp:Label>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label ID="Label4" Font-Size="Large" CssClass="badge badge-pill badge-dark" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label ID="Label9"  runat="server" Text="Discount = "></asp:Label>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:Label ID="Label5" Font-Size="Large" CssClass="badge badge-pill badge-dark" runat="server" Text="Label"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <hr style="border-top: solid 5px #151d54" />
                        <asp:Label ID="Label6" runat="server" Font-Size="Larger" Text="Label"></asp:Label>
                    </div>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" SelectCommand="SELECT * FROM [Incart] WHERE ([CustomerID] = @CustomerID)">
                    <SelectParameters>
                        <asp:SessionParameter Name="CustomerID" SessionField="userID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
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
