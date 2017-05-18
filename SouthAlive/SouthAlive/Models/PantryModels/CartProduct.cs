using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthAlive.Models.PantryModels
{
    public class CartProduct
    {
        public int CartProductID { get; set; }

        public virtual int CartID { get; set; }
        public virtual Cart Cart { get; set; }

        public virtual int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
