using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
namespace Business
{
    public abstract class objPerson
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public bool LoadPerson(int personId)
        {
            try 
            { 
            using (var db = new PasswordManagementEntities())
            {
                var result = db.People.Where(x => x.PersonID == personId).FirstOrDefault();
                
               
                if (result == null)
                    return false;

                PersonId = result.PersonID;
                FirstName = result.FirstName;
                MiddleName = result.MiddleName;
                LastName = result.LastName;
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

