using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicChat
{
    public partial class Default : System.Web.UI.Page
    {
        private Chat m_chat = Chat.ActiveChats()[0];
        private Chatter m_chatter = new Chatter(new Guid(), "Anonymous");
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Page.User.Identity.Name);
            System.Diagnostics.Debug.WriteLine(HttpContext.Current.User.Identity.Name);
            //if( Page.User.Identity.name )

            _UpdateChatterList();
            _UpdateChatMessageList();
        }
        private void _UpdateChatMessageList()
        {
            ChatMessageList.DataSource = m_chat.Messages;
            ChatMessageList.DataBind();
        }
        private void _UpdateChatterList()
        {
            ChattersBulletedList.DataSource = m_chat.Chatters;
            ChattersBulletedList.DataTextField = "Name";
            ChattersBulletedList.DataBind();
        }
        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NewMessageTextBox.Text))
            {
                string messageSent = m_chat.SendMessage(m_chatter, NewMessageTextBox.Text);
                //NewMessageTextBox.Text = string.Empty;
                NewMessageTextBox.Text = "";
            }
            _UpdateChatterList();
            _UpdateChatMessageList();
        }
    }
}