using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Business
{
    public class objAccountHolder
    {
       
        public int LoginId { get; set; }
        public string AccountLoginDataUserName { get; set; }
        public string AccountLoginDataPassword { get; set; }
        public string AccountName { get; set; }

        public objAccountHolder()         
        {

        }
        public objAccountHolder(int loginId, string accountLoginDataUserName, string accountLoginDataPassword, string accountName)
        {
            LoginId = loginId;
            AccountLoginDataUserName = accountLoginDataUserName;
            AccountLoginDataPassword = accountLoginDataPassword;
            AccountName = accountName;
        }

        public bool AddAccountHolderInformation(int loginId, string userName, string password, string accountName)
        {
            try
            {
                using (var db = new PasswordManagementEntities())
                {
                    AccountLoginData accountLoginData = new AccountLoginData();
                    accountLoginData.LoginID = loginId;
                    accountLoginData.AccountLoginDataUserName = userName;
                    accountLoginData.AccountLoginDataPassword = password;
                    accountLoginData.AccountName = accountName;

                    if (accountLoginData == null)
                        return false;

                    db.AccountLoginDatas.Add(accountLoginData);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ex.LogExceptionsToFile();
            }

            return true;
        }

        public bool LoadAccountHolderInformation(int loginId)
        {
            try
            {
                using (var db = new PasswordManagementEntities())
                {
                    var query = db.AccountLoginDatas.Where(x => x.LoginID == loginId).FirstOrDefault();
                    if (query == null)
                        return false;

                    AccountLoginDataUserName = query.AccountLoginDataUserName;
                    AccountLoginDataPassword = query.AccountLoginDataPassword;
                    LoginId = (int) query.LoginID;
                }
            }
            catch(Exception ex)
            {
                ex.LogExceptionsToFile();
            }
            return true;
        }
    }
}