using Mapster;
using OpenDinner.Application.Authentication.Command.Register;
using OpenDinner.Application.Authentication.Queries.Login;
using OpenDinner.Application.Services.Authentication.Common;
using OpenDinner.Contracts.Authentication;

namespace OpenDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
