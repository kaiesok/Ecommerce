using Core.DTOs;
using Core.Entities.Product;
using Core.Interfaces.Product;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                PromotionPrice = p.PromotionPrice,
                PurchasePrice = p.PurchasePrice,
                Margin = p.Margin,
                StockQuantity = p.StockQuantity,
                Brand = p.Brand,
                Category = p.Category
            }).ToList();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _dbContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PromotionPrice = product.PromotionPrice,
                PurchasePrice = product.PurchasePrice,
                Margin = product.Margin,
                StockQuantity = product.StockQuantity,
                Brand = product.Brand,
                Category = product.Category
            };
        }

        public async Task<int> CreateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                PromotionPrice = productDto.PromotionPrice,
                PurchasePrice = productDto.PurchasePrice,
                StockQuantity = productDto.StockQuantity,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.PromotionPrice = productDto.PromotionPrice;
            product.PurchasePrice = productDto.PurchasePrice;
            product.StockQuantity = productDto.StockQuantity;
            product.BrandId = productDto.BrandId;
            product.CategoryId = productDto.CategoryId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
