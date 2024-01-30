using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Country { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Address>? Address { get; set; }
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
