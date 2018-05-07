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
        public DbSet<Category> Category { get; set; }
        public DbSet<ExportDetail> ExportDetail { get; set; }
        public DbSet<ExportProduct> ExportProduct { get; set; }
        public DbSet<ImportDetail> ImportDetail { get; set; }
        public DbSet<ImportProducts> ImportProducts { get; set; }
        public DbSet<Staff> Staff { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}