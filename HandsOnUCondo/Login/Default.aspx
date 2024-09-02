<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandsOnUCondo.Login.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HandsOn uCondo</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link rel="stylesheet" href="Assets/login.css" />
    <link href="~\assets\icons\favicon.jpg" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex; align-items: center; flex-direction: column; height: 100vh; justify-content: center;">
            <div class="col-12" style="display: flex; margin-top: 5px; align-items: center; justify-content: center;">
                <asp:Image runat="server" ID="logo" ImageUrl="~/assets/logo.png" Height="120px" Width="280px"/>
            </div>
            <div class="col-12" style="display: flex; margin-top: 5px; align-items: center; justify-content: center;">
                <asp:Label ID="lblMail" runat="server" Text="E-Mail" CssClass="m-2" ForeColor="135,113,209"></asp:Label>
                <asp:TextBox ID="TbMail" runat="server" CssClass="text-black rounded-2 text-center" Height="32px" Width="290px"></asp:TextBox>
            </div>
            <div class="col-12" style="display: flex; margin-top: 5px; align-items: center; justify-content: center;">
                <asp:Label ID="lblPassword" runat="server" Text="Senha" CssClass="m-2" ForeColor="135,113,209"></asp:Label>
                <asp:TextBox ID="TbPassword" runat="server" CssClass="text-black rounded-2 text-center" Height="32px" Width="290px" TextMode="Password" ></asp:TextBox>
            </div>
            <div class="col-12" style="display: flex; margin-top: 20px; align-items: center; justify-content: center;">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="text-white rounded-2 text-center" Height="40px" Width="360px" BackColor="135,113,209" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
    <footer class="py-2 fixed-bottom" style="background-color: rgb(135,113,209);">
        <div class="container text-center">
            <small class="text-white-50">&copy; <%: DateTime.Now.Year %> HandsOn uCondo - All Rights Reserved. </small>
        </div>
    </footer>
</body>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
<script src="Assets/login.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
<script type="text/javascript" src="https://alcdn.msauth.net/browser/2.35.0/js/msal-browser.min.js"></script>
</html>
