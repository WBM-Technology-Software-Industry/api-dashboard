namespace Dashboard.Models;

/// <summary>
/// Item de um Pedido
/// </summary>
public class PedidoItem
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public required string Item { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public string? Observacao { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt {  get; set; } = DateTime.UtcNow;

    // Relacionamento: PedidoItem pertence a um Pedido
    public Pedido Pedido { get; set; } = null!;
}
