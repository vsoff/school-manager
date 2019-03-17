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
        /// <summary>
        /// Возвращает страницу с абонементами для определенного студента.
        /// </summary>
        PaginationResponse<Subscription> GetPageByStudent(long studentId, SearchPaginationRequest request);

        /// <summary>
        /// Возвращает все активные абонементы ученика на указаное время.
        /// </summary>
        Subscription[] GetAllActiveSubscriptionsInTime(long studentId, DateTime dateTime);
    }

    public class SubscriptionsRepository : Repository<Subscription>, ISubscriptionsRepository
    {
        public SubscriptionsRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
        }

        public Subscription[] GetAllActiveSubscriptionsInTime(long studentId, DateTime dateTime)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return GetObjectWithIncludes(context)
                    .Where(x => x.StudentId == studentId
                        && dateTime >= x.DateStart
                        && dateTime <= x.DateEnd)
                    .ToArray();
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
