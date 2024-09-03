using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HandsOnUCondo.Classes;

namespace HandsOnUCondo.Login.Register
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbName.Text) || string.IsNullOrEmpty(TbMail.Text) || string.IsNullOrEmpty(TbCPF.Text) || string.IsNullOrEmpty(TbPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Todos os campos devem ser preenchidos para cadastro!')", true);
                return;
            }

            if (!Util.isMail(TbMail.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('E-mail inválido!')", true);
                return;
            }

            if (!Util.isCPF(TbCPF.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('CPF inválido!')", true);
                return;
            }

            User usu = new User();
            usu.UserName = TbName.Text;
            usu.UserMail = TbMail.Text;
            usu.UserCPF = TbCPF.Text;
            usu.UserPassword = TbPassword.Text;

            usu.Add();

            Redirect();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Redirect();
        }

        protected void Redirect()
        {
            Response.Redirect("~/Login");
        }
    }
}