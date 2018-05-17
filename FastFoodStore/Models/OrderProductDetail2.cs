using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{

    public class OrderProductDetail2
    {
        public int OrderProductDetail2ID { get; set; }
        public int OrerProductID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public virtual OrderProduct OrderProduct { get; set; }
        public virtual Product Product { get; set; }
    }
}