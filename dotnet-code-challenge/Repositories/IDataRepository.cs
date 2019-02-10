using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Repositories
{
    public interface IDataRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
