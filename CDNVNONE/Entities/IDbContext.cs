using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDNVNONE.Entities
{
    public interface IDbContext
    {
    }

    public class OneDbContext<T> : DbContext where T: DbContext
    {
        public T Context { get; set; }
        public OneDbContext(T context)
        {
            Context = context;
        }
    }
}
