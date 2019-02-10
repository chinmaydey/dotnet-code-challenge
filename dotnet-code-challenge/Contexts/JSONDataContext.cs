using dotnet_code_challenge.Contexts.JSONDeserializer;
using dotnet_code_challenge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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

            try
            {
                var selections = GetSelections();

                if (selections != null)
                {
                    returnData = new List<TEntity>();

                    foreach (var selection in selections)
                    {
                        var horseName = selection.Tags?.name;

                        var horseNumber = 0;
                        Int32.TryParse(selection.Tags?.participant, out horseNumber);

                        returnData.Add((TEntity)Convert.ChangeType(new Horse() { HorseName = horseName, HorseNumber = horseNumber }, typeof(TEntity)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in JSONDataContext->GetHorseData(). {ex.ToString()}");
            }

            return returnData;
        }

        public IEnumerable<TEntity> GetPriceData()
        {
            List<TEntity> returnData = null;

            try
            {
                var selections = GetSelections();

                if (selections != null)
                {
                    returnData = new List<TEntity>();

                    foreach (var selection in selections)
                    {
                        var horseNumber = 0;
                        Int32.TryParse(selection.Tags?.participant, out horseNumber);

                        double price = 0.0;
                        double.TryParse(Convert.ToString(selection.Price), out price);

                        returnData.Add((TEntity)Convert.ChangeType(new Price() { HoreseNumber = horseNumber, HorsePrice = price }, typeof(TEntity)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in JSONDataContext->GetHorseData(). {ex.ToString()}");
            }

            return returnData;
        }

        private Selection[] GetSelections()
        {
            var jsonData = JsonConvert.DeserializeObject<Rootobject>((new StreamReader(ConnectionString)).ReadToEnd());

            return jsonData?.RawData?.Markets?[0].Selections;
        }
    }
}