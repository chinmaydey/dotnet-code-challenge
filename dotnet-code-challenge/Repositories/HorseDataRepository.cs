using dotnet_code_challenge.Contexts;
using dotnet_code_challenge.Models;

namespace dotnet_code_challenge.Repositories
{
    public class HorseDataRepository : DataRepository<Horse>, IHorseDataRepository
    {
        public HorseDataRepository(IDBContext<Horse> dbContext) : base(dbContext)
        {

        }
    }
}
