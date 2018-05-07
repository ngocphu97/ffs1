using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class ImportProducts
    {
        public int ImportProductsID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public virtual ICollection<ImportDetail> ImportDetail { get; set; }
        public virtual Staff Staff { get; set; }
    }
}