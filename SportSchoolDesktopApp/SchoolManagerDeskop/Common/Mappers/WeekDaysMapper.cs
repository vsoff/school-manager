using SchoolManagerDeskop.Core.Enums;
using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class WeekDaysMapper : IModelMapper<WeekDayCore, WeekDayModel>
    {
        public WeekDayCore ToCore(WeekDayModel obj) => (WeekDayCore)obj;

        public WeekDayModel ToModel(WeekDayCore obj) => (WeekDayModel)obj;
    }
}
