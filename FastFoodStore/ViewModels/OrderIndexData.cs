using System.Collections.Generic;
using FastFoodStore.Models;
namespace FastFoodStore.ViewModels
{
    public class OrderIndexData
    {
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
        public IEnumerable<OrderProductDetail2> OrderProductDetails { get; set; }
    }
}