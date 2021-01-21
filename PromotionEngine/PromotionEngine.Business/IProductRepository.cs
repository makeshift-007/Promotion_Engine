namespace PromotionEngine.Business
{
    public interface IProductRepository
    {
        Product GetProduct(char sku);
    }
}
