using Core.Entities.Product;

namespace Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Margin { get; set; }
        public int StockQuantity { get; set; }

        public int BrandId { get; set; }  

        public int CategoryId { get; set; } 
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}




