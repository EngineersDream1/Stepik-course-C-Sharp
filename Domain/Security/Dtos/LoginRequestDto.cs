using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Security.Dtos
{
    public record LoginRequestDto(
        string Email,
        string Password        
    );
}
