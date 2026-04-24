namespace Dashboard.Models;

/// <summary>
/// Modelo de OP (Ordem de Produção)
/// Equivalente ao Op.php do Laravel
/// </summary>
public class Op
{
    public int Id { get; set; }

    public required string Numero { get; set; }

    public string? Item { get; set; }

    public string? Responsavel { get; set; }

    public string? Setor { get; set; }

    public string? Prioridade { get; set; }

    public string? Status { get; set; }

    public DateTime? Abertura { get; set; }

    public DateTime? PrevEntrega { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Relacionamentos

    // Op ↔ Pedido (N:N)
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
