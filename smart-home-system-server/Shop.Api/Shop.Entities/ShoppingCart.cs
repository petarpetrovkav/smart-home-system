namespace Shop.Entities
{
    public class ShoppingCart
    {
        /*public int ShoppingCartId { get; set; }*/
        public Guid ShoppingCartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
