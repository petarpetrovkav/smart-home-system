using Shop.Application.Common.Models;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Mappers;

public static class ProductModel
{
    public static CartProductDto ToCartProductDto(Product product, int Quantity, Guid ShoppingCartId)        
    {
        return new CartProductDto(
            product.ProductId.ToString(),
            product.ProductName,
            product.Price,
            Quantity,
            product.ImageUrl,
            null,
            ShoppingCartId.ToString()
        );
    }
}
