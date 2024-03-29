using Shop.Entities;

namespace Shop.Application.Common.Models;

public record ProductDto(Guid ProductId, Guid ProductCategoryId, string ProductName, string Description,
                         int Price, int StockQuantity, string ImageUrl, ProductCategory ProductCategory);     /*   , ProductCategory ProductCategory*/