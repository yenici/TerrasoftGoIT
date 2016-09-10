using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1.Models
{
    class Store : IEnumerable<Product>
    {
        private List<Product> products;

        private Store()
        {
            this.products = new List<Product>();
        }
        public static Store createStore()
        {
            Store store = new Store();
            store.generateProducts();
            return store;
        }
        public IEnumerator<Product> GetEnumerator()
        {
            foreach (Product product in products)
                yield return product;
        }
        private void generateProducts()
        {
            this.products.Add(new Product("New iPhone 7 Plus 32GB",  769.00M,   0, 0.0M));
            this.products.Add(new Product("New iPhone 7 Plus 128GB", 869.00M,   0, 0.0M));
            this.products.Add(new Product("New iPhone 7 Plus 256GB", 969.00M,   2, 0.05M));
            this.products.Add(new Product("New iPhone 7 32GB",       649.00M,   0, 0.0M));
            this.products.Add(new Product("New iPhone 7 128GB",      749.00M,   0, 0.0M));
            this.products.Add(new Product("New iPhone 7 256GB",      849.00M,   3, 0.05M));
            this.products.Add(new Product("iPhone 6S Plus 32GB",     649.00M,  92, 0.0M));
            this.products.Add(new Product("iPhone 6S Plus 128GB",    749.00M,  40, 0.0M));
            this.products.Add(new Product("iPhone 6S 32GB",          549.00M, 321, 0.0M));
            this.products.Add(new Product("iPhone 6S 128GB",         649.00M, 123, 0.0M));
            this.products.Add(new Product("iPhone 6SE 16GB",         399.00M, 100, 0.0M));
            this.products.Add(new Product("iPhone 6SE 64GB",         449.00M,  10, 0.1M));
            this.products.Add(new Product("New 13-inch MacBook Air 1.6GHz 128 GB Storage",  999.00M, 10, 0.1M));
            this.products.Add(new Product("New 13-inch MacBook Air 1.6GHz 256 GB Storage", 1999.00M, 10, 0.1M));
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
