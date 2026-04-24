namespace Dashboard.Models;

/// <summary>
/// Modelo de Pedido
/// Equivalente ao Pedido.php do Laravel
/// </summary>
public class Pedido
{
    public int Id { get; set; }

    public required string Numero { get; set; }

    public string? NumeroCliente { get; set; }

    public string? Cliente { get; set; }

    public string? Status { get; set; }

    public string? Prioridade { get; set; }

    public DateTime? DataEntrada { get; set; }

    public DateTime? DataPrazo { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Relacionamentos

    // Um Pedido tem muitos Items
    public ICollection<PedidoItem> Items { get; set; } = new List<PedidoItem>();

    // Pedido ↔ Op (N:N)
    public ICollection<Op> Ops { get; set; } = new List<Op>();

    // Pedido ↔ OrdemServico (N:N)
    public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();
}
