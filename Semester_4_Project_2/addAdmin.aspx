<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="addAdmin.aspx.cs" Inherits="Semester_4_Project_2.addAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        ADD ADMINISTRATOR
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="adminUsernameForm" class="form-label">Admin Username</label>
                        <asp:TextBox ID="adminUsernameForm" class="form-control" placeholder="Enter the name" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="adminPasswordForm" class="form-label">Admin Password</label>
                        <asp:TextBox ID="adminPasswordForm" class="form-control" placeholder="Enter the name" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="">
                <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="btnAdd" class="btn btn-primary button-yellow-design button-layout mb-3"/>
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="btnUpdate" class="btn btn-primary button-yellow-design button-layout"/>
                <hr />
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="btnDelete" class="btn btn-primary button-black-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
            <table id="table1" class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                <thead>
                    <tr style="border-bottom:1px solid black;">
                        <th>ID</th>
                        <th>Username</th>
                        <th>Role</th>
                        <th>Created At</th>
                        <th>Updated At</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterUsers" runat="server">
                        <ItemTemplate>
                            <tr>
                                 <td><%# Eval("id") %></td>
                                <td><%# Eval("username") %></td>
                                <td><%# Eval("role") %></td>
                                <td><%# Eval("created_at", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                                <td><%# Eval("updated_at", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
