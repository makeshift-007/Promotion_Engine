using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Business.Tests.Mocks
{
    public class CartItems
    {
        List<CartItem> _items;

        public CartItems()
        {
            var products = new Products().GetAll();
            _items = new List<CartItem>();
            int qty = 1;
            products.ForEach(m =>
            {
                _items.Add(new CartItem(m, qty++));
            });
        }
        public List<CartItem> GetAll()
        {
            return _items;
        }

        public CartItem GetCartItem(string sku)
        {
            return _items.FirstOrDefault(m => m.SKU == sku);
        }
    }
}
