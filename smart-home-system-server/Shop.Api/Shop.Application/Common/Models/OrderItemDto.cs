namespace Shop.Application.Common.Models;

public record OrderItemDto(int OrderItemId, int OrderId, int ProductId,
                           int Quantity, int PriceAtPurchase);
