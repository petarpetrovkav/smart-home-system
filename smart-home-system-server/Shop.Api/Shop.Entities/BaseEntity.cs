namespace Shop.Entities;

public class BaseEntity
{
    public string UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
