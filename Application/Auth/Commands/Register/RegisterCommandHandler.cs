using Application.Auth.Dtos;
using Application.Security.Services;
using Domain.Security;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.Register
{
    public class RegisterCommandHandler(
        UserManager<CustomIdentityUser> manager,
        IJwtSecurityService jwtSecurityService)
        : ICommandHandler<RegisterCommand, RegisterResult>
    {
        public async Task<RegisterResult> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.RegisterDto;

            if (await manager.Users.AnyAsync(
                u => u.UserName == dto.Username,
                cancellationToken))
            {
                throw new InvalidOperationException(
                    $"Пользователь с именем '{dto.Username}' уже существует");
            }

            if (await manager.Users.AnyAsync(
                u => u.Email == dto.Email,
                cancellationToken))
            {
                throw new InvalidOperationException(
                    $"Email '{dto.Email}' уже используется");
            }

            var user = new CustomIdentityUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserName = dto.Username,
                About = string.Empty
            };

            var result = await manager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(
                    $"Не удалось создать пользователя: {errors}");
            }

            var token = jwtSecurityService.CreateToken(user);

            var response = new AuthResponseDto(
                user.UserName!,
                user.Email!,
                token
            );

            return new RegisterResult(response);
        }
    }

}
