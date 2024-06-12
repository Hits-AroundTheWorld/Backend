using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Users
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T?> GetByIdAsync(Guid id);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task SaveChangeAsync();
    }
}
