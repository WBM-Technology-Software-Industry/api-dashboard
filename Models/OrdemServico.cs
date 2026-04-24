namespace Dashboard.Models;

/// <summary>
/// Modelo de Ordem de Serviço
/// Equivalente ao OrdemServico.php do Laravel
/// </summary>
public class OrdemServico
{
    public int Id { get; set; }

    public required string Numero { get; set; }

    public string? Tipo { get; set; }

    public string? OpRef { get; set; }

    public string? Descricao { get; set; }

    public string? Cliente { get; set; }

    public string? Status { get; set; }

    public string? Prioridade { get; set; }

    public string? Responsible { get; set; }

    public string? Sector { get; set; }

    public DateTime? DataAbertura { get; set; }

    public DateTime? DataPrevista { get; set; }

    public DateTime? IniciadoEm { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Relacionamentos

    // OrdemServico ↔ Pedido (N:N)
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
