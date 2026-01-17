using Domain.Security;

namespace Api.Security.Services
{
    public class JwtSecurityService(IConfiguration configuration) : IJwtSecurityService
    {
        public string CreateToken(CustomIdentityUser user)
        {
            string secretKey = configuration["AuthSettings:SecretKey"]!;
            throw new NotImplementedException();
        }
    }
}
