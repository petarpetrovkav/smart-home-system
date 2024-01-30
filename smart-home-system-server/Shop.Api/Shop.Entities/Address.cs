namespace Shop.Entities
{
    public class Address : BaseEntity
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
