using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Mensagens;

public class MensagemSemanaCreateRequest
{
    [StringLength(2000)]
    public string? Conteudo { get; set; }

    [StringLength(255)]
    public string? Responsavel { get; set; }

    public DateTime? SemanaInicio { get; set; }
}
