<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="stocksUpdate.aspx.cs" Inherits="Semester_4_Project_2.stocksUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        STOCKS UPDATE
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="supplierForm" class="form-label">Supplier ID</label>
                        <asp:TextBox ID="supplierIDForm" class="form-control" placeholder="Enter the supplier name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Stock Name</label>
                        <asp:TextBox ID="stockNameForm" class="form-control" placeholder="Enter the description"  runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Stock Price</label>
                        <asp:TextBox ID="stockPriceForm" class="form-control" placeholder="Enter the description"  runat="server"></asp:TextBox>
                    </div>
                    <div class="category">
                        <label for="DropDownCategory" class="form-label">Category</label>
                        <asp:DropDownList ID="ddlCat" runat="server"  placeholder="Choose the category">
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3 pt-3">
                        <label for="stockDescForm" class="form-label">Stock Description</label>
                        <asp:TextBox ID="stockDescForm" class="form-control" style="resize: none;" placeholder="Enter the address" TextMode="MultiLine" runat="server" Rows="3"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="">
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="btnUpdate" class="btn btn-primary button-yellow-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
                <table class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                <tr style="border-bottom:1px solid black;">
                <th>Product Name</th>
                <th>Description</th>
                <th>Product Name</th>
    
                <th>Product Name</th>
    
                <th>Product Name</th>
    
                <th>Product Name</th>

                <th>Product Name</th>
    
                
                </tr>
                    <td>Contoh1</td>
                    <td>Contoh2</td>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>Contoh1</td>
                            <td>Contoh2</td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
