using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Patterns
{
    public interface IRepository<T> where T : class, Models.IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
