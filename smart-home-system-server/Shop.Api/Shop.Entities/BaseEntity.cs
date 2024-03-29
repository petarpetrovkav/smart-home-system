﻿namespace Shop.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
