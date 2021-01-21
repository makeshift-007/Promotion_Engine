using Moq;
using PromotionEngine.Business.Tests.Mocks;
using PromotionEngine.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Business.Tests
{
    [Trait("Category", "Business")]
    public class CartTest
    {
        private Cart GenerateSUT(Mock<IProductRepository> productRepoMock = null, Mock<ICheckOutManager> checkoutManager = null)
        {
            if (productRepoMock == null)
                productRepoMock = new Mock<IProductRepository>();
            if (checkoutManager == null)
                checkoutManager = new Mock<ICheckOutManager>();

            return new Cart(productRepoMock.Object, checkoutManager.Object);
        }

        [Fact(DisplayName = "AddItem: Should Add Item in cart")]
        public void AddItem_WhenItemSkuPassed_ShouldAddItemInCart()
        {
            //Arrange
            var productRepoMock = new Mock<IProductRepository>();
            var productsMockedData = new Products();
            var productSku = 'A';
            productRepoMock.Setup(m => m.GetProduct(productSku)).Returns(productsMockedData.GetProduct(productSku));
            var sut = GenerateSUT(productRepoMock);

            //Act
            sut.AddItem(productSku);

            //Assert
            var foundItem = sut.Items.FirstOrDefault(m => m.SKU == productSku);
            productRepoMock.Verify(m => m.GetProduct(productSku));
            Assert.NotNull(foundItem);
            Assert.Equal(productSku, foundItem.SKU);
        }


        [Fact(DisplayName = "AddItem: Should Add Item in cart with default value when no quantity is passed")]
        public void AddItem_WhenNoQuantityIsPassed_ShouldAddItemWithDefaultQuantity()
        {
            //Arrange
            var productRepoMock = new Mock<IProductRepository>();
            var productsMockedData = new Products();
            var productSku = 'A';
            productRepoMock.Setup(m => m.GetProduct(productSku)).Returns(productsMockedData.GetProduct(productSku));
            var sut = GenerateSUT(productRepoMock);

            //Act
            sut.AddItem(productSku);

            //Assert
            var foundItem = sut.Items.FirstOrDefault(m => m.SKU == productSku);
            productRepoMock.Verify(m => m.GetProduct(productSku), Times.Once);
            Assert.NotNull(foundItem);
            Assert.Equal(productSku, foundItem.SKU);
            Assert.Equal(1, foundItem.Quantity);

        }

        [Fact(DisplayName = "RemoveItem: Should Remove Item from cart")]
        public void RemoveItem_WhenItemSkuPassed_ShouldRemoveItemFromCart()
        {
            //Arrange
            var productRepoMock = new Mock<IProductRepository>();
            var checkoutManagerMock = new Mock<ICheckOutManager>();
            var productsMockedData = new Products();
            var productSku = 'A';
            productRepoMock.Setup(m => m.GetProduct(productSku)).Returns(productsMockedData.GetProduct(productSku));
            var sut = GenerateSUT(productRepoMock);
            sut.AddItem(productSku);

            //Act
            sut.RemoveItem(productSku);

            //Assert
            var foundItem = sut.Items.FirstOrDefault(m => m.SKU == productSku);
            Assert.Null(foundItem);
        }


        [Fact(DisplayName = "GetCheckoutAmount: Should return Total Cart Amount")]
        public void GetCheckoutAmount_IsCalled_ShouldReturnTotalCartAmount()
        {
            //Arrange        
            var productRepoMock = new Mock<IProductRepository>();
            var checkoutManagerMock = new Mock<ICheckOutManager>();
            var productsMockedData = new Products();
            var productSku = 'A';
            productRepoMock.Setup(m => m.GetProduct(productSku)).Returns(productsMockedData.GetProduct(productSku));
            checkoutManagerMock.Setup(m => m.GetAmount(It.IsAny<List<CartItem>>())).Returns(100);            
            var sut = GenerateSUT(productRepoMock, checkoutManagerMock);
            //Act
            var amount = sut.GetCheckoutAmount();
            //Assert
            Assert.Equal(100, amount);
            checkoutManagerMock.Verify(m => m.GetAmount(It.IsAny<List<CartItem>>()), Times.Once);
        }
    }
}
