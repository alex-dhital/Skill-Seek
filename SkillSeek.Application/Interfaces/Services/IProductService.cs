using SkillSeek.Application.DTOs.Product;

namespace SkillSeek.Application.Interfaces.Services;

public interface IProductService
{
    List<ProductDto> GetAllProducts();

    ProductDto GetProductById(Guid productId);

    void UpsertProduct(ProductDto product);
}