using DataAccess;

namespace Business
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public DataContext Context
        {
            get { return Context as DataContext; }
        }

        public ProductRepository(DataContext context) : base(context)
        {
        }
    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}
