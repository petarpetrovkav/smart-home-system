using Shop.Application.Common.Models;

namespace Shop.Application.Repositories.ProductRepository.Interface;

public interface IProductService // : IServiceRepository<ProductDto>
{
    Task<ProductDto> Get(string id);
    Task<List<ProductDto>> GetAll();
    Task<List<ProductDto>> GetAllProductByCategory(string id);
}
