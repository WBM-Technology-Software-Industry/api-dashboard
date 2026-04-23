using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Products;

/// <summary>
/// DTO para atualização de produto
/// PUT /api/products/{id}
/// Todos os campos são opcionais
/// </summary>
public class ProductUpdateRequest
{
    [StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres")]
    public string? Name { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public decimal? Price { get; set; }

    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
    public string? Description { get; set; }

    [StringLength(500, ErrorMessage = "A URL da imagem deve ter no máximo 500 caracteres")]
    public string? Image { get; set; }
}
