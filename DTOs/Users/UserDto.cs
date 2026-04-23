namespace Dashboard.DTOs.Users;

/// <summary>
/// DTO de usuário (sem informações sensíveis como senha)
/// </summary>
public class UserDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
}
