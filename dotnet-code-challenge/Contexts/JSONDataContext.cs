using dotnet_code_challenge.Models;
using System.Collections.Generic;

namespace dotnet_code_challenge.Contexts
{
    /// <summary>
    /// Context responsible for getting JSON data
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class JSONDataContext<TEntity> : DBContext, IDBContext<TEntity> where TEntity : class
    {
        public JSONDataContext(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> returnData = null;

            if (!string.IsNullOrEmpty(ConnectionString))
            {
                if (typeof(TEntity) == typeof(Horse))
                {
                    returnData = GetHorseData();
                }
                else if (typeof(TEntity) == typeof(Price))
                {
                    returnData = GetPriceData();
                }
            }

            return returnData;
        }

        public IEnumerable<TEntity> GetHorseData()
        {
            List<TEntity> returnData = null;

            return returnData;
        }

        public IEnumerable<TEntity> GetPriceData()
        {
            List<TEntity> returnData = null;

            return returnData;
        }
    }
}