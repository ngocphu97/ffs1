using System.Collections.Generic;
using FastFoodStore.Models;
namespace FastFoodStore.ViewModels
{
    public class ImportIndexData
    {
        public IEnumerable<ImportProducts> ImportProductss { get; set; }
        public IEnumerable<ImportDetail> ImportDetails { get; set; }
    }
}