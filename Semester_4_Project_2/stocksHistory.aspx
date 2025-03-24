<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="stocksHistory.aspx.cs" Inherits="Semester_4_Project_2.stocksHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">\
    <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        STOCKS HISTORY
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Admin Username</label>
                        <asp:TextBox ID="AdminUsernameForm" class="form-control" placeholder="Enter the description"  runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="supplierForm" class="form-label">Stock Name</label>
                        <asp:TextBox ID="stockForm" class="form-control" placeholder="Enter the supplier name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="category">
                        <label for="DropDownCategory" class="form-label">Category</label>
                        <asp:DropDownList ID="ddlCat" runat="server" class="form-control"  placeholder="Choose the category">
                        </asp:DropDownList>
                    </div>
                    <div class="category">
                        <label for="DropDownSupplier" class="form-label">Category</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control"  placeholder="Choose the category">
                        </asp:DropDownList>
                    </div>
                    <div class="category">
                        <label for="ddlActionType" class="form-label">Action Type</label>
                        <asp:DropDownList ID="ddlActionType" runat="server" class="form-control" >
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="">
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="btnSubmit_Click" class="btn btn-primary button-yellow-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
            <table class="table table-hover table-striped table-products display" style="outline: 1px solid #343434;" id="tableid">
                <thead>
                    <tr style="border-bottom:1px solid black;">
                        <th>Stock Name</th>
                        <th>Stock Price</th>
                        <th>Stock Amount</th>
                        <th>Description</th>
                        <th>Admin Username</th>
                        <th>Supplier</th>
                        <th>Action Type</th>
                        <th>Action Date</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("stock_name") %></td>
                                <td><%# Eval("stock_price", "{0:C}") %></td>
                                <td><%# Eval("stock_amount") %></td>
                                <td><%# Eval("description") %></td>
                                <td><%# Eval("username") %></td>
                                <td><%# Eval("supplier_name") %></td>
                                <td><%# Eval("action_type") %></td>
                                <td><%# Eval("action_time", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
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
