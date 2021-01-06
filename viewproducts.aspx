<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="viewproducts.aspx.cs" Inherits="DatabaseProject.viewproducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <!--   Featured products-->
        <div class="small-container">
            <div class="row2 row-2">
            <h2 >All Products</h2>
            <select>
                 <option>Default Sorting</option>
                 <option>Sort by price</option>
                 <option>Sort by popularity</option>
                 <option>Sort by rating</option>
                 <option>Sort by sale</option>
            </select>
                </div>
            <div class="row2">
                <div class="col-4">   
                    <img src="imgs/product-1.jpg"/>  
                    <h4>Red Printed T-shirt</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                    <asp:Button ID="Button1" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-2.jpg"/>  
                    <h4>Black Shoes</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button2" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-3.jpg"/>  
                    <h4>Grey Sweatpants</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button3" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-4.jpg"/>  
                    <h4>Navy T-shirt</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-half-o" ></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button4" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                

            </div>
              <div class="row2">
                <div class="col-4">   
                    <img src="imgs/product-11.jpg"/>  
                    <h4>Nike Air Force</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button5" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-11.jpg"/>  
                    <h4>Grey Shoes</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button6" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-6.jpg"/>  
                    <h4>Black T-shirt</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button7" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-7.jpg"/>  
                    <h4>Socks</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-half-o" ></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button8" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="row2">
                <div class="col-4">   
                    <img src="imgs/product-8.jpg"/>  
                    <h4>Fossil Watch</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button9" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-9.jpg"/>  
                    <h4>Roadster Watch</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button10" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-10.jpg"/>  
                    <h4>Black Shoes</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-o" aria-hidden="false"></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button11" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                <div class="col-4">   
                    <img src="imgs/product-12.jpg"/>  
                    <h4>Black Sweatpants</h4>
                     <div class="rating">
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star" ></i>
                         <i class="fa fa-star-half-o" ></i>

                     </div>
                    <p>$50.00</p>
                      <asp:Button ID="Button12" runat="server" Text="Buy Now &#8594;" class="btn btn-success btn-block" style="background-color:#e73538; border-color: #fff;"/>
                </div>
                

            </div>
              </div>    
            <div class="page-btn">
                  <span>1</span>
                  <span>2</span>
                  <span>3</span>
                  <span>4</span>
                <span>&#8594;</span>
            </div>
            </div>

</asp:Content>
