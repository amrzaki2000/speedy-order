<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="DatabaseProject.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <!--Cart items details-->
    <div class="small-container cart-page">
        <table>
            <tr>
                <th>Product</th>
                <th>Quantity</th>
                <th>Subtotal</th>
            </tr>
            <tr>
                <td>
                    <div class="cart-info">
                         <img src="imgs/product-1.jpg" style="width: 80px; height: 80px; margin-right: 10px; "/>
                        <div>
                            <p>Red Printed T-shirt</p>
                            <small>Price: $50.00</small>
                            <br />
                            <a href="">Remove</a>
                        </div>
                    </div>
                </td>
                <td><input type="number" value="1"></td>
                <td>$50.00</td>
            </tr>
             <tr>
                <td>
                    <div class="cart-info">
                         <img src="imgs/product-3.jpg" style="width: 80px; height: 80px; margin-right: 10px; "/>
                        <div>
                            <p>Red Printed T-shirt</p>
                            <small>Price: $75.00</small>
                            <br />
                            <a href="">Remove</a>
                        </div>
                    </div>
                </td>
                <td><input type="number" value="1"></td>
                <td>$125.00</td>
            </tr>
             <tr>
                <td>
                    <div class="cart-info">
                         <img src="imgs/product-6.jpg" style="width: 80px; height: 80px; margin-right: 10px; "/>
                        <div>
                            <p>Red Printed T-shirt</p>
                            <small>Price: $68.00</small>
                            <br />
                            <a href="">Remove</a>
                        </div>
                    </div>
                </td>
                <td><input type="number" value="1"></td>
                <td>$193.00</td>
            </tr>
        </table>
        <div class="total-price">
            <table>
                <tr>
                    <td>Subtotal</td>
                    <td>$193.00</td>
                </tr>
                <tr>
                    <td>Shipping fees</td>
                    <td>$5.00</td>
                </tr>
                <tr>
                    <td>Total</td>
                    <td>$198.00</td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
