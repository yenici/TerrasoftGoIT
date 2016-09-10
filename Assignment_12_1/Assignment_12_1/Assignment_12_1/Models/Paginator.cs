using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_12_1.Models
{
    /**
     * 
     * Реализовать метод пагинации результатов. Т.е.мы можем из базы получить список товаров,
     * разбитый по страницам.
     * Пользователь может указать какую страницу ему выбрать, при этом ему предлагается только
     * из существующих страниц (т.е.больше 0, меньше максимального числа страниц).
     * Результатов на страницу – 2.
     * 
     */
    class Paginator<T>
    {
        private IEnumerable<T> source;
        private int itemsOnPage;
        public decimal PageCount { get; private set; }
        public Paginator(IEnumerable<T> source, int itemsOnPage)
        {
            this.source = source;
            this.itemsOnPage = itemsOnPage;
            this.PageCount = Math.Ceiling((decimal)(this.source.Count() / this.itemsOnPage));
        }
        public IEnumerable<T> GetPage(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > this.PageCount)
                throw new Exception(
                    string.Format("Wrong page number. The maximum number of a page is {0}.", this.PageCount));
            return this.source.Skip(this.itemsOnPage * (pageNumber - 1)).Take(this.itemsOnPage);
        }
    }
}
