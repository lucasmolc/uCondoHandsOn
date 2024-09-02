using HandsOnUCondo.Classes;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandsOnUCondo
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["UserId"] != null)
            {
                int _userId = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value.ToString());

                User usu = new User();
                usu.Get(_userId);

                lblWelcome.Text = "Bem-vindo, " + usu.UserName.SubstringUpToFirst(' ') + "!";
            }
            else
                Response.Redirect("~/Login/Logout/");
        }
    }
}