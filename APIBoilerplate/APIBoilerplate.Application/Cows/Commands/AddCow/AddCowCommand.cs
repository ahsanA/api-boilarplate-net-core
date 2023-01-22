using APIBoilerplate.Domain.CowAggregate;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
using APIBoilerplate.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace APIBoilerplate.Application.Cows.Commands.AddCow
{
    public record AddCowCommand(
         double InitialWeight, 
        double InitialPrice, 
        DateTime OnBoardingDate,
        string AddedBy,
        string FarmId) : IRequest<ErrorOr<Cow>>;
}