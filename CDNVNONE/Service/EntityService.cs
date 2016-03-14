using System;
using System.Collections.Generic;
using System.Data.Entity;
using CDNVNONE.Entities;
using CDNVNONE.Repository;

namespace CDNVNONE.Service
{
    public abstract class EntityService<T,TContext> : IEntityService<T> where T : BaseEntity where TContext:DbContext
    {
        private IUnitOfWork<TContext> _unitOfWork;
        private IGenericRepository<T,TContext> _repository;

        public EntityService(IUnitOfWork<TContext> unitOfWork, IGenericRepository<T,TContext> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
