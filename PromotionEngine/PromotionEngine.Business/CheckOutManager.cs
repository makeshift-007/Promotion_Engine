using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business
{
    /// <summary>
    /// Can be used for applying promotions and taxes
    /// </summary>
    public class CheckOutManager: ICheckOutManager
    {
        private readonly IPromotionManager promotionManager;

        public CheckOutManager(IPromotionManager promotionManager)
        {
            this.promotionManager = promotionManager;
        }

        public int GetAmount(List<CartItem> items)
        {
            items = items.Select(m => new CartItem(m.Product, m.Quantity)).ToList();
            int totalAmount = promotionManager.GetPromotionAmount(items);
            totalAmount += items.Sum(m => m.GetAmount());
            return totalAmount;
        }
    }
}
