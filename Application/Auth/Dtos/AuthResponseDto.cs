namespace Application.Auth.Dtos
{
    public record AuthResponseDto(
        string Username,
        string Email,
        string Token
    );
}
