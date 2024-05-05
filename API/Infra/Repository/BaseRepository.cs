// using Domain.Model;
// using Microsoft.EntityFrameworkCore;

// namespace AutologApi.API.Infra.Repository
// {
//     public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
//     {
//         private readonly AppDbContext _appDbContext;
//         private DbSet<T> entities;

//         public BaseRepository(AppDbContext appDbContext)
//         {
//             _appDbContext = appDbContext;
//             entities = _appDbContext.Set<T>();
//         }

//         public void Delete(T entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             entities.Remove(entity);
//             _appDbContext.SaveChanges();
//         }

//         public T? GetById(Guid id)
//         {
//             return entities.SingleOrDefault(c => c.Id == id);
//         }

//         public System.Collections.Generic.IEnumerable<T> GetAll()
//         {
//             return entities.AsEnumerable();
//         }

//         public void Insert(T entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             entities.Add(entity);
//             _appDbContext.SaveChanges();
//         }

//         public void Remove(T entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             entities.Remove(entity);
//         }

//         public void SaveChanges()
//         {
//             _appDbContext.SaveChanges();
//         }

//         public void Update(T entity)
//         {
//             if (entity == null)
//             {
//                 throw new ArgumentNullException("entity");
//             }
//             entities.Update(entity);
//             _appDbContext.SaveChanges();
//         }
//     }
// }