using Shop.Application.Common.Models;
using Shop.Entities;

namespace Shop.Application.Common.Mappers;

public static class OrderItemModel
{
    /*   public static OrderItem ToOrderItem(this OrderItemDto orderItemModel, int OrderId)
       {

           return new OrderItem()
           {
               PriceAtPurchase = orderItemModel.PriceAtPurchase,
               Quantity = orderItemModel.Quantity,
               ProductId = orderItemModel.ProductId,
               OrderId = OrderId,
           };
       }*/

    public static Order ToOrder(int totalCost, Guid address, string user)
    {
        return new Order()
        {
            TotalCost = totalCost,
            PaymentMethod = "Test",
            OrderStatus = OrderStatus.Processing,
            AddressId = address,
            UserId = user,
            OrderDate = DateTime.Now,
        };
    }
}
