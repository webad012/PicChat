<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PicChat.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">
        function _SetChatTextScrollPosition() {
            var chatText = document.getElementById("ChatText");
            chatText.scrollTop = chatText.scrollHeight;
            window.setTimeout("_SetChatTextScrollPosition()", 1);
        }

        window.onload = function () {
            _SetChatTextScrollPosition();
        }

//        function storeinput(value) {
//            document.getElementById("hidValue").value = value;
//        }
    </script>

    <form id="form1" runat="server" style="background-color: #ADC9D1">
        <%--<input type="hidden" id="hidValue" runat="server" />--%>
        <asp:LoginName ID="LoginName1" runat="server" />
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                You are not logged in.<asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
                &nbsp;
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in.
            </LoggedInTemplate>
        </asp:LoginView>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <asp:UpdatePanel ID="ChatUpdatePanel" runat="server" UpdateMode="Always">
            <ContentTemplate>
                Chatters<br/>
                <asp:BulletedList ID="ChattersBulletedList" runat="server" 
                    BackColor="#FF8000" />
                Chat Text<br/>
                <div id="ChatText" 
                    style="width: 440px; height: 140px; overflow: auto; background-color: #B6E2B7;">
                    <asp:BulletedList runat="server" ID="ChatMessageList" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="SendButton" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ChatTextTimer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        Send Message Text<br/>|
        <asp:TextBox ID="NewMessageTextBox" Columns="50" runat="server" 
            BackColor="White" /><asp:Button EnableViewState="false" ID="SendButton" Text="Send" runat="server" OnClick="SendButton_Click" />
        <asp:Timer runat="server" ID="ChatTextTimer" Interval="1000" />
    </form>
</body>
</html>
