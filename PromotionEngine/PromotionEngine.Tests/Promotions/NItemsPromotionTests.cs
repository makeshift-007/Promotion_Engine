using PromotionEngine.Business.Promotions;
using PromotionEngine.Business.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PromotionEngine.Business.Tests.Promotions
{
   public class NItemsPromotionTests
    {
        private NItemsPromotion GenerateSUT(char skus,int promoQty, int promotionAmount)
        {
            return new NItemsPromotion(skus, promoQty, promotionAmount);
        }

        [Fact(DisplayName = "GetAmount: Should Calculate Total Promotion Amount")]
        public void GetAmount_IsCaled_ShouldCalculateAndReturnPromotionAmountValue()
        {
            //Arrange             
            var bundleAmount = 130;
            var sut = GenerateSUT('A',3, bundleAmount);
            var orders = new MockOrders();
            //Act
            var amount = sut.GetAmount(orders.Order3());
            //Assert
            Assert.Equal(bundleAmount, amount);
        }
    }
}
