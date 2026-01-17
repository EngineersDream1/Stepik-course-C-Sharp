using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Security.Dtos
{
    public record RegisterUserRequestDto(
        //[MinLength(length:2, ErrorMessage = "Пароль должен быть больше 2-х символов")]
        string FullName,
        string Username,
        string Email,
        string Password
    );
}
