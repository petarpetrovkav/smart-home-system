using Shop.Entities;

namespace Shop.Application.Common.Models;

public record CartProductDto(string ProductId, string ProductName, int Price, 
                             int StockQuantity, string ImageUrl, ProductCategory? ProductCategory, string ShoppingCartId);

