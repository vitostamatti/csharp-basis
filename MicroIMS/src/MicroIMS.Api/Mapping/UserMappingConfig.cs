using Mapster;
using MicroIMS.Application.Users.Commands.CreateUser;
using MicroIMS.Contracts.Users;

namespace MicroIMS.Api.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateUserRequest, CreateUserCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<GetUserByIdResult, UserResponse>()
            .Map(dest => dest, src => src);
    }
}