namespace Shop.Entities
{
    public class Product : BaseInformation
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
