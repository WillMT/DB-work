using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVCcafe_web.Models
{
    public partial class LoginContext : DbContext
    {
        public System.Data.Entity.DbSet<MVCcafe_web.Models.admin> admins { get; set; }
    }
}