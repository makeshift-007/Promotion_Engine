using PromotionEngine.Business.Promotions;
using PromotionEngine.Business.Tests.Mocks;
using PromotionEngine.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PromotionEngine.Business.Tests.Promotions
{
    [Trait("Category", "Business")]
    public class CombinedItemsPromotionsTest
    {
        private CombineItemsPromotion GenerateSUT(List<string> skus, int promotionAmount)
        {
            return new CombineItemsPromotion(skus, promotionAmount);
        }

        [Fact(DisplayName = "GetAmount: Should Calculate Total Promotion Amount")]
        public void GetAmount_IsCaled_ShouldCalculateAndReturnPromotionAmountValue()
        {
            //Arrange
            var bundleAmount = 30;
            var sut = GenerateSUT(new List<string> { "C","D"}, bundleAmount);
            var orders = new MockOrders();
            //Act
            var amount = sut.GetAmount(orders.Order3());
            //Assert
            Assert.Equal(bundleAmount, amount);
        }

    }
}
