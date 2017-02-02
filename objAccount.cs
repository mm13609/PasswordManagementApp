using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class objAccount
    {
        public int AccountId{ get; set; }
        public string AccountName { get; set; }
        public int? LoginId { get; set; }
       
        public objAccount()
        {
        }

        //TODO: separate method to add account, and separate method to add a password 
        //public bool AddPassword(string username, string password, string accountName)
        //{
   
        //    using (var db = new Business.PasswordManagementEntities())
        //    {
        //        /*var result = from x in db.Passwords
        //                     join y in db.Accounts on x.AccountID equals y.AccountID
        //                     select new
        //                     {
        //                         username = x.UserName,
        //                         password = x.Password1,
        //                         accountName = y.AccountName
        //                     };*/
        //        Account account = new Account();
        //        account.AccountName = accountName;
        //        db.Accounts.Add(account);
        //        db.SaveChanges();

        //        //var result = db.Passwords.Where(x => x.AccountID == account.AccountID).FirstOrDefault();

        //        Login login = new Login();
        //        login.AccountID = account.AccountID;
        //        login.UserName = username;
        //        login.Password = password;

        //        db.Logins.Add(login);

        //        db.SaveChanges();
        //    }
        //    return true;
        //}

        //public bool AddAccount(string accountName, int loginId)
        //{
        //    using(var db = new PasswordManagementEntities())
        //    {
        //        Account account = new Account();
        //       // account.AccountID = AccountId;
        //        account.LoginID = loginId;
        //        account.AccountName = accountName;
                
        //        db.Accounts.Add(account);
        //        db.SaveChanges();

        //        return true;
        //    }
        //}

        //public bool LoadAccount(string accountName, int loginId)
        //{
        //    using(var db = new PasswordManagementEntities())
        //    {
        //        var query = db.Accounts.Where(x => x.AccountName == accountName && x.LoginID == loginId).FirstOrDefault();
        //        if (query == null)
        //            return false;

        //        AccountId = query.AccountID;
        //    }
        //    return true;
        //}
    }
}
