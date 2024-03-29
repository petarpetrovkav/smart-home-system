namespace Shop.Entities
{
    public class ShoppingCart : BaseEntity
    {
        /*public int ShoppingCartId { get; set; }*/
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
