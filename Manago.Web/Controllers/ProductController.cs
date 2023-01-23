using Manago.Web.Services.IServices;
using Mango.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Manago.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            var response = await productService.GetProductAsync<ResponseDto>();
            if (response != null && response.IsSucess) 
            {
                list =JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        
        public async Task<IActionResult> ProductCreate()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            
            var response = await productService.CreateProductAsync<ResponseDto>(model);
            if (response != null && response.IsSucess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductEdit(int productId)
        {
           var response = await productService.GetProductById<ResponseDto>(productId);
            if (response != null && response.IsSucess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {

            var response = await productService.UpdateProductAsync<ResponseDto>(model);
            if (response != null && response.IsSucess)
            {

                return RedirectToAction(nameof(ProductIndex));
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await productService.GetProductById<ResponseDto>(productId);
            if (response != null && response.IsSucess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.DeleteProductAsync<ResponseDto>(model.ProductId);
                if (response != null && response.IsSucess)
                {

                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
    }
}
