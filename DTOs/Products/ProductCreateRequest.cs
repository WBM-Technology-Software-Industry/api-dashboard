using System.ComponentModel.DataAnnotations;

namespace Dashboard.DTOs.Products;

/// <summary>
/// DTO para criação de produto
/// POST /api/products
/// </summary>
public class ProductCreateRequest
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public decimal Price { get; set; }

    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
    public string? Description { get; set; }

    [StringLength(500, ErrorMessage = "A URL da imagem deve ter no máximo 500 caracteres")]
    public string? Image { get; set; }
}
