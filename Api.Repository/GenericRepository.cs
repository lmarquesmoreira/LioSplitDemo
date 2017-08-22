using Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApiDbContext _dbContext;

        public GenericRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleAsync(predicate);
        }

        public async Task<List<T>> GetAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<int> SaveAsync(T model)
        {
            _dbContext.Set<T>().Add(model);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
