using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ShoppingSessionId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public ShoppingSession? ShoppingSession { get; set; }
    }
}
