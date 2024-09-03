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
            // Check if any of the required fields are empty
            if (string.IsNullOrEmpty(TbName.Text) || string.IsNullOrEmpty(TbMail.Text) || string.IsNullOrEmpty(TbCPF.Text) || string.IsNullOrEmpty(TbPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Todos os campos devem ser preenchidos para cadastro!')", true);
                return;
            }

            // Check if the email is valid
            if (!Util.isMail(TbMail.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('E-mail inválido!')", true);
                return;
            }

            // Check if the CPF is valid
            if (!Util.isCPF(TbCPF.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('CPF inválido!')", true);
                return;
            }

            // Create a new User object and set its properties
            User usu = new User();
            usu.UserName = TbName.Text;
            usu.UserMail = TbMail.Text;
            usu.UserCPF = TbCPF.Text;
            usu.UserPassword = TbPassword.Text;

            // Call the Add method to add the user
            usu.Add();

            // Redirect to the login page
            Redirect();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect to the login page
            Redirect();
        }

        protected void Redirect()
        {
            Response.Redirect("~/Login");
        }
    }
}