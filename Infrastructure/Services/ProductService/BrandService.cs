using Core.DTOs;
using Core.Entities.Product;
using Core.Interfaces.Product;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ProductService
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _dbContext;

        public BrandService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _dbContext.Brands.ToListAsync();
            return brands.Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description
            }).ToList();
        }

        public async Task<BrandDto> GetBrandByIdAsync(int id)
        {
            var brand = await _dbContext.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null)
                throw new KeyNotFoundException("Brand not found.");

            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description
            };
        }

        public async Task<int> CreateBrandAsync(BrandDto brandDto)
        {
            var brand = new Brand
            {
                Name = brandDto.Name,
                Description = brandDto.Description
            };

            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();

            return brand.Id;
        }

        public async Task UpdateBrandAsync(int id, BrandDto brandDto)
        {
            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
                throw new KeyNotFoundException("Brand not found.");

            brand.Name = brandDto.Name;
            brand.Description = brandDto.Description;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(int id)
        {
            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
                throw new KeyNotFoundException("Brand not found.");

            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
