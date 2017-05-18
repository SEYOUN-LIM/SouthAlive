using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models.PantryModels
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string VideoPath { get; set; }

        public virtual List<RecipeProduct> RecipeProducts { get; set; }
    }
}
