using System;

namespace Business
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        int Save();
    }
}
