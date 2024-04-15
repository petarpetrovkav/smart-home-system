namespace Shop.Entities
{
    public class Address
    {
        /* public int AddressId { get; set; }*/
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
