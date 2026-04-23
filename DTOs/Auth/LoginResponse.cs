namespace Dashboard.DTOs.Auth;

/// <summary>
/// DTO para resposta de login
/// Equivalente ao JSON retornado no login() do Laravel
/// </summary>
public class LoginResponse
{
    public required string Message { get; set; }
    public required Users.UserDto User { get; set; }
    public required string Token { get; set; }
}
