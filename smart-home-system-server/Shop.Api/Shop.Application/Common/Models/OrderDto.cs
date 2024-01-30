using Shop.Entities;

namespace Shop.Application.Common.Models;

public record OrderDto(int OrderId, int AddressId, string PaymentMethod,
                       OrderStatus OrderStatus, DateTime OrderDate, int TotalCost, string UserId, List<OrderItemDto> ListOrderItems);