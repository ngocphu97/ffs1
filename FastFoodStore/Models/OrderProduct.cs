using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class OrderProduct 
    {
        public int ID { get; set; }
        public DateTime DateIn { get; set; }
        public int Status { get; set; }
        public string Buyer { get; set; }
        public long Total { get; set; }
        //lakjlf
        public virtual ICollection<OrderProductDetail2> OrderProductDetails { get; set; }
        public virtual Staff Staff { get; set; }
    }
}