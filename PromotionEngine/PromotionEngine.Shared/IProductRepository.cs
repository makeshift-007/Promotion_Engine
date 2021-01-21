namespace PromotionEngine.Shared
{
    public interface IProductRepository
    {
        Product GetProduct(string sku);
    }
}
