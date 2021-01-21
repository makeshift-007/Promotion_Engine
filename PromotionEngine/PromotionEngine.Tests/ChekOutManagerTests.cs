using Moq;
using PromotionEngine.Business.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PromotionEngine.Business.Tests
{
    [Trait("Category", "Business")]
    public class ChekOutManagerTests
    {
        private CheckOutManager GenerateSUT(Mock<IPromotionManager> promotionManager = null)
        {
            if (promotionManager == null)
                promotionManager = new Mock<IPromotionManager>();

            return new CheckOutManager(promotionManager.Object);
        }

        [Fact(DisplayName = "GetAmount: Should apply all managers which would affect amount")]
        public void GetAmount_WhenItemsArePassed_ShouldApplyAllRateManagers()
        {
            //Arrange
            var promotionManager = new Mock<IPromotionManager>();
            var cartItemsMockedData = new CartItems();
            var items = cartItemsMockedData.GetAll();
            List<List<CartItem>> capturedItems = new List<List<CartItem>>();

            promotionManager.Setup(m => m.GetPromotionAmount(Capture.In(capturedItems))).Returns(100);
            var sut = GenerateSUT(promotionManager);

            //Act
            var amount = sut.GetAmount(items);

            //Assert            
            Assert.Single(capturedItems);            
            var expectedAmount = 100 + capturedItems[0].Sum(m => m.GetAmount());
            Assert.Equal(expectedAmount, amount);
        }
    }
}
