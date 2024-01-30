using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int ShoppingCartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
