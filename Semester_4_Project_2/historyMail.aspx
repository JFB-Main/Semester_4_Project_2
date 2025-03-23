<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="historyMail.aspx.cs" Inherits="Semester_4_Project_2.historyMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        MAIL HISTORY
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="txtMailUsername" class="form-label">Sender Name</label>
                        <asp:TextBox ID="txtMailUsername" class="form-control" placeholder="Enter the sender name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtAdminUsername" class="form-label">Admin Name</label>
                        <asp:TextBox ID="txtAdminUsername" class="form-control" placeholder="Enter the Admin name"  runat="server"></asp:TextBox>
                    </div>
                    <div class="category">
                        <label for="DropDownCategory" class="form-label">Mail Status</label>
                        <asp:DropDownList ID="ddlActionType" runat="server">
                            <asp:ListItem Text="-- Select Action --" Value=""></asp:ListItem>
                            <asp:ListItem Text="PENDING" Value="pending"></asp:ListItem>
                            <asp:ListItem Text="RESPONDED" Value="responded"></asp:ListItem>
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
                            <th>Email</th>
                            <th>Old Status</th>
                            <th>New Status</th>
                            <th>Admin Name</th>
                            <th>Message</th>
                            <th>Changed At</th>
                        </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Email") %></td>
                            <td><%# Eval("OldStatus") %></td>
                            <td><%# Eval("NewStatus") %></td>
                            <td><%# Eval("Username") %></td>
                            <td><%# Eval("Message") %></td>
                            <td><%# Eval("ChangedAt", "{0:yyyy-MM-dd HH:mm:ss}") %></td>
                        </tr>
                    </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
