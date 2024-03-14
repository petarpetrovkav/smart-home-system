namespace Shop.Application.Common.Models;

public record CartItemDto(int CartItemId, int ShoppingCartId, int ProductId, int Quantity, List<ProductDto> Products);
