using FastFoodStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FastFoodStore.DAL
{
    public class FastFoodStoreContext: DbContext
    {
        public FastFoodStoreContext() : base("FastFoodStoreContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<OrderProductDetail> OrderProductDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}