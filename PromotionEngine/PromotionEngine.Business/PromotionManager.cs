using PromotionEngine.Business.Promotions;
using System.Collections.Generic;

namespace PromotionEngine.Business
{
    public class PromotionManager : IPromotionManager
    {
        List<IPromotion> _promotions;

        //Further can be extracted from database later or extra logic can be added
        List<IPromotion> GetPromotions()
        {
            return new List<IPromotion>
            {
                new NItemsPromotion('A',3,50),
                new NItemsPromotion('B',2,45),
                new CombineItemsPromotion(new List<char>{'C','D'},30),
            };
        }

        public PromotionManager()
        {
            _promotions = GetPromotions();
        }

        public int GetPromotionAmount(List<CartItem> items)
        {
            int promotionsAmount = 0;
            foreach (var promotion in _promotions)
            {
                promotionsAmount += promotion.GetAmount(items);
            }
            return promotionsAmount;
        }
    }


}
