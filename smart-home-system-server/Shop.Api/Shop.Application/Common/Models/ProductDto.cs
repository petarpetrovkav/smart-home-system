using Shop.Entities;

namespace Shop.Application.Common.Models;

public record ProductDto(int ProductId, int ProductCategoryId, string ProductName, string Description,
                         int Price, int StockQuantity, string ImageUrl, ProductCategory ProductCategory);
