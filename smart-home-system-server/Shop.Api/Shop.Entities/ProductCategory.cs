namespace Shop.Entities
{
    public class ProductCategory : BaseInformation
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public ICollection<Product> Products { get; set; } = null!;
    }
}
