<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PicChat.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Login<br />
        <asp:Login ID="Login2" runat="server" onauthenticate="Login2_Authenticate">
        </asp:Login>
    
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ValidationGroup="Login2" />
    </form>
</body>
</html>
