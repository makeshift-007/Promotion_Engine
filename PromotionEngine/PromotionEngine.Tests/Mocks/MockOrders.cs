using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Business.Tests.Mocks
{
    public class MockOrders
    {
        Products _products = new Products();
        public List<CartItem> Order1()
        {
            return new List<CartItem>()
            {
                new CartItem(_products.GetProduct("A"),1),
                new CartItem(_products.GetProduct("B"),1),
                new CartItem(_products.GetProduct("C"),1),
            };
        }
        public List<CartItem> Order2()
        {
            return new List<CartItem>()
            {
                new CartItem(_products.GetProduct("A"),5),
                new CartItem(_products.GetProduct("B"),5),
                new CartItem(_products.GetProduct("C"),1),
            };
        }
        public List<CartItem> Order3()
        {
            return new List<CartItem>()
            {
                new CartItem(_products.GetProduct("A"),3),
                new CartItem(_products.GetProduct("B"),5),
                new CartItem(_products.GetProduct("C"),1),
                new CartItem(_products.GetProduct("D"),1)
            };
        }
    }
}
