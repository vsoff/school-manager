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
    public interface ISessionsRepository : IRepository<Session>
    {
        //Session GetSessionForGroupInTime();
    }

    public class SessionsRepository : Repository<Session>, ISessionsRepository
    {
        public SessionsRepository(ISportEntitiesContextProvider sportEntitiesContextProvider)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
        }

        internal override IQueryable<Session> GetObjectWithIncludes(DbContext context) => context.Set<Session>().Include(x => x.Students).Include(x => x.Group).Include(x => x.Group.Trainer);

        internal override Expression<Func<Session, bool>> GetSearchExpression(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
