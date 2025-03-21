<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="loginHistory.aspx.cs" Inherits="Semester_4_Project_2.loginHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        LOGIN HISTORY
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="adminUsernameForm" class="form-label">Admin Username</label>
                        <asp:TextBox ID="adminUsernameForm" class="form-control" placeholder="Enter the name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="category">
                        <label for="DropDownStatus" class="form-label">Login Status</label>
                        <asp:DropDownList ID="ddlStat" runat="server"  placeholder="Choose the category">
                            <asp:ListItem Text="-- Select Action --" Value=""></asp:ListItem>
                            <asp:ListItem Text="success" Value="success"></asp:ListItem>
                            <asp:ListItem Text="logout" Value="logout"></asp:ListItem>
                            <asp:ListItem Text="failed" Value="failed"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="">
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="btnSearch" class="btn btn-primary button-yellow-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
            <HeaderTemplate>
                <table class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                     <tr style="border-bottom:1px solid black;">
                        <th>Username</th>
                        <th>Login Time</th>
                        <th>Status</th>
                    </tr>
            </HeaderTemplate> 
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                         <tr>
                            <td><%# Eval("username") %></td>
                            <td><%# Eval("login_time") %></td>
                            <td><%# Eval("status") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
