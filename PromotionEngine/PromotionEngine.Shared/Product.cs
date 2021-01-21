namespace PromotionEngine.Shared
{
    public class Product
    {
        public Product(string sku, int price)
        {
            SKU = sku;
            Price = price;
        }
        public string SKU { get; }
        public int Price { get; }
    }
}
