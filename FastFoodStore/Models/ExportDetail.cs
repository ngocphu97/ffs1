using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class ExportDetail
    {
        public int ExportDetailID { get; set; }
        public int ExportID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public float Total { get; set; }
        public virtual ExportProduct ExportProduct { get; set; }

}
}