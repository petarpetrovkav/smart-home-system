using Shop.Application.Common.Models;
using Shop.Entities;

namespace Shop.Application.Common.Mappers;

public static class CartItemModel
{
    public static CartItem ToCartItem(this CartItemDto CartItemDtoModel, Guid ShoppingCartId)
    {
        return new CartItem()
        {
            ProductId = Guid.Parse(CartItemDtoModel.ProductId),
            ShoppingCartId = ShoppingCartId,
            Quantity = CartItemDtoModel.Quantity,
        };
    }

    public static CartItemDto ToCartItemDto(this CartItem CartItem)
    {
        return new CartItemDto(
            CartItem.ProductId.ToString(),
            CartItem.Quantity,
            CartItem.ShoppingCartId.ToString()
        );
    }
}
