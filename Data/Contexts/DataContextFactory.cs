using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    internal class DataContextFactory
    {
        public class BloggingContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Hampus\\Documents\\Database.mdf;Integrated Security=True;Connect Timeout=30");

                return new DataContext(optionsBuilder.Options);
            }
        }
    }
}
