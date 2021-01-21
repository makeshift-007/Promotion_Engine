using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Promotions
{

    public class NItemsPromotion : IPromotion
    {
        private readonly char sku;
        private readonly int promotionQty;
        private readonly int promotionAmount;

        public NItemsPromotion(char sku, int promotionQty, int promotionAmount)
        {
            this.sku = sku;
            this.promotionQty = promotionQty;
            this.promotionAmount = promotionAmount;
        }


        public int GetAmount(List<CartItem> items)
        {
            var item = items.FirstOrDefault(m => m.SKU == sku);
            int amount = 0;
            if (item != null && (item.Quantity / promotionQty) > 0)
            {
                var totalBundle = item.Quantity / promotionQty;
                amount = totalBundle * promotionAmount;
                item.Quantity = item.Quantity - (totalBundle * promotionQty);
            }
            return amount;
        }
    }
}
