using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Helpers;
using Business;
using System.Data.Entity.Core.Objects;
using System.Data.Linq.SqlClient;
namespace PasswordWebApp.GridViews
{
    public class UserNameAndPasswordGrid
    {
          
        //public static void LoadUserNameAndPasswordGrid(int loginId, DataGrid data)
        //{
        //    try
        //    {
        //        using (var db = new PasswordManagementEntities())
        //        {
        //            var result = (from x in db.LoginInformations
        //                          join y in db.AccountLoginDatas on x.LoginID equals y.LoginID
        //                          where x.LoginID == loginId
        //                          select new
        //                          {
        //                              y.AccountLoginDataUserName,
        //                              y.AccountLoginDataPassword,
        //                              y.AccountName
        //                              //x.UserName,
        //                              //x.Password,
        //                              //y.AccountName
                                     
        //                          }).ToList();
        //            if (result == null)
        //            {
        //                return;
        //            }
        //            data.DataSource = result;
        //            data.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.LogExceptionsToFile();
        //    }
        //}
        private readonly BasePage _basePage;
        private List<objAccountHolder> _accountHolders;
        private objAccountHolder _accountHolder;
        private int _loginId;
                
        public UserNameAndPasswordGrid()
        {
            _basePage = new BasePage(ref _loginId);
            _accountHolder = new objAccountHolder();
            _accountHolders = new List<objAccountHolder>();
        }

                
        public void LoadAllRecordsGrid(int? loginId,  DataGrid data)
         {
             IEncryptAndDecrypt decrypt = new CryptoEncryption();
             
             using(var db = new PasswordManagementEntities())
             {
                 try
                 {
                     if (db.ShowAllRecords(loginId).ToList().Count > 0)
                     {
                         DecryptAllRecords(loginId, decrypt, db);
                         data.DataSource = _accountHolders.ToList();
                         data.DataBind();
                     }
                 }
                 catch(Exception ex)
                 {
                     ex.LogExceptionsToFile();
                 }
             }
         }

         private List<objAccountHolder> DecryptAllRecords(int? loginId, IEncryptAndDecrypt decrypt, PasswordManagementEntities db)
         {
             db.ShowAllRecords(loginId).ToList().ForEach(x =>
             {
                 x.AccountLoginDataUserName = decrypt.Decrypt(x.AccountLoginDataUserName);
                 x.AccountLoginDataPassword = decrypt.Decrypt(x.AccountLoginDataPassword);
                 x.AccountName = decrypt.Decrypt(x.AccountName);

                 _accountHolders.Add(new objAccountHolder
                 {
                     AccountLoginDataUserName = x.AccountLoginDataUserName,
                     AccountLoginDataPassword = x.AccountLoginDataPassword,
                     AccountName = x.AccountName
                 }
                );
             });
             
             return _accountHolders;
         }

         public void LoadAllRecordsByAccountName(string accountName, DataGrid data, ref string message)
         {
            using(var db = new PasswordManagementEntities())
            {
                try
                {
                    IEncryptAndDecrypt decrypt = new CryptoEncryption();
                 
                    DecryptAllRecords(_basePage.LoginId, decrypt, db);
                    var query = _accountHolders.Where(x => x.AccountName.Contains(accountName)).ToList();
                  
                        if (query.Count > 0)
                       {
                            data.DataSource = query;
                            data.DataBind();
                        }
                        else
                        {
                            message = "No records were found with the account name you entered.";
                        }
                }
                catch(Exception ex)
                {
                    ex.LogExceptionsToFile();
                }
            }
        }

        public void LoadAllRecordsByUserName(string userName, DataGrid data, ref string message)
        {
            using (var db = new PasswordManagementEntities())
            {
                try
                {
                    IEncryptAndDecrypt decrypt = new CryptoEncryption();

                    DecryptAllRecords(_basePage.LoginId, decrypt, db);

                    var query = _accountHolders.Where(x => x.AccountLoginDataUserName.Contains(userName)).ToList();
                
                    if (query.Count > 0)
                    {
                        data.DataSource = query;
                        data.DataBind();
                    }
                    else
                    {
                        message = "No records were found with the username you entered.";
                    }
                }
                catch(Exception ex)
                {
                    ex.LogExceptionsToFile();
                }
            }
        }

        public void LoadAllRecordsByPassword(string password, DataGrid data, ref string message)
        {
            using (var db = new PasswordManagementEntities())
            {
                try
                {
                    IEncryptAndDecrypt decrypt = new CryptoEncryption();

                    DecryptAllRecords(_basePage.LoginId, decrypt, db);

                    var query = _accountHolders.Where(x => x.AccountLoginDataPassword.Contains(password)).ToList();
                     
                    if (query.Count > 0)
                    {
                        data.DataSource = query;
                        data.DataBind();
                    }
                 
                    else
                    {
                        message = "No records were found with the password you entered.";
                    }
                }
                catch(Exception ex)
                {
                    ex.LogExceptionsToFile();
                }
            }
        }
    }
}