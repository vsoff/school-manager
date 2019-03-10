using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories.Pagination
{
    public class PaginationResponse<T>
    {
        public T[] Items { get; set; }
        public int Limit { get; set; }
        public int TotalItemsCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public int Skip => CurrentPageIndex * Limit;
        public int PagesCount => (TotalItemsCount + Limit - 1) / Limit;
    }
}
