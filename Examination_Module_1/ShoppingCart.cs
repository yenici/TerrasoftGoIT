using System;
using System.Collections.Generic;

namespace Examination_Module_1
{
    class ShoppingCart
    {
        private Dictionary<Product, Decimal> cardItems = new Dictionary<Product, Decimal>();
        public Decimal Discount {get; set;}
        public void print()
        {
            Console.WriteLine("\n" + new String('-', 21) + " Check: " + new String('-', 21));
            foreach (KeyValuePair<Product, Decimal> item in cardItems)
            {
                Console.WriteLine(" {0,-10}\t$ {1,10:N2} x {2,7:N3} = $ {3:N2}",
                    item.Key.Name,
                    item.Key.Price,
                    item.Value,
                    item.Key.Price * item.Value);
            }
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Total:               $ {0:N2}", getTotal());
            Console.WriteLine("Discount:            $ {0:N2}", getDiscount());
            Console.WriteLine("Total with discount: $ {0:N2}", getTotal() - getDiscount());
        }
        public Decimal addItem(Product product, Decimal quantity)
        {
            if (cardItems.ContainsKey(product))
            {
                if (cardItems[product] + quantity > 0)
                {
                    cardItems[product] += quantity;
                }
                else
                {
                    throw new Exception(product.Name +" quantity should be greater than zero.");
                }
                
            }
            else
            {
                if (quantity > 0)
                {
                    cardItems.Add(product, quantity);
                }
                else
                {
                    throw new Exception(product.Name + " quantity should be greater than zero.");
                }
            }
            return cardItems[product];
        }
        public void removeItem(Product product)
        {
            cardItems.Remove(product);
        }
        public int getItemsCount()
        {
            return cardItems.Count;
        }
        public Decimal getTotal()
        {
            Decimal _dTotal = 0M;
            foreach (KeyValuePair<Product, Decimal> item in cardItems)
            {
                _dTotal += Math.Round(item.Key.Price * item.Value, 2);
            }
            return _dTotal;
        }
        public Decimal getDiscount()
        {
            return Math.Round(getTotal() * Discount / 100, 2);
        }
    }
}
