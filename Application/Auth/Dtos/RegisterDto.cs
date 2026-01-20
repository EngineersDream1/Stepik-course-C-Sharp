namespace Application.Auth.Dtos
{
    public record RegisterDto(
        string FullName,
        string Username,
        string Email,
        string Password
    );
}
