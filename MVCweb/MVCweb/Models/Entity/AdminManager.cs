using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCweb.Models.Database;
using MVCweb.Models.ViewModel;

namespace MVCweb.Models.Entity
{
    public class AdminManager
    {
        public void AddAdminAcc (AdminSignUpView user)
        {
            using (MVCDB_Entities db = new MVCDB_Entities())
            {
                admin AD = new admin();
                AD.aName = user.Username;
                AD.aPwd = user.Password;
                db.admins.Add(AD);
                db.SaveChanges();
            }
        }
        public bool IsUsernNameExist(string UserName)
        {
            using (MVCDB_Entities db = new MVCDB_Entities())
            {
                return db.admins.Where(o => o.aName.Equals(UserName)).Any();
            }
        }
    }
}