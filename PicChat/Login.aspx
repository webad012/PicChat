<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PicChat.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Login ID="Login2" runat="server" onauthenticate="Login2_Authenticate">
        </asp:Login>
    
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ValidationGroup="Login2" />
    <div>
    
        Register<br />
        <asp:Label ID="Label1" runat="server" Text="User name:"></asp:Label>
&nbsp;<asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="registerButton" runat="server" onclick="registerButton_Click" 
            Text="Register" />
    </div>
    <p>
        <asp:Label ID="registerErrorLabel" runat="server"></asp:Label>
    </p>
    </form>
</body>
</html>
