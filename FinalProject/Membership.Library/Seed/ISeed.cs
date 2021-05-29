using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Membership.Library.Seed
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }

    public abstract class DataSeed : ISeed
    {
        private readonly DbContext _dbContext;

        protected DataSeed(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }

        public abstract Task SeedAsync();
    }
}