using GEMEscolar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);

        Task<TEntity> GetIdAsync(Guid id);
        TEntity GetId(Guid id);

        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAll();

        Task UpdateAsync(TEntity entity);
        void Update(TEntity entity);

        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);

        Task RemoveAsync(Guid id);
        void Remove(Guid id);

        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);


        Task<int> SaveChangesAsync();
        int SaveChanges();

        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);

        IQueryable<TEntity> Queryable(bool asNoTracking = true);

    }
}
