<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="DatabaseProject.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-10">
                <div class="card" style="margin-bottom: 10px;">
                    <div class="card-body">
                        <div class="row">
                            <div class="'col">
                                    <img src="imgs/user.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="'col">
                                    <h6>Login</h6>
                            </div>
                        </div>

                        <hr>
                        <div class="row">
                            <div class="'col">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="username" runat="server" placeholder="Username"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Password" TextMode="password"></asp:TextBox>
                                 </div>
                                  <div class="form-group">
                                      <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-success btn-block"/>
                                      <label style="margin: 10px">Not a member ? Join Us</label>
                                      <asp:Button ID="Button2" runat="server" Text="Sign up" class="btn btn-primary btn-block"/>
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
