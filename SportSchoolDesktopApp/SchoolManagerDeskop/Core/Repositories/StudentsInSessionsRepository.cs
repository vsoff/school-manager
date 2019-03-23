using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Repositories
{

    public interface IStudentsInSessionsRepository : IRepository<StudentInSession>
    {
        PaginationResponse<StudentInSession> GetStudentsInSessionPage(long sessionId, SearchPaginationRequest request);
    }

    public class StudentsInSessionsRepository : Repository<StudentInSession>, IStudentsInSessionsRepository
    {
        public StudentsInSessionsRepository(
            ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));

            _allIncludes = new Expression<Func<StudentInSession, object>>[]
            {
                x => x.Student,
                x => x.Session,
            };
        }

        public PaginationResponse<StudentInSession> GetStudentsInSessionPage(long sessionId, SearchPaginationRequest request)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
                return GetPageWithSearch<StudentInSession>(context, request,
                new Expression<Func<StudentInSession, object>>[]
                {
                    x => x.Student
                }, new Expression<Func<StudentInSession, bool>>[]
                {
                    x => x.SessionId == sessionId
                });
        }

        internal override Expression<Func<StudentInSession, bool>>[] GetSearchExpression(string searchText) => throw new NotImplementedException();
    }
}
