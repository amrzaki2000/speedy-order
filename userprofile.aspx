<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="DatabaseProject.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
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
                                    <h6>Welcome Back</h6>
                                    <span>Account Status - </span>
                                    <label class="badge badge-pill badge-success">Active</label>
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <span>Points - </span>
                                    <label class="badge badge-pill badge-warning">0</label>
                                    </center>
                            </div>
                        </div>

                        <hr/>


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
                                <center>
                                      <label class="badge badge-pill badge-info">Login Credentials</label>
                              </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Username" TextMode="Singleline"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Old Password" TextMode="Password"></asp:TextBox>
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
                                <div class="'form-group">
                                <center>
                                      <label class="badge badge-pill badge-warning">Appeal to an Admin</label>
                              </center>
                                    </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" TextMode="MultiLine" runat="server" placeholder="Write your Appeal" Rows="2"></asp:TextBox>
                                    
                                </div>
                            </div>
                               <div class="col-md-6">
                                <div class="form-group">
                                    <label>View my appeal Status</label>
                                    <asp:TextBox ID="TextBox23" runat="server" placeholder="None" Disabled="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="Button2" runat="server" Text="Appeal" class="btn btn-warning btn-block" OnClick="Button2_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card" style="margin: 10px 0 10px 0; border-radius: 5%;">
                    <div class="card-body">
                        <div class="row">

                            <div class="col">
                                <center>
                                    <img style="width:100px;" src="imgs/shopping-bag.png" />
                                    </center>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h6>Your Products</h6>
                                    </center>
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
    </div>
</asp:Content>
