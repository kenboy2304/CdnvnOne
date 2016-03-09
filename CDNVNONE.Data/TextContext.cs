using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDNVNONE.Data
{
    [RegisterType(typeof(DbContext))]
    public class TextContext : DbContext
    {
        public TextContext():base("TextDb")
        {
        }
        public virtual DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TextContext>());
            base.OnModelCreating(modelBuilder);
        }
        
    }

    [RegisterType(typeof(DbContext))]
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("CompanyDb")
        {
        }
        public virtual DbSet<Company> Persons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CompanyContext>());
            base.OnModelCreating(modelBuilder);
        }

    }
}
