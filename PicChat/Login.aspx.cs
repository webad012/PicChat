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

        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Trim().Length == 0)
            {
                registerErrorLabel.Text = "Username empty";
            }
            else
            {
                var user = from u in entities.Users
                           where u.Username == usernameTextBox.Text
                           select u;

                if (user.Count() != 0)
                {
                    registerErrorLabel.Text = "Username taken";
                }
                else
                {
                    if (passwordTextBox.Text.Trim().Length == 0)
                    {
                        registerErrorLabel.Text = "Password empty";
                    }
                    else
                    {
                        PicChatDBEntities1 transac_entities = new PicChatDBEntities1();
                        transac_entities.Connection.Open();
                        System.Data.Common.DbTransaction transaction = transac_entities.Connection.BeginTransaction();
                        try
                        {
                            User newuser = new User()
                            {
                                Username = usernameTextBox.Text,
                                Password = passwordTextBox.Text
                            };

                            transac_entities.Users.AddObject(newuser);
                            transac_entities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            registerErrorLabel.Text = "Error creating user";
                            return;
                        }

                        transaction.Commit();
                        registerErrorLabel.Text = "Successful registration";
                    }
                }
            }
        }
    }
}