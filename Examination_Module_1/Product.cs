using System;

namespace Examination_Module_1
{
    public class Product
    {
        public String Name { get; private set; }
        public Decimal Price { get; private set; }
        public Product(String name, Decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
