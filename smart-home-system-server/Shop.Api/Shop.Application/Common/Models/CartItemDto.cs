namespace Shop.Application.Common.Models;

/*public record CartItemDto(int CartItemId, int ShoppingCartId, int ProductId, int Quantity, List<ProductDto> Products);*/
public record CartItemDto(string ProductId, int Quantity, string ShoppingCartId);         /*TODO: Dali moze Quantity da bide null setirano*/