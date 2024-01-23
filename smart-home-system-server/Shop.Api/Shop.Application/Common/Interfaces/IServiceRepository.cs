using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Interfaces
{
    public interface IServiceRepository<T>
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<string> Delete(Guid id);
        Task<string> Add(T entity, string Id);
        Task<string> Update(T entity);
    }
}
