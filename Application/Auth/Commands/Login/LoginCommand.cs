using Domain.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Commands.Login
{
    public record LoginCommand(LoginRequestDto LoginDto) : ICommand<LoginResult>;

    public record LoginResult(IdentityUserResponseDto Result);
    
}
