using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Helpers;
using System.Web.Security;

namespace PasswordWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            objLogin login = new objLogin();
            try
            {
                if (!login.CheckPassword(txtUsername.Text, txtPassword.Text))
                {
                    Response.Write("<script>alert('incorrect login information')</script>");

                    return;
                }
                
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);
                
                if (!login.LoadLogin(txtUsername.Text.Trim()))
                {
                    Response.Write("<script>alert('An error occurred while attempting to login.')</script>");
                    return;
                }

                Session["LoginId"] = login.LoginId;
               
            }
            catch (Exception ex)
            {
                ex.LogExceptionsToFile();
            }
            Response.Redirect("~/Home.aspx");
        }
    }
}