using dotnet_code_challenge.Contexts;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Repositories
{
    public class PriceDataRepository : DataRepository<Price>, IPriceDataRepository
    {
        public PriceDataRepository(IDBContext<Price> dbContext) : base(dbContext)
        {

        }
    }
}
