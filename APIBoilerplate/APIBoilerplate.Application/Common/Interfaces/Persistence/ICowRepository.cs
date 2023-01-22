using APIBoilerplate.Domain.CowAggregate;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;

namespace APIBoilerplate.Application.Common.Interfaces.Persistence
{
    public interface ICowRepository
    {
        Task<Cow> AddCowAsync(Cow cow);
        Task<int> GetCowCountAsync(FarmId farmId);
        // Task<ErrorOr<Cow>> GetCowAsync(GetCowQuery query);
        // Task<ErrorOr<Cow>> UpdateCowAsync(UpdateCowCommand command);
        // Task<ErrorOr<Cow>> DeleteCowAsync(DeleteCowCommand command);
    }
}