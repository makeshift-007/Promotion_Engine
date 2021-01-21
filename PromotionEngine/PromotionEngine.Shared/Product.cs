namespace PromotionEngine.Shared
{
    public class Product
    {
        public Product(char sku, int price)
        {
            SKU = sku;
            Price = price;
        }
        public char SKU { get; }
        public int Price { get; }
    }
}
