using Mango.Web.Models;
using System.Reflection;

namespace Manago.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetProductAsync<T>();

        Task<T> GetProductById<T>(int id);

        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);

    }
}
