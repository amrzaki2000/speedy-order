<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="DatabaseProject.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <!--Cart items details-->
    <div class="small-container cart-page">
        <div class="row">
            <div class="col">
                <asp:GridView ID="GridView1" runat="server">

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
