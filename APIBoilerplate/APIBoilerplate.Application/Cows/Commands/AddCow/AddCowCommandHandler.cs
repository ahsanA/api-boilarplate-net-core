using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.CowAggregate;
using APIBoilerplate.Domain.FarmAgreegate.ValueObjects;
using APIBoilerplate.Domain.UserAggregate.ValueObjects;

using ErrorOr;

using MediatR;

namespace APIBoilerplate.Application.Cows.Commands.AddCow
{
    public class AddCowCommandHandler : IRequestHandler<AddCowCommand, ErrorOr<Cow>>
    {
        private readonly ICowRepository _cowRepository;

        public AddCowCommandHandler(ICowRepository cowRepository)
        {
            _cowRepository = cowRepository;
        }

        public async Task<ErrorOr<Cow>> Handle(AddCowCommand request, CancellationToken cancellationToken)
        {            
            //TODO:Generate a display number
            //Add a new cow
            var cow = Cow.Create(await GenerateDisplayNumber(request.FarmId),
                                 request.InitialWeight,
                                 request.InitialPrice,
                                 request.OnBoardingDate,
                                 DateTime.UtcNow,
                                 UserId.Create(request.AddedBy),
                                 FarmId.Create(request.FarmId));
            //Persist the cow
            await _cowRepository.AddCowAsync(cow);
            //Return the cow
            return cow;
        }

        protected async Task<string> GenerateDisplayNumber(string farmId)
        {
            //Generate a display number
            FarmId convertedFarmId = FarmId.Create(farmId);
            var cowCount = await _cowRepository.GetCowCountAsync(convertedFarmId);
            var splitedFarmId = farmId.Split("-");
            var displayNumber = $"{splitedFarmId[0]}-{cowCount + 1}";
            return displayNumber;
        }
    }
}