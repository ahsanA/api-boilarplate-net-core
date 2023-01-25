using APIBoilerplate.Application.Cows.Commands.AddCow;
using APIBoilerplate.Contracts.Cows;
using APIBoilerplate.Domain.CowAggregate;

using Mapster;

namespace APIBoilerplate.Api.Common.Mapping
{
    public class CowMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(AddCowRequest Request,  string AddedBy, string FarmId), AddCowCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.AddedBy, src => src.AddedBy)
                .Map(dest => dest.FarmId, src => src.FarmId);

            config.NewConfig<Cow, AddCowResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.FarmId, src => src.FarmId.Value);
        }
    }
}