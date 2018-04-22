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
                new Product{ ID=1, Name="Ga ran 1", Category="ABC", Price=99000, Images="garan1.png",},
                new Product{ ID=2, Name="Ga chien 2", Category="ABC", Price=19000, Images="garan2.jpg",},
                new Product{ ID=3, Name="Ga xoi mo 3", Category="ABC", Price=29000, Images="garan3.jpg",},
                new Product{ ID=4, Name="Ga ham 4", Category="ABC", Price=39000, Images="garan4.jpg",},
                new Product{ ID=5, Name="Ga hap 5", Category="ABC", Price=49000, Images="garan5.jpg",},
                new Product{ ID=6, Name="Ga nuong 6", Category="ABC", Price=59000, Images="garan6.jpg",},
                new Product{ ID=7, Name="Ga lan bot 7", Category="ABC", Price=59000, Images="garan7.jpg",},
                new Product{ ID=8, Name="Ga lan kem 8", Category="ABC", Price=69000, Images="garan8.jpg",},
                new Product{ ID=9, Name="Ga com 9", Category="ABC", Price=99000, Images="garan9.png",},
                new Product{ ID=10, Name="Ga xao 10", Category="ABC", Price=199000, Images="garan10.jpg",},
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



        }
    }
}