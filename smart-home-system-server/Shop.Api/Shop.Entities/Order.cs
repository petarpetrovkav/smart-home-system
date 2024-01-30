namespace Shop.Entities;

public class Order : BaseEntity
{
    public int OrderId { get; set; }
    public int AddressId { get; set; }
    public string? PaymentMethod { get; set; }
    public OrderStatus OrderStatus { get; set; }     //varchar 20
    public DateTime OrderDate { get; set; }
    public int TotalCost { get; set; }
    public Address? Addresses { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped_Dispatched,
    Delivered,
    Canceled,
    Refunded,
    OnHold,
    Completed,
}
/*

    The "order_status" in the context of an e-commerce or order management system refers to the current status or state of an order in its lifecycle.
It provides information about the progress and current condition of an order, helping both the customer and the system administrators understand the stage the order has reached.

Common order status values include:

Pending: The order has been placed but has not yet been processed or confirmed.

Processing: The order is being prepared for shipment or is undergoing other processing steps.

Shipped/Dispatched: The order has been shipped or dispatched to the customer.

Delivered: The order has been successfully delivered to the customer.

Canceled: The order has been canceled, either by the customer or by the system administrator.

Refunded: The order has been refunded, indicating a financial transaction reversing the purchase.

On Hold: The order is temporarily on hold, perhaps awaiting additional information or approval.

Completed: The order has been processed, shipped, and delivered, and is considered complete.

 */
