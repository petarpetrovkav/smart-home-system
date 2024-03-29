using Microsoft.AspNetCore.Identity;

namespace Shop.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Country { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public virtual ICollection<Address>? Address { get; set; }
        public virtual ICollection<ShoppingCart>? ShoppingCarts { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }
}
