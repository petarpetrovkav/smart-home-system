namespace Shop.Entities
{
    public class ProductCategory : BaseInformation
    {
        public Guid ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public virtual ICollection<Product> Products { get; set; } = null!;
    }
}
