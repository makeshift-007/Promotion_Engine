using PromotionEngine.Business.Tests.Mocks;
using PromotionEngine.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PromotionEngine.Business.Tests
{
    [Trait("Category", "Business")]
    public class CartItemTests
    {
        private CartItem GenerateSUT(Product product, int quantity)
        {
            return new CartItem(product, quantity);
        }

        [Fact(DisplayName = "CTOR: Should Initialize Properties(Product and Quantity)")]
        public void CTOR_WhenProductAndQuantityPassed_ShouldInitilizeProperties()
        {
            //Arrange           
            var productsMockedData = new Products();
            var productSku = 'A';
            var product = productsMockedData.GetProduct(productSku);
            var quantity = 10;
            //Act
            var sut = GenerateSUT(product, quantity);

            //Assert
            Assert.Equal(product, sut.Product);
            Assert.Equal(quantity, sut.Quantity);
        }


        [Fact(DisplayName = "GetAmount: Should Calculate Total Cart Item Amount")]
        public void GetAmount_IsCaled_ShouldCalculateAndReturnCartItemAmountValue()
        {
            //Arrange           
            var productsMockedData = new Products();
            var productSku = 'A';
            var product = productsMockedData.GetProduct(productSku);
            var quantity = 10;
            var sut = GenerateSUT(product, quantity);
            //Act
            var amount = sut.GetAmount();
            //Assert
            Assert.Equal(product.Price * quantity, amount);
        }


        [Fact(DisplayName = "CTOR: When Null Product is passed throw Exception")]
        public void GetAmount_WhenNullProductPassed_ThrowException()
        {
            //Arrange           
            var quantity = 10;

            //Act
            var exception = Assert.Throws<System.ArgumentException>(() => GenerateSUT(null, quantity));
            //Assert
            Assert.Equal("Invaid Product!!", exception.Message);
        }


    }
}
