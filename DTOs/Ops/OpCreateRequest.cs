using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Ops;

/// <summary>
/// DTO para criação de OP (Ordem de Produção)
/// POST /api/ops
/// </summary>
public class OpCreateRequest
{
    [Required(ErrorMessage = "O número é obrigatório")]
    [StringLength(100)]
    public required string Numero { get; set; }

    [StringLength(255)]
    public string? Item { get; set; }

    [StringLength(255)]
    public string? Responsavel { get; set; }

    [StringLength(100)]
    public string? Setor { get; set; }

    [StringLength(50)]
    public string? Prioridade { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public DateTime? Abertura { get; set; }

    public DateTime? PrevEntrega { get; set; }
}
