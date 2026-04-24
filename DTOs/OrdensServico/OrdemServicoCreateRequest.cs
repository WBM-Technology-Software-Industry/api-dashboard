using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.OrdensServico;

public class OrdemServicoCreateRequest
{
    [Required]
    [StringLength(100)]
    public required string Numero { get; set; }

    [StringLength(50)]
    public string? Tipo { get; set; }

    [StringLength(100)]
    public string? OpRef { get; set; }

    [StringLength(1000)]
    public string? Descricao { get; set; }

    [StringLength(255)]
    public string? Cliente { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(50)]
    public string? Prioridade { get; set; }

    [StringLength(255)]
    public string? Responsible { get; set; }

    [StringLength(100)]
    public string? Sector { get; set; }

    public DateTime? DataAbertura { get; set; }

    public DateTime? DataPrevista { get; set; }

    public int? CreatedBy { get; set; }
}
