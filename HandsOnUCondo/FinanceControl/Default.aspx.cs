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
                GridViewFinances.DataBind();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Verify if all fields are filled
            if (string.IsNullOrEmpty(ddlStatus.SelectedValue) || string.IsNullOrEmpty(tbDescription.Text) || string.IsNullOrEmpty(tbValue.Text) || string.IsNullOrEmpty(tbExpiration.Text) || string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert Message", "alert('Todos os campos devem ser preenchidos para cadastro!')", true);
                return;
            }

            // Register finance in database
            Finance finance = new Finance();
            finance.IdStatus = Convert.ToInt32(ddlStatus.SelectedIndex) + 1;
            finance.Description = tbDescription.Text;
            finance.FinanceValue = Convert.ToDecimal(tbValue.Text);
            finance.Expiration = tbExpiration.Text;
            finance.Period = !string.IsNullOrEmpty(tbPeriod.Text) ? Convert.ToInt32(tbPeriod.Text) : 1;
            finance.Type = Convert.ToInt32(ddlType.SelectedValue);
            finance.Add();

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

            // Create a new instance of the finance class
            Finance finance = new Finance();

            // Retrieve the finance details from the database using the value obtained from the GridView
            finance.Get(Convert.ToInt32(dc));

            // Disable the register button and make the save button visible
            btnRegister.Enabled = false;
            btnSave.Visible = true;

            // Update the input fields with the finance's information
            tbId.Text = finance.FinanceId.ToString();
            ddlStatus.SelectedIndex = finance.IdStatus - 1;
            tbDescription.Text = finance.Description;
            tbValue.Text = finance.FinanceValue.ToString();
            tbExpiration.TextMode = TextBoxMode.Date;
            tbExpiration.Text = finance.Expiration.SubstringUpToFirst(' ').Replace("/", "-");
            tbPeriod.Text = finance.Period.ToString();
            ddlType.SelectedIndex = finance.Type - 1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new instance of the finance class
            Finance finance = new Finance();

            // Set the properties of the finance object with the values from the input fields
            finance.FinanceId = Convert.ToInt32(tbId.Text);
            finance.IdStatus = Convert.ToInt32(ddlStatus.SelectedValue);
            finance.Description = tbDescription.Text;
            finance.FinanceValue = Convert.ToDecimal(tbValue.Text);
            finance.Expiration = tbExpiration.Text;
            finance.Period = !string.IsNullOrEmpty(tbPeriod.Text) ? Convert.ToInt32(tbPeriod.Text) : 1;
            finance.Type = Convert.ToInt32(ddlType.SelectedValue);

            // Call the Update method of the finance object to update the finance's information in the database
            finance.Update();

            // Call the Refresh method to refresh the page
            Refresh();
        }

        protected void GridViewFinances_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Create a new instance of the User class
            Finance finance = new Finance();
            // Set the UserId property of the User object with the value from the GridView data keys
            finance.FinanceId = Convert.ToInt32(GridViewFinances.DataKeys[e.RowIndex].Value);
            // Call the Delete method of the User object to delete the user from the database
            finance.Delete();

            // Call the Refresh method to refresh the page
            Refresh();
        }

        public void LimpaCampos()
        {
            tbDescription.Text = "";
            tbValue.Text = "";
            tbExpiration.Text = "";
            tbPeriod.Text = "";
        }

        public void LimpaFiltros()
        {
            tbIdFinancesFilter.Text = "";
            tbDescriptionFilter.Text = "";
            tbExpirationDate1Filter.Text = "";
            tbExpirationDate2Filter.Text = "";
        }

        public void Refresh()
        {
            LimpaCampos();
            LimpaFiltros();

            Response.Redirect(Request.RawUrl);
        }

        public void FillDropDownList()
        {
            Status status = new Status();
            ddlStatusFilter.DataSource = status.GetAllStatus();
            ddlStatus.DataSource = status.GetStatusToRegister();
            ddlStatusFilter.DataTextField = "StatusName";
            ddlStatus.DataTextField = "StatusName";
            ddlStatusFilter.DataValueField = "IdStatus";
            ddlStatus.DataValueField = "IdStatus";
            ddlStatusFilter.SelectedIndex = 2;
            ddlStatusFilter.DataBind();
            ddlStatus.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GridViewFinances.DataBind();
        }

        protected void GridViewFinances_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCell = e.Row.Cells[1];
                switch (statusCell.Text)
                {
                    case "1":
                        statusCell.Text = "Aberto";
                        break;
                    case "2":
                        statusCell.Text = "Quitado";
                        break;
                }

                TableCell typeCell = e.Row.Cells[6];
                switch (typeCell.Text)
                {
                    case "1":
                        typeCell.Text = "Receita";
                        typeCell.ForeColor = System.Drawing.Color.Green;
                        break;
                    case "2":
                        typeCell.Text = "Despesa";
                        typeCell.ForeColor = System.Drawing.Color.Red;
                        break;
                }
            }
        }
    }
}