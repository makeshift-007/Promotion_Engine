namespace PromotionEngine.Shared
{
    public interface IProductRepository
    {
        Product GetProduct(char sku);
    }
}
