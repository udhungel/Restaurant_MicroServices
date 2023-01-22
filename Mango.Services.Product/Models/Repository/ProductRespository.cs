using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Models.Repository
{
    public class ProductRespository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRespository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
         MangoProduct product =  _mapper.Map<MangoProduct>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);

            }
            else 
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                MangoProduct product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId); 
                if (product == null) { return false; }
                _db.Products.Remove(product);   
                await _db.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            MangoProduct product = await _db.Products.Where(x=>x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<MangoProduct> productsList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productsList);

        }
    }
}
