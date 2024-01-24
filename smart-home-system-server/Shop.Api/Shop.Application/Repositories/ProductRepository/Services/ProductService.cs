using Shop.Application.Common.Models;
using Shop.Application.Repositories.ProductRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Repositories.ProductRepository.Services
{
    public class ProductService : IProductService
    {
        public Task<string> Add(ProductDto entity, string Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
