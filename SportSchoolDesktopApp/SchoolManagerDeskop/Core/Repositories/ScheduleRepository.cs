using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Enums;
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
    public interface IScheduleRepository : IRepository<ScheduleSubject>
    {
        /// <summary>
        /// Возвращает элементы расписания для переданного дня недели.
        /// </summary>
        ScheduleSubject[] GetSchedulePerWeekDay(WeekDayCore weekDay);
    }

    public class ScheduleRepository : Repository<ScheduleSubject>, IScheduleRepository
    {
        private readonly ISessionsRepository _sessionsRepository;

        public ScheduleRepository(
            ISportEntitiesContextProvider sportEntitiesContextProvider,
            ISessionsRepository sessionsRepository)
        {
            _sportEntitiesContextProvider = sportEntitiesContextProvider ?? throw new ArgumentNullException(nameof(sportEntitiesContextProvider));
            _sessionsRepository = sessionsRepository ?? throw new ArgumentNullException(nameof(sessionsRepository));
        }

        /// <inheritdoc />
        public ScheduleSubject[] GetSchedulePerWeekDay(WeekDayCore weekDay)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                DateTime currentDate = DateTime.Now.Date;
                return GetObjectWithIncludes(context).Where(x => x.WeekDays.HasFlag(weekDay)).ToArray();
            }
        }

        internal override IQueryable<ScheduleSubject> GetObjectWithIncludes(DbContext context) => context.Set<ScheduleSubject>().Include(x => x.Group).Include(x => x.Group.Trainer);

        internal override Expression<Func<ScheduleSubject, bool>> GetSearchExpression(string searchText)
        {
            return x => x.Group.Name.Contains(searchText);
        }
    }
}
