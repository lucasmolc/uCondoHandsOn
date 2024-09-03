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
    public partial class Usuarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Verify if all fields are filled
            if (string.IsNullOrEmpty(tbName.Text) && string.IsNullOrEmpty(tbMail.Text) && string.IsNullOrEmpty(tbCPF.Text) && string.IsNullOrEmpty(tbPassword.Text))
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Todos os campos devem ser preenchidos para cadastro!')", true);

            // Verify if e-mail is valid
            if (!Classes.Util.isMail(tbMail.Text))
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('E-mail inválido!')", true);

            // Register user in database
            User user = new User();
            user.UserName = tbName.Text;
            user.UserMail = tbMail.Text;
            user.UserCPF = tbCPF.Text;
            user.UserPassword = tbPassword.Text;
            user.Add();

            // Clear fields after registration
            LimpaCampos();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Retrieve the button that triggered the event
            Button btn = (Button)sender;

            // Retrieve the GridViewRow that contains the button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            // Retrieve the value of the first cell in the GridViewRow
            var dc = gvr.Cells[0].Text;

            // Create a new instance of the User class
            User usu = new User();
            // Retrieve the user details from the database using the value obtained from the GridView
            usu.Get(Convert.ToInt32(dc));

            // Disable the register button and make the save button visible
            btnRegister.Enabled = false;
            btnSave.Visible = true;

            // Update the input fields with the user's information
            tbId.Text = usu.UserId.ToString();
            tbName.Text = usu.UserName;
            tbMail.Text = usu.UserMail;
            tbCPF.Text = usu.UserCPF;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new instance of the User class
            User usu = new User();
            // Set the properties of the User object with the values from the input fields
            usu.UserId = Convert.ToInt32(tbId.Text);
            usu.UserName = tbName.Text;
            usu.UserMail = tbMail.Text;
            usu.UserCPF = tbCPF.Text;
            // Call the Update method of the User object to update the user's information in the database
            usu.Update();

            // If password filled, update it
            if (!string.IsNullOrEmpty(tbPassword.Text))
            {
                usu.UserPassword = tbPassword.Text;
                usu.UpdatePassword();
            }

            // Call the Refresh method to refresh the page
            Refresh();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Create a new instance of the User class
            User usu = new User();
            // Set the UserId property of the User object with the value from the GridView data keys
            usu.UserId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            // Call the Delete method of the User object to delete the user from the database
            usu.Delete();

            // Call the Refresh method to refresh the page
            Refresh();
        }

        /// <summary>
        /// Clears the input fields.
        /// </summary>
        public void LimpaCampos()
        {
            tbName.Text = "";
            tbMail.Text = "";
            tbCPF.Text = "";

            Refresh();
        }

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        public void Refresh()
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}