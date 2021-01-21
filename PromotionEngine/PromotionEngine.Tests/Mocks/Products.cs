using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Tests.Mocks
{
    public class Products
    {
        List<Product> _products;

        public Products()
        {
            _products = new List<Product>
            {
                new Product('A',50),
                new Product('B',30),
                new Product('C',20),
                new Product('D',15)
            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetProduct(char sku)
        {
            return _products.FirstOrDefault(m => m.SKU == sku);
        }
    }
}
