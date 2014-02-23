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
            m_chatter.Name = HttpContext.Current.User.Identity.Name;
            //System.Diagnostics.Debug.WriteLine(Page.User.Identity.Name);
            //System.Diagnostics.Debug.WriteLine(HttpContext.Current.User.Identity.Name);
            //if( Page.User.Identity.name )

            _UpdateChatterList();
            _UpdateChatMessageList();
        }
        private void _UpdateChatMessageList()
        {
            if (ChatMessageList.Items.Count != m_chat.Messages.Count)
            {
                ChatMessageList.DataSource = m_chat.Messages;
                ChatMessageList.DataBind();
            }
        }
        private void _UpdateChatterList()
        {
            if (ChattersBulletedList.Items.Count != m_chat.Chatters.Count)
            {
                ChattersBulletedList.DataSource = m_chat.Chatters;
                ChattersBulletedList.DataTextField = "Name";
                ChattersBulletedList.DataBind();
            }
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

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            foreach (var c in m_chat.Chatters)
            {
                if (c.Name.Equals(m_chatter.Name))
                {
                    m_chat.Chatters.Remove(c);
                    break;
                }
            }
        }
    }
}