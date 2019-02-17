using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories.Pagination
{
    public class PaginationRequest
    {
        public int PageIndex { get; set; }
        public int ItemsPerPage { get; set; }
        public int Skip => PageIndex * ItemsPerPage;
    }
}
