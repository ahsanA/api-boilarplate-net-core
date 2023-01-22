using APIBoilerplate.Domain.CowAggregate;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
using APIBoilerplate.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace APIBoilerplate.Application.Cows.Commands.AddCow
{
    public class AddCowCommandHandler : IRequestHandler<AddCowCommand, ErrorOr<Cow>>
    {
        // private readonly ICowRepository _cowRepository;

        // public AddCowCommandHandler(ICowRepository cowRepository)
        // {
        //     _cowRepository = cowRepository;
        // }

        public async Task<ErrorOr<Cow>> Handle(AddCowCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            //TODO:Generate a display number
            //Add a new cow
            var cow = Cow.Create(GenerateDisplayNumber(request.FarmId),
                                 request.InitialWeight,
                                 request.InitialPrice,
                                 request.OnBoardingDate,
                                 DateTime.UtcNow,
                                 UserId.Create(request.AddedBy),
                                 FarmId.Create(request.FarmId));
            //Persist the cow
            //Return the cow
            return default!;
        }

        protected string GenerateDisplayNumber(string farmId)
        {
            //Generate a display number
            return default!;
        }
    }
}