using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Clientes;

/// <summary>
/// DTO para atualização de cliente
/// PUT /api/clientes/{id}
/// Todos os campos são opcionais
/// </summary>
public class ClienteUpdateRequest
{
    [StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres")]
    public string? Nome { get; set; }

    [StringLength(50, ErrorMessage = "O documento deve ter no máximo 50 caracteres")]
    public string? Documento { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido")]
    [StringLength(255, ErrorMessage = "O email deve ter no máximo 255 caracteres")]
    public string? Email { get; set; }

    [StringLength(50, ErrorMessage = "O telefone deve ter no máximo 50 caracteres")]
    public string? Telefone { get; set; }

    [StringLength(500, ErrorMessage = "O endereço deve ter no máximo 500 caracteres")]
    public string? Endereco { get; set; }
}
