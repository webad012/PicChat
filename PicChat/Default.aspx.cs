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
        private Chatter m_chatter = Chatter.ActiveChatters().Values.Last();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "prompt", "var value = prompt('Enter your message here.'); storeinput(value);", true);
            m_chatter.Name = hidValue.Value;

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