using PromotionEngine.Business;
using PromotionEngine.Data;
using System;

namespace PromotionEngine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart(new DummyProductRepository(),
                new CheckOutManager(new PromotionManager()));

            cart.AddItem('A', 3);
            cart.AddItem('B', 5);
            cart.AddItem('C', 1);
            cart.AddItem('D', 1);

            System.Console.WriteLine("Final Amount:" + cart.GetCheckoutAmount());


             cart = new Cart(new DummyProductRepository(),
           new CheckOutManager(new PromotionManager()));

            cart.AddItem('A', 1);
            cart.AddItem('B', 1);
            cart.AddItem('C', 1);
            

            System.Console.WriteLine("Final Amount:" + cart.GetCheckoutAmount());



             cart = new Cart(new DummyProductRepository(),
           new CheckOutManager(new PromotionManager()));

            cart.AddItem('A', 5);
            cart.AddItem('B', 5);
            cart.AddItem('C', 1);            

            System.Console.WriteLine("Final Amount:" + cart.GetCheckoutAmount());


            System.Console.ReadLine();
        }
    }
}
