using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories
{
    public interface ISubscriptionsRepository : IRepository<Subscription>
    {
        PaginationResponse<Subscription> GetPageByStudent(long studentId, SearchPaginationRequest request);
    }

    public class SubscriptionsRepository : Repository<Subscription>, ISubscriptionsRepository
    {
        public SubscriptionsRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
        }

        public PaginationResponse<Subscription> GetPageByStudent(long studentId, SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return GetPageWithSearch(context, request, x => x.StudentId == studentId);
        }

        internal override IQueryable<Subscription> GetObjectWithIncludes(DbContext context) => context.Set<Subscription>()
            .Include(x => x.Student).Include(x => x.Group).Include(x => x.Group.Trainer);

        internal override Expression<Func<Subscription, bool>> GetSearchExpression(string searchText)
        {
            throw new NotImplementedException($"Поиск для {nameof(Subscription)} не реализован");
        }
    }
}
