<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Semester_4_Project_2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign Up and Login Form</title>
    <link rel="stylesheet" href="App_Themes/Project_Theme/styles/login.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">

</head>
<body>
    <div class="wrapper">
        <form id="loginForm" runat="server">
            <h1>Log In</h1>
            <div class="input-box">
                <asp:TextBox ID="username" class="form-control" placeholder="Username"  runat="server"></asp:TextBox>
                <i class='bx bxs-user'></i>
            </div>
            <div class="input-box">
                <asp:TextBox ID="password" class="form-control" placeholder="Password"  runat="server" TextMode="Password"></asp:TextBox>
                <i class='bx bxs-lock-alt'></i>
            </div>

<%--            <div class="remember-forgot">
                <label><input type="checkbox"> Remember Me!</label>
                <a href="#"> Forgot Password? </a>
            </div>--%>

            <asp:Button ID="ButtonLogIn" runat="server" Text="Log In" OnClick="btnLogIn" class="btn button-yellow-design button-layout mb-3"/>

<%--            <div class="register-link">
                <p> Don't Sign Up Yet? <a href="signup.html">Sign Up!</a> </p>
                <p> Change Password? <a href="changePassword.html">Click Here!</a> </p>
            </div>--%>
        </form>
    </div>

        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.all.min.js"></script>
</body>
</html>
