using dotnet_code_challenge.ExtendedModels;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge.Controller
{
    public class HorseOrderingController
    {
        private readonly IEnumerable<Horse> horsesxml = null;
        private readonly IEnumerable<Price> pricesxml = null;
        private readonly IEnumerable<Horse> horsesjson = null;
        private readonly IEnumerable<Price> pricesjson = null;

        /// <summary>
        /// Construction - Injecting xml and json data repository for data retrival
        /// Assumption - Origin of horse and price data may change in future so it is better to keep their repositories
        /// </summary>
        /// <param name="horseDataRepositoryxml"></param>
        /// <param name="priceDataRepositoryxml"></param>
        /// <param name="horseDataRepositoryjson"></param>
        /// <param name="priceDataRepositoryjson"></param>
        public HorseOrderingController(IHorseDataRepository horseDataRepositoryxml, IPriceDataRepository priceDataRepositoryxml,
            IHorseDataRepository horseDataRepositoryjson, IPriceDataRepository priceDataRepositoryjson)
        {
            horsesxml = horseDataRepositoryxml.GetAll();
            horsesjson = horseDataRepositoryjson.GetAll();
            pricesxml = priceDataRepositoryxml.GetAll();
            pricesjson = priceDataRepositoryjson.GetAll();
        }

        /// <summary>
        /// Get horse names sorted by price
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HorsePrice> GetSortedHorsesByPrice()
        {
            var xmlHorsePrices = horsesxml.Join(pricesxml, t => t.HorseNumber, s => s.HoreseNumber,
            (t, s) => new HorsePrice { HorseName = t.HorseName, Price = s.HorsePrice });

            var jsonHorsePrices = horsesjson.Join(pricesjson, t => t.HorseNumber, s => s.HoreseNumber,
            (t, s) => new HorsePrice { HorseName = t.HorseName, Price = s.HorsePrice });

            return xmlHorsePrices.Union(jsonHorsePrices).OrderBy(t => t.Price).ToList();
        }

        /// <summary>
        /// Print hourse and their prices
        /// </summary>
        /// <param name="horsePrices"></param>
        public void DisplayData(IEnumerable<HorsePrice> horsePrices)
        {
            if (horsePrices != null)
            {
                foreach (var item in horsePrices)
                {
                    Console.WriteLine($"Horse Name: { item.HorseName }, Price: { item.Price }");
                }
            }
        }
    }
}
