using Moq;
using PromotionEngine.Business.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PromotionEngine.Business.Tests

{
    [Trait("Category", "Business")]
    public class PromotionManagerTests
    {
        private PromotionManager GenerateSUT()
        {
            return new PromotionManager();
        }

        [Fact(DisplayName = "GetPromotionAmount: Should return amount after applying promotions")]
        public void GetPromotionAmount_WhenItemsArePassed_ShouldApplyAllPromotionAndReturnAmount()
        {
            //Arrange            
            var sut = GenerateSUT();
            var orders = new MockOrders();
            var expectedResult = 220;

            //Act
            var amount = sut.GetPromotionAmount(orders.Order2());

            //Assert                       
            Assert.Equal(expectedResult, amount);
        }

    }
}
