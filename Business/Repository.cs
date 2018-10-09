using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _Context;

        public Repository(DbContext Context)
        {
            _Context = Context;
        }

        public void Add(TEntity entity)
        {
            var res = _Context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
        }
    }
}
