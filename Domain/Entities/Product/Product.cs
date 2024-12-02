namespace Core.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Margin => Price - PurchasePrice;
        public int StockQuantity { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
