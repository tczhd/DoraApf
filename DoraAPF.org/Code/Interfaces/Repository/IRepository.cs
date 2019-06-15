using DoraAPF.org.Data.Entities;
using System.Collections.Generic;

namespace DoraAPF.org.Code.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void AddOnly(T entity);
        void Update(T entity);
        void UpdateOnly(T entity);
        void Delete(T entity);
        int Count(ISpecification<T> spec);
        void SaveAll();
    }
}
