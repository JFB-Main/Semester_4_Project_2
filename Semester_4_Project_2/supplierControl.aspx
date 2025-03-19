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
                        <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control" >
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
            <table id="table1" class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                <tr style="border-bottom:1px solid black;">
                    <th>Supplier Name</th>
                    <th>Description</th>
                    <th>Address</th>
                    <th>Photo</th>
                </tr>
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
            </table>
        </div>
    </div>
</asp:Content>
