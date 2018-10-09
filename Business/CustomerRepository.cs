using DataAccess;

namespace Business
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public DataContext Context
        {
            get { return Context as DataContext; }
        }

        public CustomerRepository(DataContext context) : base(context)
        {

        }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {

    }
}