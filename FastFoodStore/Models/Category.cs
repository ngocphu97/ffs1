using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public String Name { get; set; }
        public int ProductID { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}