namespace Shop.Entities
{
    public class Product : BaseInformation
    {
        public Guid ProductId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ICollection<CartItem> cartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
