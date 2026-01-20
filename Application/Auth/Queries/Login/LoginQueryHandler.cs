using Application.Security.Services;
using Domain.Security;
using Domain.Security.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Queries.Login
{
    public class LoginQueryHandler(
        UserManager<CustomIdentityUser> manager,
        IJwtSecurityService jwtSecurityService) 
        : IQueryHandler<LoginQuery, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginQuery request, CancellationToken cancellationToken)
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

                return new LoginResult(response);
            }
            else
            {
                throw new NotFoundException("Неверный пароль!");
            }

            throw new NotFoundException("По введенным данным пользователь не найден!");
        }
    }
}
