using APIBoilerplate.Application.Authentication.Common;
using APIBoilerplate.Application.Services.Authentication.Commands.Register;
using APIBoilerplate.Application.Services.Authentication.Querys.Login;
using APIBoilerplate.Contracts.Authentication;
using Mapster;

namespace APIBoilerplate.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterCommand, RegisterRequest>();
            config.NewConfig<LoginQuery, LogInRequest>();
                
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}