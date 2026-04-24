using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Pedidos;

/// <summary>
/// DTO para criação de pedido
/// POST /api/pedidos
/// </summary>
public class PedidoCreateRequest
{
    [Required(ErrorMessage = "O número é obrigatório")]
    [StringLength(100, ErrorMessage = "O número deve ter no máximo 100 caracteres")]
    public required string Numero { get; set; }

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

    public int? CreatedBy { get; set; }

    // Lista de items do pedido
    public List<PedidoItemRequest>? Items { get; set; }
}

/// <summary>
/// DTO para item de pedido
/// </summary>
public class PedidoItemRequest
{
    [Required(ErrorMessage = "O item é obrigatório")]
    public required string Item { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
    public int Quantidade { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor unitário deve ser maior que zero")]
    public decimal ValorUnitario { get; set; }

    public string? Observacao { get; set; }
}
