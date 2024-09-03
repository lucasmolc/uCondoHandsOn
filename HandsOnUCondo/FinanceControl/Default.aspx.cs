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
    public partial class FinanceControl : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownList();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Verify if all fields are filled
            if (string.IsNullOrEmpty(tbName.Text) && string.IsNullOrEmpty(tbMail.Text) && string.IsNullOrEmpty(tbCPF.Text) && string.IsNullOrEmpty(tbPassword.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Todos os campos devem ser preenchidos para cadastro!')", true);
                return;
            }

            // Verify if e-mail is valid
            if (!Util.isMail(tbMail.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('E-mail inválido!')", true);
                return;
            }

            // Verify if CPF is valid
            if (!Util.isCPF(tbCPF.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('CPF inválido!')", true);
                return;
            }

            // Register user in database
            User user = new User();
            user.UserName = tbName.Text;
            user.UserMail = tbMail.Text;
            user.UserCPF = tbCPF.Text;
            user.UserPassword = tbPassword.Text;
            user.Add();

            // Clear fields after registration
            Refresh();
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
        }

        public void LimpaFiltros()
        {
            tbIdFinances.Text = "";
            tbDescription.Text = "";
            ddlStatus.Text = "";
            ddlStatus.SelectedValue = "";
            tbExpirationDate1.Text = "";
            tbExpirationDate2.Text = "";
        }

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        public void Refresh()
        {
            LimpaCampos();
            LimpaFiltros();

            Response.Redirect(Request.RawUrl);
        }

        public void FillDropDownList()
        {
            Status status = new Status();
            ddlStatus.DataSource = status.GetAllStatus();
            ddlStatus.DataTextField = "StatusName";
            ddlStatus.DataValueField = "IdStatus";
            ddlStatus.SelectedIndex = 2;
            ddlStatus.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            GridViewFinances.DataBind();
        }

        protected void iBtnFrom_Click(object sender, ImageClickEventArgs e)
        {
            ExpirationDate1.Visible = !ExpirationDate1.Visible;
        }

        protected void iBtnUntil_Click(object sender, ImageClickEventArgs e)
        {
            ExpirationDate2.Visible = !ExpirationDate2.Visible;
        }

        protected void ExpirationDate1_SelectionChanged(object sender, EventArgs e)
        {
            tbExpirationDate1.Text = ExpirationDate1.SelectedDate.ToString("dd/MM/yyyy");
            ExpirationDate1.Visible = false;
        }

        protected void ExpirationDate2_SelectionChanged(object sender, EventArgs e)
        {
            tbExpirationDate2.Text = ExpirationDate2.SelectedDate.ToString("dd/MM/yyyy");
            ExpirationDate2.Visible = false;
        }
    }
}