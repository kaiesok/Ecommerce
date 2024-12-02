using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Product
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllBrandsAsync();
        Task<BrandDto> GetBrandByIdAsync(int id);
        Task<int> CreateBrandAsync(BrandDto brandDto);
        Task UpdateBrandAsync(int id, BrandDto brandDto);
        Task DeleteBrandAsync(int id);
    }
}
