using Shop.Application.Common.Models;
using Shop.Entities;

namespace Shop.Application.Common.Mappers;

public static class CartItemModel
{
    public static CartItem ToCartItem(this CartItemDto CartItemDtoModel, string ShoppingCartId)
    {
        return new CartItem()
        {
            ProductId = CartItemDtoModel.ProductId,
            ShoppingCartId = Int32.Parse(ShoppingCartId),
            Quantity = CartItemDtoModel.Quantity,
        };
    }
}
