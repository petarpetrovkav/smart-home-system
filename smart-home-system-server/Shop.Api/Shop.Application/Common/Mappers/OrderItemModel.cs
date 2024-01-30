using Shop.Application.Common.Models;
using Shop.Entities;

namespace Shop.Application.Common.Mappers;

public static class OrderItemModel
{
    public static OrderItem ToOrderItem(this OrderItemDto orderItemModel, int OrderId)
    {

        return new OrderItem()
        {
            PriceAtPurchase = orderItemModel.PriceAtPurchase,
            Quantity = orderItemModel.Quantity,
            ProductId = orderItemModel.ProductId,
            OrderId = OrderId,
        };
    }
}
