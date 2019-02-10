using dotnet_code_challenge.Contexts;
using dotnet_code_challenge.Models;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class ContextUnitTest
    {
        [Fact]
        public void HorsesFromJSON_TestVerifyIfPathEmptyThenReturnNull()
        {
            var dbContext = new JSONDataContext<Horse>(string.Empty);
            Assert.True(dbContext.GetAll() == null);
        }

        [Fact]
        public void HorsesFromXML_TestVerifyIfPathEmptyThenReturnNull()
        {
            var dbContext = new XMLDataContext<Horse>(string.Empty);
            Assert.True(dbContext.GetAll() == null);
        }

        [Fact]
        public void PricesFromJSON_TestVerifyIfPathEmptyThenReturnNull()
        {
            var dbContext = new JSONDataContext<Price>(string.Empty);
            Assert.True(dbContext.GetAll() == null);
        }

        [Fact]
        public void PricesFromXML_TestVerifyIfPathEmptyThenReturnNull()
        {
            var dbContext = new XMLDataContext<Price>(string.Empty);
            Assert.True(dbContext.GetAll() == null);
        }
    }
}
