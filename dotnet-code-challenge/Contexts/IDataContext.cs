using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Contexts
{
    public interface IDBContext<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
