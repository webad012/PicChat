using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PicChat
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            List<Chatter> chatters = new List<Chatter>();
            //chatters.Add(new Chatter(Guid.NewGuid(), "Senad"));
            //chatters.Add(new Chatter(Guid.NewGuid(), "Bojana"));
            chatters.Add(new Chatter(new Guid(), "Milos"));
            Application.Add("Chatters", chatters);

            List<Chat> chats = new List<Chat>();
            chats.Add(new Chat());
            Application.Add("Chats", chats);
            foreach (KeyValuePair<Guid, Chatter> chatter in Chatter.ActiveChatters())
            {
                chatter.Value.Join(Chat.ActiveChats()[0]);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}