using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class ExportProduct
    {
        public int ExportProductID { get; set; }
        public int StaffID { get; set; }
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public virtual ICollection<ExportDetail> ExportDetail { get; set; }
        public virtual Staff Staff { get; set; }
    }
}