using Domain.Model;

namespace Infra.Repository
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}