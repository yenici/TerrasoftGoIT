using System;
using System.Collections.Generic;

namespace Examination_Module_1
{
    public static class ProductList
    {
        private static List<Product> products = new List<Product>();
        public static void Print()
        {
            Console.WriteLine(new String('-', 10) + " Products " + new String('-', 10) + "\n");
            for (int i = 0; i < ProductList.products.Count; i++)
            {
                Console.WriteLine("{0,2}. {1,-10} : $ {2:N2}",
                    i + 1,
                    ProductList.products[i].Name,
                    ProductList.products[i].Price);
            }
        }
        public static Product GetProductByIndex(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                return products[index];
            }
            else
            {
                return null;
            }
        }
        public static int GetProductsCount()
        {
            return products.Count;
        }
        public static void CreateFooList()
        {
            ProductList.products.Clear();
            products.Add(new Product("Apple", 1.00M));
            products.Add(new Product("Milk", 1.50M));
            products.Add(new Product("Cola", 0.75M));
            products.Add(new Product("Bread", 2.55M));
            products.Add(new Product("Chocolate", 3.00M));
        }
    }
}
