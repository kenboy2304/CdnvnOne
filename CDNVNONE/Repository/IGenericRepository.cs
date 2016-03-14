using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using CDNVNONE.Entities;

namespace CDNVNONE.Repository
{
    public interface IGenericRepository<T,TConext> where T : BaseEntity where TConext:DbContext
    {

        IEnumerable<T> GetAll();
        T GetById(object[] keyObjects);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
