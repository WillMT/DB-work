using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_web.Models.DB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC_web.DAL
{
    public class CartContext : DbContext
    {
        public CartContext() : base("CartContext")
        {
        }
        //public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<cartFunction> cartFunctions { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}