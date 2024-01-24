using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class ShoppingSession
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
