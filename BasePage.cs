using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PasswordWebApp
{
    public class BasePage : System.Web.UI.Page
    {
        private int _loginId;

        public int LoginId
        {
            get { return Convert.ToInt32(Session["LoginId"]);}
            set { _loginId = value; }
        }

        public BasePage(ref int loginId)
        {
            LoginId = loginId;            
        }

        public BasePage() 
        {
 
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!Page.IsPostBack)
            {
                objLogin login = new objLogin();
                if (!login.LoadAccountHolder(Convert.ToInt32(Session["LoginId"])))
                {
                    return;
                }
                Session["FirstName"] = login.FirstName;
                Session["LastName"] = login.LastName;
                Session["LoginIdentity"] = Session["LoginId"];
            }
        }   
    }
}