using Application.Auth.Commands.Register;
using Application.Auth.Dtos;
using Application.Auth.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IResult> login(LoginDto dto)
        {
            var query = new LoginQuery(dto);
            var result = await mediator.Send(query);

            return Results.Ok(new { result = result.Result });
        }

        [HttpPost("register")]
        public async Task<IResult> Register(RegisterDto dto)
        {
            var command = new RegisterCommand(dto);
            var result = await mediator.Send(command);

            return Results.Ok(new {result = result.Result});

        }
    }
}
