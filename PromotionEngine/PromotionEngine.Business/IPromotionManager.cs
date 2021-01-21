using System.Collections.Generic;

namespace PromotionEngine.Business
{
    public interface IPromotionManager
    {
        int GetPromotionAmount(List<CartItem> items);
    }
}
