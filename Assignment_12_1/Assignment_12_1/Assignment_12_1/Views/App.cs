using Assignment_12_1.Models;
using Assignment_12_1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12_1.Views
{
    class App
    {
        public static void StartApp()
        {
            Store store = Store.CreateStore();
            int option = 0;
            while (option != 4)
            {
                option = AppMenu.ProcessMenu("M A I N   M E N U", new string[]
                    {"Display all products", "Filter products by keywords", "Complex query", "Quit"});
                switch(option)
                {
                    case 1:
                        App.DisplayAllProducts(store);
                        break;
                    case 2:
                        App.FilterProductsByKeywords(store);
                        break;
                    case 3:
                        App.GetNewDiscountPropducts(store);
                        break;
                    case 4:
                        break;
                }
            }
        }
        private static void DisplayAllProducts(Store store)
        {
            Console.Clear();
            Console.WriteLine("\tD I S P L A Y   ALL   P R O D U C T S:");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            App.DisplayResults(store, 10);
        }
        private static void FilterProductsByKeywords(Store store)
        {
            Console.Clear();
            Console.WriteLine("\tF I L T E R   P R O D U C T S   B Y   K E Y W O R D S:");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            string keys;
            Console.Write("Enter the keys separated by a space: ");
            keys = Console.ReadLine();
            string[] keywords = keys.Split(' ');
            Console.WriteLine("\n" + new string('-', Console.WindowWidth - 1));
            App.DisplayResults(store.FindByKeywords(keywords), 2);
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
            Console.Clear();
            Console.WriteLine("\tC O M P L E X   Q U E R Y:");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            var result = from product in store
                         where product.Discount > 0 &&
                             product.Price <= 1000M &&
                             product.Quantity > 2 &&
                             product.Name.ToUpper().Contains("NEW")
                         orderby product.Total descending
                         select new
                         {
                             Id = product.Id,
                             Sum = product.Total
                         };
            foreach (var r in result)
                Console.WriteLine("Id: {0}\tTotal: {1}", r.Id, r.Sum);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private static void DisplayResults(IEnumerable<Product> result, int itemsOnPage)
        {
            Paginator<Product> paginator = new Paginator<Product>(result, itemsOnPage);
            if (paginator.PageCount > 0)
            {
                int currentPage = 0;
                int selectedPage = 1;
                string input;
                bool quit = false;
                Console.WriteLine(" Id              Name                                      Price     Quant.  Disc,%     Total");
                Console.WriteLine(new string('-', Console.WindowWidth - 1));
                int currentLineCursor = Console.CursorTop;
                int inputLineCursor = 0;
                while (!quit)
                {
                    if (currentPage != selectedPage)
                    {
                        currentPage = selectedPage;
                        Console.SetCursorPosition(0, currentLineCursor);
                        App.PrintResults(paginator.GetPage(currentPage), itemsOnPage);
                        Console.WriteLine("\nPage {0} of {1}", currentPage, paginator.PageCount);
                        inputLineCursor = Console.CursorTop;
                    }
                    Console.SetCursorPosition(0, inputLineCursor);
                    Console.WriteLine(new string(' ', Console.WindowWidth - 1));  // Clean the input area
                    Console.SetCursorPosition(0, inputLineCursor);
                    Console.Write("Enter the page number or 'q' to quit: ");
                    input = Console.ReadLine();
                    if (!input.Equals("q"))
                    {
                        if (!int.TryParse(input, out selectedPage)
                            || selectedPage < 0
                            || selectedPage > paginator.PageCount)
                        {
                            selectedPage = currentPage;
                            StandartMessage.DisplayError(
                                string.Format("Wrong input. Enter the number of a page (from {0} to {1})",
                                1, paginator.PageCount));
                        }
                    }
                    else
                    {
                        quit = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("No product found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        private static void PrintResults(IEnumerable<Product> result, int itemsOnPage)
        {
            foreach (Product product in result)
                Console.WriteLine(product);
            // The number or lines should allways be equal to the number of items on a page
            if (result.Count() < itemsOnPage)
                for (int i = 0; i < itemsOnPage - result.Count(); i++)
                    Console.WriteLine(new string(' ', Console.WindowWidth - 1));
        }
    }
}
