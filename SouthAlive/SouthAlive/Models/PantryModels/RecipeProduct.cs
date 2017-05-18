using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models.PantryModels
{
    public class RecipeProduct
    {
        public int RecipeProductID { get; set; }

        public virtual int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }

        public virtual int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
