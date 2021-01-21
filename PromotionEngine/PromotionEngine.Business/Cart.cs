using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Business
{
    public class Cart
    {
        List<CartItem> _items;
        private readonly IProductRepository _productRepo;

        public List<CartItem> Items { get { return _items; } }

        public Cart(IProductRepository productRepo)
        {
            _items = new List<CartItem>();
            _productRepo = productRepo;
        }

        public void AddItem(char sku, int quantity = 1)
        {
            var item = _items.FirstOrDefault(m => m.SKU == sku);
            if (item == null)
            {
                _items.Add(new CartItem(_productRepo.GetProduct(sku), quantity));
            }
            else
                item.Quantity += quantity;

        }

        public void RemoveItem(char sku, int quantity = 1)
        {
            var item = _items.FirstOrDefault(m => m.SKU == sku);
            if (item != null)
            {
                if (item.Quantity <= quantity)
                    _items.Remove(item);
                else
                    item.Quantity = item.Quantity - quantity;
            }

        }

        public int GetCheckoutAmount()
        {
            return _items.Sum(m => m.GetAmount());
        }
    }
}
