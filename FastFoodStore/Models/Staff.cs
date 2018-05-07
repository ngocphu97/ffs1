using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastFoodStore.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public String Name { get; set; }
        public int Role { get; set; }
        public String PhoneNumber { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<ImportProducts> ImportProducts { get; set; }
        public virtual ICollection<ExportProduct> ExportProduct { get; set; }

    }
}