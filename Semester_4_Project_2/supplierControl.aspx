<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="supplierControl.aspx.cs" Inherits="Semester_4_Project_2.supplierControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        SUPPLIER CONTROl
                    </h2>
                </div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

                <div>
                    <div class="mb-3">
                        <label for="supplierForm" class="form-label">Supplier Name</label>
                        <asp:TextBox ID="supplierNameForm" class="form-control" placeholder="Enter the supplier name"  runat="server"></asp:TextBox>

                    </div>
                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Supplier Description</label>
                        <asp:TextBox ID="supplierDescForm" class="form-control" placeholder="Enter the description"  runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="productNameForm" class="form-label">Supplier Address</label>
                        <asp:TextBox ID="supplierAddressForm" class="form-control" placeholder="Enter the address"  runat="server"></asp:TextBox>
                    </div>
                    <div class="file-insert mb-3">
                        <label class="form-label" for="uploadFile">Upload Photo</label>
                        <asp:FileUpload ID="uploadFile" runat="server" CssClass="form-control" />
                    </div>
                   <div class="category">
                        <label for="DropDownSupplier" class="form-label">Select Supplier</label>
                        <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control" class="form-control" >
                        </asp:DropDownList>
                   </div>
                    <asp:HiddenField ID="HiddenFieldImagePath" runat="server" />

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
            <table class="table table-hover table-striped table-products display" style="outline: 1px solid #343434;" id="tableid">
                <thead>
                    <tr style="border-bottom:1px solid black;">
                        <th>Supplier Name</th>
                        <th>Description</th>
                        <th>Address</th>
                        <th>Photo</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("SupplierName") %></td>
                                <td><%# Eval("Description") %></td>
                                <td><%# Eval("Address") %></td>
                                <td><img src='<%# Eval("image_path") %>' width="120"/></td>
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
                "pageLength": 3,        // Set the number of rows per page
                "lengthMenu": [3, 5] // Define length options
            });
        });
    </script>
</asp:Content>
