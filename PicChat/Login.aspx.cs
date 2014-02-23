using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PicChat
{
    public partial class Login : System.Web.UI.Page
    {
        protected PicChatDBEntities1 entities = new PicChatDBEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = ValidateUser(Login2.UserName, Login2.Password);

            e.Authenticated = Authenticated;
        }

        private bool ValidateUser(string userName, string passWord)
        {
            //string encrypted = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "SHA1");
            var logins = from u in entities.Users
                         where u.Username == userName && u.Password == passWord
                         select u;
            if (logins.Count() == 0)
            {
                return false;
            }

            FormsAuthentication.RedirectFromLoginPage(userName, false);
            return true;
        }
    }
}