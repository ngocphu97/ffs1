using FastFoodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.DAL
{
    public class FastFoodStoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FastFoodStoreContext>
    {
        protected override void Seed(FastFoodStoreContext context)
        {
            var products = new List<Product>
            {
                new Product{ ID=1, Name="Ga ran 1", CategoryID="ABC", Price=99000, Images="garan1.png",},
                new Product{ ID=2, Name="Ga chien 2", CategoryID="ABC", Price=19000, Images="garan2.jpg",},
                new Product{ ID=3, Name="Ga xoi mo 3", CategoryID="ABC", Price=29000, Images="garan3.jpg",},
                new Product{ ID=4, Name="Ga ham 4", CategoryID="ABC", Price=39000, Images="garan4.jpg",},
                new Product{ ID=5, Name="Ga hap 5", CategoryID="ABC", Price=49000, Images="garan5.jpg",},
                new Product{ ID=6, Name="Ga nuong 6", CategoryID="ABC", Price=59000, Images="garan6.jpg",},
                new Product{ ID=7, Name="Ga lan bot 7", CategoryID="ABC", Price=59000, Images="garan7.jpg",},
                new Product{ ID=8, Name="Ga lan kem 8", CategoryID="ABC", Price=69000, Images="garan8.jpg",},
                new Product{ ID=9, Name="Ga com 9", CategoryID="ABC", Price=99000, Images="garan9.png",},
                new Product{ ID=10, Name="Ga xao 10", CategoryID="ABC", Price=199000, Images="garan10.jpg",},
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            //public void addToObject()
            //{
            //    List<Vars> variable = new List<Vars>();
            //    variable.Add(new Vars { Id = "var1", Names = new List<string>() { "n1", "n2", "n3", "n4" } });
            //}


            var orderProduct = new List<OrderProduct>
            {

                new OrderProduct{
                    ID =1, Buyer="Phu", DateIn=DateTime.Parse("2017-09-10"), Status=1, Total=990000,
                },
                new OrderProduct{ID=2, Buyer="Long lun", DateIn=DateTime.Parse("2017-10-01"), Status=1, Total=990000 },
                new OrderProduct{ID=3, Buyer="Long cao", DateIn=DateTime.Parse("2017-01-01"), Status=1, Total=990000 },
                new OrderProduct{ID=4, Buyer="Phu", DateIn=DateTime.Parse("2018-02-01"), Status=1, Total=990000 },
                new OrderProduct{ID=5, Buyer="Long lun", DateIn=DateTime.Parse("2018-02-01"), Status=1, Total=990000 },
                new OrderProduct{ID=6, Buyer="Long cao", DateIn=DateTime.Parse("2017-08-01"), Status=1, Total=990000 },
                new OrderProduct{ID=7, Buyer="Phu", DateIn=DateTime.Parse("2017-07-01"), Status=1, Total=990000 },
                new OrderProduct{ID=8, Buyer="Long cao", DateIn=DateTime.Parse("2018-09-01"), Status=1, Total=990000 },
                new OrderProduct{ID=9, Buyer="Long lun", DateIn=DateTime.Parse("2018-09-01"), Status=1, Total=990000 },
                new OrderProduct{ID=10, Buyer="Phu", DateIn=DateTime.Parse("2018-09-01"), Status=1, Total=990000 },

            };
            orderProduct.ForEach(s => context.OrderProduct.Add(s));
            context.SaveChanges();

            var orderProductDetails = new List<OrderProductDetail>
            {
                new OrderProductDetail { OrderProductDetailID=1, OrerProductID=1, Amount=1, },
                new OrderProductDetail { OrderProductDetailID=1, OrerProductID=2, Amount=2, },
                new OrderProductDetail { OrderProductDetailID=1, OrerProductID=3, Amount=3, },
                new OrderProductDetail { OrderProductDetailID=1, OrerProductID=4, Amount=4, },

            };
            orderProductDetails.ForEach(s => context.OrderProductDetail.Add(s));
            context.SaveChanges();

            var staffs = new List<Staff>
            {
                new Staff{StaffID=1, Name="Phu", Role=0, PhoneNumber="0123456789" },
                new Staff{StaffID=2, Name="Long lun", Role=1, PhoneNumber="0123456789" },
                new Staff{StaffID=3, Name="Long cao", Role=1, PhoneNumber="0123456789" },
                new Staff{StaffID=4, Name="Phu 1", Role=0, PhoneNumber="0123456789" },
                new Staff{StaffID=5, Name="Phu 2", Role=1, PhoneNumber="0123456789" },
            };
            staffs.ForEach(s => context.Staff.Add(s));
            context.SaveChanges();


            var cartegories = new List<Category>
            {
                new Category{CategoryID=1, Name="Cate Ga Ran 1"},
                new Category{CategoryID=2, Name="Cate Ga Ran 2"},
                new Category{CategoryID=3, Name="Cate Ga Ran 3"},
                new Category{CategoryID=4, Name="Cate Ga Ran 4"},
                new Category{CategoryID=5, Name="Cate Ga Ran 5"},
            };
            cartegories.ForEach(s => context.Category.Add(s));
            context.SaveChanges();


            var importProducts = new List<ImportProducts>
            {
                new ImportProducts{ImportProductsID=1, Date=DateTime.Parse("2018-09-01"), StaffID=1 },
                new ImportProducts{ImportProductsID=2, Date=DateTime.Parse("2018-09-01"), StaffID=2 },
                new ImportProducts{ImportProductsID=3, Date=DateTime.Parse("2018-09-01"), StaffID=3 },
                new ImportProducts{ImportProductsID=4, Date=DateTime.Parse("2018-09-01"), StaffID=1 },
                new ImportProducts{ImportProductsID=5, Date=DateTime.Parse("2018-09-01"), StaffID=2 },
            };
            importProducts.ForEach(s => context.ImportProducts.Add(s));
            context.SaveChanges();

            var exportProducts = new List<ExportProduct>
            {
                new ExportProduct{ExportProductID=1, Date=DateTime.Parse("2018-09-01"), StaffID=1 },
                new ExportProduct{ExportProductID=2, Date=DateTime.Parse("2018-09-01"), StaffID=2 },
                new ExportProduct{ExportProductID=3, Date=DateTime.Parse("2018-09-01"), StaffID=3 },
                new ExportProduct{ExportProductID=4, Date=DateTime.Parse("2018-09-01"), StaffID=1 },
                new ExportProduct{ExportProductID=5, Date=DateTime.Parse("2018-09-01"), StaffID=2 },
            };
            exportProducts.ForEach(s => context.ExportProduct.Add(s));
            context.SaveChanges();

            var detailImportProduct = new List<ImportDetail>
            {
                new ImportDetail{ImportDetailID=1, ImportID=1, Amount=10, ProductID=1, },
                new ImportDetail{ImportDetailID=2, ImportID=1, Amount=20, ProductID=2, },
                new ImportDetail{ImportDetailID=3, ImportID=1, Amount=10, ProductID=3, },

                new ImportDetail{ImportDetailID=4, ImportID=2, Amount=10, ProductID=1, },
                new ImportDetail{ImportDetailID=5, ImportID=2, Amount=10, ProductID=2, },
                new ImportDetail{ImportDetailID=6, ImportID=2, Amount=10, ProductID=3, },
            };
            detailImportProduct.ForEach(s => context.ImportDetail.Add(s));
            context.SaveChanges();

            var detailExportProduct = new List<ExportDetail>
            {
                new ExportDetail{ExportDetailID=1, ExportID=1, Amount=10, ProductID=1, },
                new ExportDetail{ExportDetailID=2, ExportID=1, Amount=20, ProductID=2, },
                new ExportDetail{ExportDetailID=3, ExportID=1, Amount=10, ProductID=3, },

                new ExportDetail{ExportDetailID=4, ExportID=2, Amount=10, ProductID=1, },
                new ExportDetail{ExportDetailID=5, ExportID=2, Amount=10, ProductID=2, },
                new ExportDetail{ExportDetailID=6, ExportID=2, Amount=10, ProductID=3, },
            };
            detailExportProduct.ForEach(s => context.ExportDetail.Add(s));
            context.SaveChanges();
        }
    }
}