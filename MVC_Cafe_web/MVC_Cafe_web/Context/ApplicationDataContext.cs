using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Cafe_web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC_Cafe_web.Context
{
    public class ApplicationDataContext : IdentityDbContext<AppUser>
    {
        public ApplicationDataContext()
            : base("DefaultConnection")
        { }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }
    }
}