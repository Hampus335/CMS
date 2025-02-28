using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected DataContext()
        {

        }

        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<ProjectUpdateform> Projects { get; set; }

    }
}
