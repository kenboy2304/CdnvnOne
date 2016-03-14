using System;
using System.Data.Entity;

namespace CDNVNONE.Repository
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
