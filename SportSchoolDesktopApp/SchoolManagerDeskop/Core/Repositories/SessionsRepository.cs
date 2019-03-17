using SchoolManagerDeskop.Common.Services;
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
        Session GetOrCreateSession(long groupId, DateTime dateTime);
        void RegisterStudentInSession(long studentId, long sessionId);
        void UnregisterStudentInSession(long studentId, long sessionId);
    }

    public class SessionsRepository : Repository<Session>, ISessionsRepository
    {
        private readonly IDateTimeService _dateTimeService;

        public SessionsRepository(
            ISportEntitiesContextProvider sportEntitiesContextProvider,
            IDateTimeService dateTimeService)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public Session GetOrCreateSession(long groupId, DateTime dateTime)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                // Пытаемся найти сессию в БД.
                Session existsEntity = GetObjectWithIncludes(context).FirstOrDefault(x => x.GroupId == groupId);
                if (existsEntity != null)
                    return existsEntity;

                // Если не нашли, то создаём новую.
                Session newEntity = new Session
                {
                    GroupId = groupId,
                    Date = dateTime.Date,
                    Time = dateTime.TimeOfDay
                };

                Session temp = context.Set<Session>().Add(newEntity);
                context.SaveChanges();
                return temp;
            }
        }

        public void RegisterStudentInSession(long studentId, long sessionId)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                StudentInSession temp = context.Set<StudentInSession>().Add(new StudentInSession
                {
                    StudentId = studentId,
                    SessionId = sessionId,
                    RegistrationDate = _dateTimeService.GetCurrentTime()
                });
                context.SaveChanges();
            }
        }

        public void UnregisterStudentInSession(long studentId, long sessionId)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                IQueryable<StudentInSession> dbEntities = context.Set<StudentInSession>()
                    .Where(x => x.StudentId == studentId && x.SessionId == sessionId);

                context.Set<StudentInSession>().RemoveRange(dbEntities);
                context.SaveChanges();
            }
        }

        internal override IQueryable<Session> GetObjectWithIncludes(DbContext context) => context.Set<Session>().Include(x => x.Students).Include(x => x.Group).Include(x => x.Group.Trainer);

        internal override Expression<Func<Session, bool>> GetSearchExpression(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
