using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class ScheduleSubjectItemsMapper : IModelMapper<ScheduleSubject, ScheduleSubjectItemModel>
    {
        private readonly IModelMapper<ScheduleSubject, ScheduleSubjectModel> _scheduleMapper;

        public ScheduleSubjectItemsMapper(IModelMapper<ScheduleSubject, ScheduleSubjectModel> scheduleMapper)
        {
            _scheduleMapper = scheduleMapper ?? throw new ArgumentNullException(nameof(scheduleMapper));
        }

        public ScheduleSubject ToCore(ScheduleSubjectItemModel obj) =>
            throw new InvalidOperationException($"{nameof(ScheduleSubjectItemModel)} нельзя преобразовать к сущности {nameof(ScheduleSubject)}");

        public ScheduleSubjectItemModel ToModel(ScheduleSubject obj) => new ScheduleSubjectItemModel
        {
            Item = _scheduleMapper.ToModel(obj),
            StudentsCount = 0,
            ItemColor = ScheduleSubjectColor.Gray
        };
    }
}
