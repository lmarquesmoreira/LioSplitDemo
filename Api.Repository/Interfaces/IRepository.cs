using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Repository.Interfaces
{
    public interface IRepository<T> where T: class, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAsync();
        Task<int> SaveAsync(T model);
    }
}
