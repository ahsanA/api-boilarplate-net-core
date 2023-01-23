namespace APIBoilerplate.Infrastructure.Persistence.Repositories
{
    using APIBoilerplate.Application.Common.Interfaces.Persistence;
    using APIBoilerplate.Domain.CowAggregate;
    using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CowRepository : ICowRepository
    {
        private readonly APIBoilerplateDbContext _dbContext;

        public CowRepository(APIBoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Cow> AddCowAsync(Cow cow)
        {
            _dbContext.Add(cow);
            _dbContext.SaveChanges();
            return Task.FromResult(cow);
        }

        public Task<int> GetCowCountAsync(FarmId farmId)
        {
            var cowCount = _dbContext.Cows.Count(c => c.FarmId == farmId);
            return Task.FromResult(cowCount);
        }
    }

}