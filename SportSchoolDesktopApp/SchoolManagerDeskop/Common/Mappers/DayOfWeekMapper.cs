using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class DayOfWeekMapper : IModelMapper<DayOfWeek, WeekDayModel>
    {
        public DayOfWeek ToCore(WeekDayModel obj) => (DayOfWeek)obj;

        public WeekDayModel ToModel(DayOfWeek obj)
        {
            switch (obj)
            {
                case DayOfWeek.Friday: return WeekDayModel.Friday;
                case DayOfWeek.Monday: return WeekDayModel.Monday;
                case DayOfWeek.Sunday: return WeekDayModel.Sunday;
                case DayOfWeek.Tuesday: return WeekDayModel.Tuesday;
                case DayOfWeek.Saturday: return WeekDayModel.Saturday;
                case DayOfWeek.Thursday: return WeekDayModel.Thursday;
                case DayOfWeek.Wednesday: return WeekDayModel.Wednesday;
                default: throw new InvalidCastException();
            }
        }
    }
}
