using Application.Auth.Dtos;
using Domain.Security.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Queries.Login
{
    public record LoginQuery(LoginDto LoginDto) : IQuery<LoginResult>;

    public record LoginResult(AuthResponseDto Result);

}
