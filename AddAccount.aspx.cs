using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;
using Business;
using System.Security.Cryptography;
using System.Text;
namespace PasswordWebApp
{
    public partial class AddAccount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objAccountHolder oAccountHolder = new objAccountHolder();
            IEncryptAndDecrypt encrypt = new CryptoEncryption();
           
            txtUserName.Text = encrypt.Encrypt(txtUserName.Text.Trim());
            txtPassword.Text = encrypt.Encrypt(txtPassword.Text.Trim());
            txtAccountName.Text = encrypt.Encrypt(txtAccountName.Text.Trim());

            if (!oAccountHolder.AddAccountHolderInformation(Convert.ToInt32(Session["LoginId"]), txtUserName.Text, txtPassword.Text, txtAccountName.Text))
                return;
            if (!oAccountHolder.LoadAccountHolderInformation(Convert.ToInt32(Session["LoginId"])))
                return; 
                
            Response.Redirect("~/Home.aspx");

        }
    }
}