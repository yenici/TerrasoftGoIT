using System;

namespace ConsoleApplication1.Models
{
    class Product
    {
        private static uint idCounter = 0;
        private uint id;
        private string name;
        private decimal price;
        private uint quantity;
        private decimal discount;
        public uint Id {
            get
            {
                return this.id;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                value = value.Trim();
                if (value.Length == 0 || value.Length > 50)
                    throw new Exception(
                        "The length of a product name should not be empty or greater than 50 symbols");
                this.name = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0 || value >= 1000000M)
                    throw new Exception(
                        string.Format(
                            "The interval of a price's value is (0, 999.999,99]. Error: {0}", value));
                this.price = value;
            }
        }
        public uint Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (value > 9999)
                    throw new Exception(
                        string.Format(
                            "The interval of a quantity's value is [0, 9999]. Error: {0}", value));
                this.quantity = value;
            }
        }
        public decimal Discount {
            get
            {
                return this.discount;
            }
            set
            {
                if (value < 0 || value > 1)
                    throw new Exception(
                        string.Format(
                            "The interval of a quantity's value is [0, 0.9999]. Error: {0}", value));
                this.discount = value;
            }
        }
        public decimal Total
        {
            get
            {
                return this.Price * this.Quantity * (1 - this.Discount);
            }
        }
        public Product() { }
        public Product(string name, decimal price, uint quantity, decimal discount)
        {
            this.id = ++Product.idCounter;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Discount = discount;
        }
        public override string ToString()
        {
            return string.Format(
                "{0, 3}   {1, -50}   {2, 8:N2}   {3, 4}   {4, 6:N2}   {5, 13:N2}",
                this.Id,
                this.Name,
                this.Price,
                this.Quantity,
                this.Discount * 100,
                this.Total
                );
        }
    }
}
