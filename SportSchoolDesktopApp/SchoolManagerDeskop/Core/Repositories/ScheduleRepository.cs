using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Enums;
using SchoolManagerDeskop.Core.Extensions;
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

            _allIncludes = new Expression<Func<ScheduleSubject, object>>[]
            {
                x => x.Group,
                x => x.Group.Trainer
            };
        }

        /// <inheritdoc />
        public ScheduleSubject[] GetSchedulePerWeekDay(WeekDayCore weekDay)
        {
            using (var context = _sportEntitiesContextProvider.GetContext())
            {
                DateTime currentDate = DateTime.Now.Date;
                return context.Select(_allIncludes)
                    .Where(x => x.WeekDays.HasFlag(weekDay))
                    .ToArray();
            }
        }

        internal override Expression<Func<ScheduleSubject, bool>>[] GetSearchExpression(string searchText) => new Expression<Func<ScheduleSubject, bool>>[]
        {
            x => x.Group.Name.Contains(searchText)
        };
    }
}
