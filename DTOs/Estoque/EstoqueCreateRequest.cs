using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Estoque;

public class EstoqueCreateRequest
{
    [Required]
    [StringLength(255)]
    public required string Nome { get; set; }

    [StringLength(100)]
    public string? Codigo { get; set; }

    [StringLength(100)]
    public string? Categoria { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantidade { get; set; }

    [Range(0, int.MaxValue)]
    public int? QuantidadeMinima { get; set; }

    [StringLength(50)]
    public string? Unidade { get; set; }

    [StringLength(255)]
    public string? Localizacao { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? Preco { get; set; }
}
