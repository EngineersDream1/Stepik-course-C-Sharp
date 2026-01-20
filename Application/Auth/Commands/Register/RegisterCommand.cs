using Application.Auth.Dtos;
using Domain.Security.Dtos;

namespace Application.Auth.Commands.Register
{
    public record RegisterCommand(RegisterDto RegisterDto)
        : ICommand<RegisterResult>;

    public record RegisterResult(AuthResponseDto Result);
}
