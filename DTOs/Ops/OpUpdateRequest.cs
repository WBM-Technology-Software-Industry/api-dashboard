using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Ops;

/// <summary>
/// DTO para atualização de OP
/// PUT /api/ops/{id}
/// </summary>
public class OpUpdateRequest
{
    [StringLength(100)]
    public string? Numero { get; set; }

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
