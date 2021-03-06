﻿using PromotionEngine.Shared;

namespace PromotionEngine.Business
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            if (product == null)
                throw new System.ArgumentNullException("Product","Invalid Product!!");

            Product = product;
            Quantity = quantity;
        }
        public string SKU
        {
            get
            {
                return Product.SKU;
            }
        }

        public int Quantity { get; set; }
        public Product Product { get; }
        public virtual int GetAmount()
        {
            return Product.Price * Quantity;
        }

    }
}
