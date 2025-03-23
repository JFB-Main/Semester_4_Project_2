<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="stocksControl.aspx.cs" Inherits="Semester_4_Project_2.stocksControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        STOCKS CONTROL
                    </h2>
                </div>
                <div>
                    <div class="category">
                        <label for="DropDownSupplier" class="form-label">Supplier Name</label>
                       <asp:DropDownList ID="ddlsup" runat="server"  placeholder="Choose the Supplier">
                       </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Stock Name</label>
                        <asp:TextBox ID="stockNameForm" class="form-control" placeholder="Enter the description"  runat="server"></asp:TextBox>
                    </div>
                    
                    <div class="category">
                        <label for="DropDownCategory" class="form-label">Category</label>
                        <asp:DropDownList ID="ddlCat" runat="server"  placeholder="Choose the category">
                        </asp:DropDownList>
                    </div>
                 </div>
            </div>
            <div class="mb-3">
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-primary button-yellow-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
            <table class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                <tr style="border-bottom:1px solid black;">
                    <th>Stock Name</th>
                    <th>Price</th>
                    <th>Category</th>
                    <th>Stock Amount</th>
                    <th>Description</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("stock_name") %></td>
                            <td><%# Eval("stock_price", "{0:C}") %></td>
                            <td><%# Eval("category_name") %></td>
                            <td><%# Eval("stock_amount") %></td>
                            <td><%# Eval("description") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
