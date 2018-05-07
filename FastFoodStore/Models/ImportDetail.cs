using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class ImportDetail
    {
        public int ImportDetailID { get; set; }
        public int ImportID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public float PriceImport { get; set; }
        public float Total { get; set; }
        public virtual ImportProducts ImportProducts { get; set; }
    }
}