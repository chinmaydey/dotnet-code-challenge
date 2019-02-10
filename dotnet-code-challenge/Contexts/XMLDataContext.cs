using dotnet_code_challenge.Models;
using System.Collections.Generic;

namespace dotnet_code_challenge.Contexts
{
    /// <summary>
    /// Context responsible for getting XML data
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class XMLDataContext<TEntity> : DBContext, IDBContext<TEntity> where TEntity : class
    {
        public XMLDataContext(string connectionString) : base(connectionString)
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

        /// <summary>
        /// Gets horse data from xml
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetHorseData()
        {
            List<TEntity> returnData = null;
           

            return returnData;
        }

        /// <summary>
        /// Get price data from xml
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetPriceData()
        {
            List<TEntity> returnData = null;           

            return returnData;
        }
    }
}
