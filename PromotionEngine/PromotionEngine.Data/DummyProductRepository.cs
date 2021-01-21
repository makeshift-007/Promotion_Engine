using PromotionEngine.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Data
{
    public class DummyProductRepository : IProductRepository
    {
        List<Product> _products;

        public DummyProductRepository()
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
