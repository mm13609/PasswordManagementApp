using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Business
{
    public class objLogin : objPerson
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        /// <summary>
        /// loads login information by login id
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public bool LoadLogin(int loginId)
        {
            try
            {
                using (var db = new PasswordManagementEntities())
                {
                    var result = db.LoginInformations.Where(x => x.LoginID == loginId).FirstOrDefault();

                    if (result == null)
                    {
                        return false;
                    }

                    LoginId = (int)result.LoginID;
                    UserName = result.UserName;
                    Password = result.Password;
                    PersonId = (int)result.PersonID;
                }
            }
            catch(Exception ex)
            {
                ex.LogExceptionsToFile();
                return false;
            }
            return true;
        }

        /// <summary>
        /// loads login information by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool LoadLogin(string userName)
        {
            try 
            {
                using (var db = new PasswordManagementEntities())
                {
                    var result = db.LoginInformations.Where(x => x.UserName == userName).FirstOrDefault();

                    if (result == null)
                    {
                        return false;
                    }

                    LoginId = (int)result.LoginID;
                    UserName = result.UserName;
                    Password = result.Password;
                    PersonId = (int)result.PersonID;
                }
            }
            catch(Exception ex)
            {
                ex.LogExceptionsToFile();
                return false;
            }
            return true;
        }
       /// <summary>
       /// loads account holder's name
       /// </summary>
       /// <param name="loginId"></param>
       /// <returns></returns>
        public bool LoadAccountHolder(int loginId)
        {
            if (!LoadLogin(loginId))
            {
                return false;
            }

            if (!LoadPerson(PersonId))
            {
                return false;
            }

            return true;
        }

        public bool CheckPassword(string userName, string password)
        {
            try
            {
                using (var db = new PasswordManagementEntities())
                {
                    var result = db.LoginInformations.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
                    if (result == null)
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                ex.LogExceptionsToFile();
                return false;
            }
            return true;
        }

        public bool AddLogin(int loginId, string userName, string password)
        {
            try
            {
                using (var db = new PasswordManagementEntities())
                {
                    LoginInformation login = new LoginInformation();
                    login.UserName = userName;
                    login.Password = password;

                    db.LoginInformations.Add(login);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ex.LogExceptionsToFile();
                return false;
            }
            
            return true;
        }
    }
}
