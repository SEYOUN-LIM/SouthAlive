using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models.PantryModels
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserEmail { get; set; }


        public virtual List<CartProduct> CartProducts { get; set; }
    }
}
