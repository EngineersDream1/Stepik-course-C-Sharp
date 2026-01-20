using Application.Auth.Commands.Register;
using Application.Auth.Queries.Login;
using Application.Security.Services;
using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IResult> login(LoginRequestDto dto)
        {
            var query = new LoginQuery(dto);
            var result = await mediator.Send(query);

            return Results.Ok(new { result = result.Result });
        }

        [HttpPost("register")]
        public async Task<IResult> Register(RegisterUserRequestDto dto)
        {
            var command = new RegisterCommand(dto);
            var result = await mediator.Send(command);

            return Results.Ok(new {result = result.Result});

        }
    }
}
