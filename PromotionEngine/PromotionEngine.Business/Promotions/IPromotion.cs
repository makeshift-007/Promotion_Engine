using System.Collections.Generic;

namespace PromotionEngine.Business.Promotions
{
    interface IPromotion
    {
        int GetAmount(List<CartItem> items);
    }
}
