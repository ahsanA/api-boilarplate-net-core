using APIBoilerplate.Domain.CowAggregate;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;

namespace APIBoilerplate.Application.Common.Interfaces.Persistence
{
    public interface ICowRepository
    {
        Task<Cow> AddCowAsync(Cow cow);
        Task<int> GetCowCountAsync(FarmId farmId);
    }
}