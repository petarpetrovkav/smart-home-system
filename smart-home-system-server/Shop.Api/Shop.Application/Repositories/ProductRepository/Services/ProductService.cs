using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.ProductRepository.Interface;
using Shop.Entities;

namespace Shop.Application.Repositories.ProductRepository.Services
{
    public class ProductService : IProductService
    {
        private readonly IShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(IShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> Get(string productId)
        {
            Product product = await _dbContext.Products.FindAsync(Guid.Parse(productId));
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetAll()
        {
            List<Product> dbProducts = await _dbContext.Products.ToListAsync();
            List<ProductDto> productDtos = new();

            foreach (Product item in dbProducts)
            {
                ProductDto productDto = _mapper.Map<Product, ProductDto>(item);
                productDtos.Add(productDto);
            }

            return productDtos;
        }

        public async Task<List<ProductDto>> GetAllProductByCategory(string productCategoryId)
        {
            List<Product> dbProducts = await _dbContext.Products.Where(product => product.ProductCategoryId == Guid.Parse(productCategoryId)).ToListAsync();
            List<ProductDto> productDtos = new();

            foreach (Product item in dbProducts)
            {
                ProductDto productDto = _mapper.Map<Product, ProductDto>(item);
                productDtos.Add(productDto);
            }

            return productDtos;
        }
    }
}
