<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="userMail.aspx.cs" Inherits="Semester_4_Project_2.userMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="App_Themes\Project_Theme\styles\supplierHistory.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sup-content">
        <div class="sup-content-search">
            <div class="">
                <div>
                    <h2>
                        USER MAIL & COMPLAINT
                    </h2>
                </div>
                <div>
                    <div class="mb-3">
                        <label for="userEmailForm" class="form-label">User Email</label>
                        <asp:TextBox ID="userEmailForm" class="form-control" placeholder="Enter the Email"  runat="server"></asp:TextBox>
                    </div>
                    <div class="category">
                        <label for="ddlStatus" class="form-label">Mail Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">-- All Status --</asp:ListItem>
                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                            <asp:ListItem Value="Responded">Responded</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="">
                <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="btnSearch" class="btn btn-primary button-yellow-design button-layout mb-3"/>
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="btnUpdate" class="btn btn-primary button-yellow-design button-layout"/>
            </div>
        </div>
        <div class="sup-content-table">
            <table class="table table-hover table-striped table-products" style="outline: 1px solid #343434;">
                <tr style="border-bottom:1px solid black;">
                    <th>Name</th>
                    <th>Email</th>
                    <th>Status</th>
                    <th>Message</th>
                    <th>Created at</th>
                    <th>Updated at</th>
                </tr>

                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("name") %></td>
                            <td><%# Eval("email") %></td>
                            <td><%# Eval("status") %></td>
                            <td><%# Eval("message") %></td>
                            <td><%# Eval("created_at") %></td>
                            <td><%# Eval("updated_at") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
