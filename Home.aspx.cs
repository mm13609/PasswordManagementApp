using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;
using Business;
namespace PasswordWebApp
{
    public partial class Home : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNoRecordFound.Text = "";

            if (!Page.IsPostBack)
            {
                try
                {
                    int loginId = Convert.ToInt32(Session["LoginId"]);

                    GridViews.UserNameAndPasswordGrid userNameAndPasswordGrid = new GridViews.UserNameAndPasswordGrid();
                                       
                    userNameAndPasswordGrid.LoadAllRecordsGrid(loginId, PasswordDataGrid);
                }
                catch (Exception ex)
                {
                    ex.LogExceptionsToFile();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            GridViews.UserNameAndPasswordGrid userNameAndPasswordGrid = new GridViews.UserNameAndPasswordGrid();
           
            if(rbtnUserName.Checked)
            {
                userNameAndPasswordGrid.LoadAllRecordsByUserName(txtSearchData.Text, PasswordDataGrid, ref message);
                
                if(!String.IsNullOrEmpty(message))
                {
                    lblNoRecordFound.Visible = true;
                    lblNoRecordFound.Text = message;
                }
                rbtnUserName.Checked = false;
            }
            else if(rbtnPassword.Checked)
            {
                userNameAndPasswordGrid.LoadAllRecordsByPassword(txtSearchData.Text, PasswordDataGrid, ref message);
           
                if (!String.IsNullOrEmpty(message))
                {
                    lblNoRecordFound.Visible = true;
                    lblNoRecordFound.Text = message;
                }
                rbtnPassword.Checked = false;
            }
            else if(rbtnAccountName.Checked)
            {
                userNameAndPasswordGrid.LoadAllRecordsByAccountName(txtSearchData.Text, PasswordDataGrid, ref message);
                
                if (!String.IsNullOrEmpty(message))
                {
                    lblNoRecordFound.Visible = true;
                    lblNoRecordFound.Text = message;
                }
                rbtnAccountName.Checked = false;
            }
        }

        protected void PasswordDataGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
          //PasswordGridView.EditIndex = e.
        }

        protected void PasswordGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
           // PasswordGridView.EditIndex = e.NewEditIndex;
        }

        protected void PasswordGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }
    }
}