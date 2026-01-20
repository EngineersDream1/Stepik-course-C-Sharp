using Domain.Security.Dtos;

namespace Application.Auth.Commands.Register
{
    public record RegisterCommand(RegisterUserRequestDto RegisterDto)
        : ICommand<RegisterResult>;

    public record RegisterResult(IdentityUserResponseDto Result);
}
