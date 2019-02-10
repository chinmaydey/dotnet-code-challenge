using dotnet_code_challenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge.Contexts
{
    /// <summary>
    /// Context responsible for getting XML data
    /// Used XDocument instead of class because class deserialization was throwing error
    /// Investigation would have take bit more time so used XDocument
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

            try
            {
                var doc = XDocument.Parse(File.ReadAllText(ConnectionString));

                var horses = doc.Root.Elements("races").Elements("race").Elements("horses").Elements().ToList();

                if (horses != null)
                {
                    returnData = new List<TEntity>();

                    foreach (var horse in horses)
                    {
                        var horseName = horse.Attribute("name").Value;

                        var horseNumber = 0;
                        Int32.TryParse(horse.Elements("number").FirstOrDefault().Value, out horseNumber);

                        returnData.Add((TEntity)Convert.ChangeType(new Horse() { HorseName = horseName, HorseNumber = horseNumber }, typeof(TEntity)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in XMLDataContext->GetHorseData(). {ex.ToString()}");
            }

            return returnData;
        }

        /// <summary>
        /// Get price data from xml
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetPriceData()
        {
            List<TEntity> returnData = null;

            try
            {
                var doc = XDocument.Parse(File.ReadAllText(ConnectionString));

                var horsePrices = doc.Root.Elements("races").Elements("race").Elements("prices").Elements("price").Elements("horses").Elements("horse").ToList();

                if (horsePrices != null)
                {
                    returnData = new List<TEntity>();

                    foreach (var horsePrice in horsePrices)
                    {
                        var horseNumber = 0;
                        Int32.TryParse(horsePrice.Attribute("number").Value, out horseNumber);

                        double price = 0.0;
                        double.TryParse(horsePrice.Attribute("Price").Value, out price);

                        returnData.Add((TEntity)Convert.ChangeType(new Price() { HoreseNumber = horseNumber, HorsePrice = price }, typeof(TEntity)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in XMLDataContext->GetPriceData(). {ex.ToString()}");
            }

            return returnData;
        }
    }
}
