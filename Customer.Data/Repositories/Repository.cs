using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Customer.Data.IRepositories;
using Customer.Domain;
using Customer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : ModelBase
    {
        private readonly CustomerDbContext _dbContext;
        protected readonly DbSet<TModel> ModelDbSets;

        public Repository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException();
            ModelDbSets = _dbContext.Set<TModel>();
        }
        
        
        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TModel>> GetListAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).ToListAsync();
        }

        public IQueryable<TModel> Queryable(Expression<Func<TModel, bool>> predicate)
        {
            return ModelDbSets.Where(predicate);
        }

        public void Add(TModel entity)
        {
            ModelDbSets.Add(entity);
        }

        public void AddRange(IEnumerable<TModel> entities)
        {
            ModelDbSets.AddRange(entities);
        }

        public void Remove(TModel entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);
            
            ModelDbSets.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TModel> entities)
        {
            foreach (var entity in entities)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);

                ModelDbSets.Remove(entity);
            }
        }

        public void Update(TModel entity)
        {
            ModelDbSets.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}