using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Relatorios;

public class RelatorioCreateRequest
{
    [Required]
    [StringLength(255)]
    public required string Titulo { get; set; }

    [StringLength(100)]
    public string? Setor { get; set; }

    [StringLength(5000)]
    public string? Conteudo { get; set; }

    public DateTime? DataReferencia { get; set; }

    [StringLength(255)]
    public string? AutorNome { get; set; }

    public int? CriadoPor { get; set; }
}
