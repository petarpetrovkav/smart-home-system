using Shop.Application.Common.Models;
using Shop.Entities;

namespace Shop.Application.Common.Mappers;

public static class CartItemModel
{
    public static CartItem ToCartItem(this CartItemDto CartItemDtoModel, int ShoppingCartId)
    {
        return new CartItem()
        {
            ProductId = CartItemDtoModel.ProductId,
            /*ShoppingCartId = Int32.Parse(ShoppingCartId),*/
            ShoppingCartId = ShoppingCartId,
            Quantity = CartItemDtoModel.Quantity,

        };
    }

  /*  public static CartItemDto ToCartItemDto(this CartItem CartItem)
    {

        return new CartItemDto()
        {
            CartItemId = CartItem.CartItemId,
            ShoppingCartId = CartItem.ShoppingCartId,
            ProductId = CartItem.ProductId,
            Quantity = CartItem.Quantity,
            Products = null,
        };
    }*/
}
