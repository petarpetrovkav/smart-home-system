using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Repositories.ProductRepository.Interface
{
    public interface IProductService : IServiceRepository<ProductDto>
    {

    }
}
