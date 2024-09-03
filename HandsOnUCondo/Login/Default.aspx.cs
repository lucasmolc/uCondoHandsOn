using HandsOnUCondo.Classes;
using System;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Xml.Linq;

namespace HandsOnUCondo.Login
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Util.isMail(TbMail.Text)) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Informe um E-Mail válido!')", true); }
            if (string.IsNullOrEmpty(TbPassword.Text)) { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Informe uma senha válida!')", true); }

            string uname = Regex.Replace(TbMail.Text.Trim().Substring(0, Math.Min(TbMail.Text.Length, 100)), "[^a-zA-Z0-9!.?] ", "");
            string password = Regex.Replace(TbPassword.Text.Trim().Substring(0, Math.Min(TbPassword.Text.Length, 20)), "[^a-zA-Z0-9!.?] ", "");

            bool isAuthenticated = Classes.User.Login(uname, password);
            if (isAuthenticated)
            {
                try
                {
                    FormsAuthentication.SetAuthCookie(uname, false);
                    Response.Redirect("~/Home");
                }
                catch (Exception)
                {

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Usuário ou senha não conferem.')", true);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/Register");
        }
    }
}