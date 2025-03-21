<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="supplierHistory.aspx.cs" Inherits="Semester_4_Project_2.supplierHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        SUPPLIER HISTORY
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Supplier Name</label>
                        <asp:TextBox ID="txtName" class="form-control" placeholder="Enter the product name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="supplierForm" class="form-label">Useradmin</label>
                        <asp:TextBox ID="txtUsername" class="form-control" placeholder="Enter the supplier name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="category">
                        <label for="DropDownCategory" class="form-label">Action Type</label>
                        <asp:DropDownList ID="ddlActionType" runat="server">
                            <asp:ListItem Text="-- Select Action --" Value=""></asp:ListItem>
                            <asp:ListItem Text="INSERT" Value="INSERT"></asp:ListItem>
                            <asp:ListItem Text="UPDATE" Value="UPDATE"></asp:ListItem>
                            <asp:ListItem Text="DELETE" Value="DELETE"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-primary button-yellow-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
            <table class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                <tr style="border-bottom:1px solid black;">
                    <th>Name</th>
                    <th>Description</th>
                    <th>Address</th>
                    <th>Image</th>
                    <th>Username</th>
                    <th>Action Type</th>
                    <th>Action Date</th>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Description") %></td>
                            <td><%# Eval("Address") %></td>
                            <td><img src='<%# Eval("ImagePath") %>' width="50"/></td>
                            <td><%# Eval("Username") %></td>
                            <td><%# Eval("ActionType") %></td>
                            <td><%# Eval("ActionDate", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>

    </div>
</asp:Content>
