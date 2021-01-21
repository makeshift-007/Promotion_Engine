using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Business.Promotions
{
    public class CombineItemsPromotion : IPromotion
    {
        private readonly List<char> promotionSkus;
        private readonly int promotionAmount;

        public CombineItemsPromotion(List<char> skus, int promotionAmount)
        {
            this.promotionSkus = skus;
            this.promotionAmount = promotionAmount;
        }


        public int GetAmount(List<CartItem> items)
        {
            foreach (var sku in promotionSkus)
            {
                if (items.All(m => m.SKU != sku && m.Quantity > 0))
                    return 0;
            }

            var totalBundle = int.MaxValue;
            int promotionAmount = 0;

            foreach (var sku in promotionSkus)
            {
                var item = items.FirstOrDefault(m => m.SKU == sku);
                totalBundle = totalBundle < item.Quantity ? totalBundle : item.Quantity;
            }

            promotionAmount = totalBundle * this.promotionAmount;


            foreach (var sku in promotionSkus)
            {
                var item = items.FirstOrDefault(m => m.SKU == sku);
                item.Quantity = item.Quantity - totalBundle;
            }

            return promotionAmount;
        }
    }
}
