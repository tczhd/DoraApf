
using Microsoft.EntityFrameworkCore;
using DoraAPF.org.Data.Entities;
using DoraAPF.org.Facade.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.Data.Repository.Base
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DoraAPFContext _dbContext;

        public EfRepository(DoraAPFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            //var queryableResultWithIncludes = spec.Includes
            //    .Aggregate(_dbContext.Set<T>().AsQueryable(),
            //        (current, include) => current.Include(include));

            //// modify the IQueryable to include any string-based include statements
            //var secondaryResult = spec.IncludeStrings
            //    .Aggregate(queryableResultWithIncludes,
            //        (current, include) => current.Include(include));

            //// return the result of the query using the specification's criteria expression
            //return secondaryResult
            //                .Where(spec.Criteria)
            //                .AsEnumerable();
              return ApplySpecification(spec).ToList();
        }
        //public async Task<List<T>> ListAsync(ISpecification<T> spec)
        //{
        //    // fetch a Queryable that includes all expression-based includes
        //    var queryableResultWithIncludes = spec.Includes
        //        .Aggregate(_dbContext.Set<T>().AsQueryable(),
        //            (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    var secondaryResult = spec.IncludeStrings
        //        .Aggregate(queryableResultWithIncludes,
        //            (current, include) => current.Include(include));

        //    // return the result of the query using the specification's criteria expression
        //    return await secondaryResult
        //                    .Where(spec.Criteria)
        //                    .ToListAsync();
        //}

        public void AddOnly(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddOnlyAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void UpdateOnly(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void UpdateOnlyAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }


        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAllAsync()
        {
           await  _dbContext.SaveChangesAsync();
        }
        public int Count()
        {
            return _dbContext.Set<T>().AsNoTracking().Count();
        }


        public int Count(ISpecification<T> spec)
        {
            return ApplySpecification(spec).AsNoTracking().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).AsNoTracking().CountAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
