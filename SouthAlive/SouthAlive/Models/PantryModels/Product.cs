﻿using SouthAlive.Models.PantryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models.PantryModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImgUrl { get; set; }    
        public DateTime ListedDate { get; set; }
        public string ProductPrice { get; set; }

        public virtual int ProductCategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual List<RecipeProduct> RecipeProducts { get; set; }

        public virtual List<CartProduct> CartProducts { get; set; }

    }
}
