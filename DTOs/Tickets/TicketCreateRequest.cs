using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Tickets;

public class TicketCreateRequest
{
    [Required]
    [StringLength(255)]
    public required string Titulo { get; set; }

    [StringLength(2000)]
    public string? Descricao { get; set; }

    [StringLength(50)]
    public string? Tipo { get; set; }

    [StringLength(50)]
    public string? Prioridade { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public int? CriadoPor { get; set; }
}
