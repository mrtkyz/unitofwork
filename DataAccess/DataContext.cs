using System.Data.Entity;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Customer> Customer { get; set; }
    }
}