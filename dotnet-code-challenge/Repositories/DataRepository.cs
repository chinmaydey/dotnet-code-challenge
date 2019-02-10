using dotnet_code_challenge.Contexts;
using System.Collections.Generic;

namespace dotnet_code_challenge.Repositories
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        protected IDBContext<TEntity> _dbContext;

        public DataRepository(IDBContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.GetAll();
        }
    }
}
