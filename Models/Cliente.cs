namespace Dashboard.Models;

/// <summary>
/// Modelo de Cliente
/// Equivalente ao Cliente.php do Laravel
/// </summary>
public class Cliente
{
    public int Id { get; set; }

    public required string Nome { get; set; }

    public string? Documento { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
