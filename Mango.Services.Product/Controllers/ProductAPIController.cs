using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")] //global route
    public class ProductAPIController : ControllerBase
    {
        private IProductRepository _productRepository;
        protected ResponseDto _response;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new();
        }


        [HttpGet]
         
        public async Task<object> Get()
        {
            try
            {
               IEnumerable<ProductDto> productDto = await _productRepository.GetProducts();
                _response.Result= productDto;


            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
                
            }
            return _response;
        }
    }
}
