using Application.Security.Services;
using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands.Login
{
    public class LoginCommandHandler(UserManager<CustomIdentityUser> manager, IJwtSecurityService jwtSecurityService) : ICommandHandler<LoginCommand, IdentityUserResponseDto>
    {
        public async Task<IdentityUserResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await manager.FindByEmailAsync(request.LoginDto.Email);

            if (user == null)
            {
                throw new NotFoundException("Не найден пользователь с таким Email!");
            }

            var result = await manager.CheckPasswordAsync(user, request.LoginDto.Password);

            if (result)
            {
                var response = new IdentityUserResponseDto(
                    user.UserName!,
                    user.Email!,
                    jwtSecurityService.CreateToken(user)
                );

                return response;
            }

            throw new NotFoundException("По введенным данным пользователь не найден!");
        }
    }
}
