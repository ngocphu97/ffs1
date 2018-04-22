using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class OrderProductDetail
    {
        public int OrderProductDetailID { get; set; }
        public int OrerProductID { get; set; }
        public int Amount { get; set; }
    }
}