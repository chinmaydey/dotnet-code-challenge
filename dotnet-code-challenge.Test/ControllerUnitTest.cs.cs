using dotnet_code_challenge.Controller;
using dotnet_code_challenge.ExtendedModels;
using dotnet_code_challenge.Models;
using dotnet_code_challenge.Repositories;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class ControllerUnitTest
    {
        [Fact]
        public void TestVerifyingSortedHorsesAndPrice()
        {
            var horseXMLData = new List<Horse>();
            horseXMLData.Add(new Horse() { HorseNumber = 1, HorseName = "H1" });
            var horseJSONData = new List<Horse>();
            horseJSONData.Add(new Horse() { HorseNumber = 2, HorseName = "H2" });
            var priceXMLData = new List<Price>();
            priceXMLData.Add(new Price() { HoreseNumber = 1, HorsePrice = 8.5 });
            var priceJSONData = new List<Price>();
            priceJSONData.Add(new Price() { HoreseNumber = 2, HorsePrice = 6.5 });

            Mock<IHorseDataRepository> mockHorseXMLDataRepository = new Mock<IHorseDataRepository>();
            mockHorseXMLDataRepository.Setup(t => t.GetAll()).Returns(horseXMLData);

            Mock<IHorseDataRepository> mockHorseJSONDataRepository = new Mock<IHorseDataRepository>();
            mockHorseJSONDataRepository.Setup(t => t.GetAll()).Returns(horseJSONData);

            Mock<IPriceDataRepository> mockPriceXMLDataRepository = new Mock<IPriceDataRepository>();
            mockPriceXMLDataRepository.Setup(t => t.GetAll()).Returns(priceXMLData);

            Mock<IPriceDataRepository> mockPriceJSONDataRepository = new Mock<IPriceDataRepository>();
            mockPriceJSONDataRepository.Setup(t => t.GetAll()).Returns(priceJSONData);

            var sut = new HorseOrderingController(mockHorseXMLDataRepository.Object, mockPriceXMLDataRepository.Object,
            mockHorseJSONDataRepository.Object, mockPriceJSONDataRepository.Object);

            var result = (List<HorsePrice>)(sut.GetSortedHorsesByPrice());

            Assert.True(result[0].HorseName == "H2" && result[1].HorseName == "H1");
        }
    }
}
