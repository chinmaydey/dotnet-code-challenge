using dotnet_code_challenge.Contexts;
using dotnet_code_challenge.Controller;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // get xml file path
            var info = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            var xmlFilePath = Path.Combine(info.Parent.Parent.Parent.FullName, @"FeedData\Caulfield_Race1.xml");
            var jsonFilePath = Path.Combine(info.Parent.Parent.Parent.FullName, @"FeedData\Wolferhampton_Race1.json");

            var horseRepositoryxml = new HorseDataRepository(new XMLDataContext<Horse>(xmlFilePath));
            var priceRepositoryxml = new PriceDataRepository(new XMLDataContext<Price>(xmlFilePath));

            var horseRepositoryjson = new HorseDataRepository(new JSONDataContext<Horse>(jsonFilePath));
            var priceRepositoryjson = new PriceDataRepository(new JSONDataContext<Price>(jsonFilePath));

            var horseOrderingController = new HorseOrderingController(horseRepositoryxml, priceRepositoryxml, horseRepositoryjson, priceRepositoryjson);
            horseOrderingController.DisplayData(horseOrderingController.GetSortedHorsesByPrice());

            Console.ReadLine();
        }
    }
}
