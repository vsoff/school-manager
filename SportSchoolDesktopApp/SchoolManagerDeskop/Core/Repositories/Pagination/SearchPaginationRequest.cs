using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories.Pagination
{
    public class SearchPaginationRequest
    {
        public string SearchText { get; set; }
        public int PageIndex { get; set; }
        public int Limit { get; set; }
        public int Skip => PageIndex * Limit;
    }
}
