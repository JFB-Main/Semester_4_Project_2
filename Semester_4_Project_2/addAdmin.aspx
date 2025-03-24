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
            <table id="tableid" class="table table-hover table-striped table-products display" style="outline: 1px solid #343434;">
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
                "lengthMenu": [5, 10] // Define length options
            });
        });
    </script>
</asp:Content>
