using GEMEscolar.Core.Context;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly GEMContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(GEMContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            return asNoTracking
                ? await DbSet.AsNoTracking().Where(predicate).ToListAsync()
                : await DbSet.Where(predicate).ToListAsync();
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
        {
            return !asNoTracking
                ? DbSet.Where(predicate).ToList()
                : DbSet.AsNoTracking().Where(predicate).ToList();
        }


        public virtual TEntity GetId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
            SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }
        public virtual async Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            SaveChanges();
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, bool asNoTracking)
        {
            return asNoTracking ?
                DbSet.AsNoTracking().Where(predicate) :
                DbSet.Where(predicate);
        }

        public IQueryable<TEntity> Queryable(bool asNoTracking)
        {
            return asNoTracking ?
                DbSet.AsNoTracking().AsQueryable<TEntity>().AsQueryable() :
                DbSet.AsQueryable<TEntity>().AsQueryable();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
