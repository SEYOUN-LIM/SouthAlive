using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models.PantryModels
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Category { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
