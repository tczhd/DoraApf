using DoraAPF.org.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoraAPF.org.Code.Interfaces.Repository
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        void UpdateOnlyAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        void AddOnlyAsync(T entity);
        Task SaveAllAsync();
    }
}
