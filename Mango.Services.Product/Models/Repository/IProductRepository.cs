namespace Mango.Services.ProductAPI.Models.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId); 

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<ProductDto> DeleteProduct(int productId);

    }
}
