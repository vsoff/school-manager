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
        PaginationResponse<TEntity> GetPage(SearchPaginationRequest request);
        PaginationResponse<TEntity> GetPageWithSearch(SearchPaginationRequest request);
    }
}
