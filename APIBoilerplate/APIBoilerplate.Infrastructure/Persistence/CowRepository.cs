namespace APIBoilerplate.Infrastructure.Persistence
{
    using APIBoilerplate.Application.Common.Interfaces.Persistence;
    using APIBoilerplate.Domain.CowAggregate;
    using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CowRepository : ICowRepository
    {
        private static readonly List<Cow> _cows = new ();
        public Task<Cow> AddCowAsync(Cow cow)
        {
            _cows.Add(cow);
            return Task.FromResult(cow);
        }

        public Task<int> GetCowCountAsync(FarmId farmId)
        {
            var cowCount = _cows.FindAll(c => c.FarmId == farmId).Count;
            return Task.FromResult(cowCount);
        }
    }

}