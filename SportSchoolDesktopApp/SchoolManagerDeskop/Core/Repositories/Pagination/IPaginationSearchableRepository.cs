using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories.Pagination
{
    public interface IPaginationSearchableRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        TEntity[] Search(string searchString);
        PaginationResponse<TEntity> GetPage(PaginationRequest request);
        PaginationResponse<TEntity> GetPageWithSearch(SearchPaginationRequest request);
    }
}
