<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="memberSignup.aspx.cs" Inherits="DatabaseProject.memberSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-10">
                <div class="card" style="margin-bottom: 10px; border-radius:5%; ">
                    <div class="card-body">
                        <div class="row">
                            <center>
                            <div class="col">
                                    <img src="imgs/user.png" />
                            </div>
                                </center>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Member Sign-Up</h6>
                                    </center>
                            </div>
                        </div>
                        <hr>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Username"></asp:TextBox>
                                </div>     

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>                            

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                </div>                            
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" MaxLength="11" runat="server" placeholder="Phone Number" TextMode="Number"></asp:TextBox>
                                </div>                            

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Address" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                </div>                            
                            </div>
                             <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>                            
                            </div>
                              <div class="col-md-6">
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Select Type" Value="Type"></asp:ListItem>
                                        <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                                        <asp:ListItem Text="Seller" Value="Seller"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>                            
                            </div>
                        </div>
                          <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button1" runat="server" Text="Sign up" class="btn btn-primary btn-block" OnClick="Button1_Click"/>
                                </div>                            
                            </div>
                        </div>
                           <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Already a Member ?</label>
                                </div>                            
                            </div>
                               <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="Button2" runat="server" Text="Log in" class="btn btn-success btn-block" OnClick="Button2_Click"/>
                                </div>                            
                            </div>

                        </div>
                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
