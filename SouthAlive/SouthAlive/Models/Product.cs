using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImgUrl { get; set; }
        public string ProductCategory { get; set; }
        public DateTime ListedDate { get; set; }
        public string ProductPrice { get; set; }
    }
}
