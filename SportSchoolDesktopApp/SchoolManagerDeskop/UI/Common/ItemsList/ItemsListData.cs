using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Common.ItemsList
{
    public class ItemsListData<T> where T : IDisplayableModel
    {
        /// <summary>
        /// Коллекция элементов.
        /// </summary>
        public T[] Items { get; set; }
        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int PagesCount { get; set; }
        /// <summary>
        /// Индекс текущей страницы.
        /// </summary>
        public int CurrentPageIndex { get; set; }
    }
}
