using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories.Pagination
{
    public interface IPaginationSearchableRepository<T>
    {
        T[] Search(string searchString);
        PaginationResponse<T> GetPage(PaginationRequest request);
        PaginationResponse<T> GetPageWithSearch(SearchPaginationRequest request);
    }
}
