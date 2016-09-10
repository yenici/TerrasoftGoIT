using ConsoleApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = Store.createStore();
            Console.WriteLine("P R O D U C T' S   L I S T");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            foreach (Product product in store)
                Console.WriteLine(product);
            //Program.GetNewDiscountPropducts(store);
            //Program.FindByKeywords(store, new string[] { "64", "256", "SE" });
            //"The show must go on".Any(key => { Console.WriteLine(key); return false; });
        }

        /**
         * 
         * Нужно получить список товаров, которые
         *    имеют скидку,
         *    при этом цена не превышает 1000,
         *    и кол-во проданных товаров более 2,
         *    при этом в названии товара присутствует «новый».
         * Этот список получаем полностью через Linq.
         * Упаковываем это дело в анонимный класс, с полями: Id, Сумма
         * 
         */
        public static void GetNewDiscountPropducts(Store store)
        {
            var result = from product in store
                         where product.Discount > 0 &&
                             product.Price <= 1000M &&
                             product.Quantity > 2 &&
                             product.Name.ToUpper().Contains("NEW")
                         orderby product.Total descending
                         select new
                         {
                             Id = product.Id,
                             Summ = product.Total
                         };
            Console.WriteLine("Q U E R Y   R E S U L T");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            foreach (var r in result)
                Console.WriteLine(r);
        }

        /**
         * 
         * Реализовать метод пагинации результатов. Т.е.мы можем из базы получить список товаров,
         * разбитый по страницам.
         * Пользователь может указать какую страницу ему выбрать, при этом ему предлагается только
         * из существующих страниц (т.е.больше 0, меньше максимального числа страниц).
         * Результатов на страницу – 2.
         * 
         */
        public static void Paginator(Store store)
        {
            
        }

        /**
         * 
         * Реализовать метод, который будет дергать данные из базы по списку ключевых слов.
         * Пользователь указывает несколько слов и в результате получать список товаров,
         * которые содержат в названии эти слова(любое из слов).
         * Реализовать через Linq.
         * 
         */
        public static void FindByKeywords(Store store, string[] keywords)
        {
//Enter the keys separated by a space 
            //var result = from product in store
            //             where (from key in keywords
            //                    where product.Name.ToUpper().Contains(key.ToUpper())
            //                    select key).Count() > 0
            //             orderby product.Price descending
            //             select product;
            var result = from product in store
                         where keywords.Any(key => product.Name.ToUpper().Contains(key.ToUpper()))
                         orderby product.Price descending
                         select product;
            Console.WriteLine("Q U E R Y   B Y   K E Y W O R D S");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            Console.Write("Keywords:");
            foreach (string key in keywords)
                Console.Write(" " + key);
            Console.WriteLine("\n" + new string('-', Console.WindowWidth - 1));
            foreach (var product in result)
                Console.WriteLine(product);
        }
    }
}
