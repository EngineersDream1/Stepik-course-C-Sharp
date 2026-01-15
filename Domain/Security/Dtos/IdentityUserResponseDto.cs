using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Security.Dtos
{
    public record IdentityUserResponseDto(
        string Username,
        string Email,
        string JwtToken        
    );
}
