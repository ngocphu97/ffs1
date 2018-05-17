using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CategoryID { get; set; }
        public long Price { get; set; }
        public string Images { get; set; }
        public virtual Category Category { get; set; }
    }
}