using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CDNVNONE.Entities;

namespace CDNVNONE.Repository
{
    public abstract class GenericRepository<T, TContext> : IGenericRepository<T, TContext> 
        where T:BaseEntity 
        where TContext: DbContext
        {
        protected DbContext Entities;
        protected readonly IDbSet<T> Dbset;

        protected GenericRepository(TContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {

            return Dbset.AsEnumerable();
        }
        public T GetById(params object[] keyObjects)
        {

            var query = Dbset.Find(keyObjects);
            return query;
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            var query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}
