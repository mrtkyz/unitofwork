using DataAccess;

namespace Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IProductRepository ProductRepository { get; private set; }

        public ICustomerRepository CustomerRepository { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}