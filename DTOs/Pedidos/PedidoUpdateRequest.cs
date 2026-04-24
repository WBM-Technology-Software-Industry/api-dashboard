using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Pedidos;

/// <summary>
/// DTO para atualização de pedido
/// PUT /api/pedidos/{id}
/// </summary>
public class PedidoUpdateRequest
{
    [StringLength(100)]
    public string? Numero { get; set; }

    [StringLength(100)]
    public string? NumeroCliente { get; set; }

    [StringLength(255)]
    public string? Cliente { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(50)]
    public string? Prioridade { get; set; }

    public DateTime? DataEntrada { get; set; }

    public DateTime? DataPrazo { get; set; }

    public int? UpdatedBy { get; set; }
}
