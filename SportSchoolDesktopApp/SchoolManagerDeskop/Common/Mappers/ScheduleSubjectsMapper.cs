using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Enums;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class ScheduleSubjectsMapper : IModelMapper<ScheduleSubject, ScheduleSubjectModel>
    {
        private readonly IModelMapper<WeekDayCore, WeekDayModel> _weekDaysMapper;

        public ScheduleSubjectsMapper(IModelMapper<WeekDayCore, WeekDayModel> weekDaysMapper)
        {
            _weekDaysMapper = weekDaysMapper ?? throw new ArgumentNullException(nameof(weekDaysMapper));
        }

        public ScheduleSubject ToCore(ScheduleSubjectModel obj) => new ScheduleSubject
        {
            Id = obj.Id,
            Hall = obj.Hall,
            IsPeriodic = obj.IsPeriodic,
            StartTime = obj.StartTime,
            WeekDays = _weekDaysMapper.ToCore(obj.WeekDays),
            GroupId = obj.GroupId
        };

        public ScheduleSubjectModel ToModel(ScheduleSubject obj) => new ScheduleSubjectModel
        {
            Id = obj.Id,
            Hall = obj.Hall,
            IsPeriodic = obj.IsPeriodic,
            StartTime = obj.StartTime,
            WeekDays = _weekDaysMapper.ToModel(obj.WeekDays),
            GroupId = obj.GroupId,
            GroupCaption = obj.Group.Name,
            TrainerCaption = obj.Group.Trainer.FullName
        };
    }
}
