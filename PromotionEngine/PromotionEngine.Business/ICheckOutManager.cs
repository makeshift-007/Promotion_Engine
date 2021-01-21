using System.Collections.Generic;

namespace PromotionEngine.Business
{
    public interface ICheckOutManager
    {
        int GetAmount(List<CartItem> items);
    }
}
