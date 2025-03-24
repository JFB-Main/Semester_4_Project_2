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
                        <asp:DropDownList ID="ddlStat" runat="server" class="form-control"  placeholder="Choose the category">
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
                <table class="table table-hover table-products display" style="outline: 1px solid #343434; width:100%" id="tableid">
                    <thead>
                     <tr style="border-bottom:1px solid black;">
                        <th>Username</th>
                        <th>Login Time</th>
                        <th>Status</th>
                    </tr>
                    </thead>
                    <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                             <tr>
                                <td><%# Eval("username") %></td>
                                <td><%# Eval("login_time") %></td>
                                <td><%# Eval("status") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>
        </div>
        </div>

    <link rel="stylesheet" href="https://cdn.datatables.net/2.2.2/css/dataTables.dataTables.css" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
  
    <script src="https://cdn.datatables.net/2.2.2/js/dataTables.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables"></script>
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#tableid').DataTable({
                "paging": true,          // Enable pagination
                "pageLength": 10,        // Set the number of rows per page
                "lengthMenu": [5, 10, 15, 20] // Define length options
            });
        });
    </script>
</asp:Content>
