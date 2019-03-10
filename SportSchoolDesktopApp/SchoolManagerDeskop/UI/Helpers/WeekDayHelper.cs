using SchoolManagerDeskop.Properties;
using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Helpers
{
    public static class WeekDayHelper
    {
        public static string GetWeekDayCaption(WeekDayModel weekDay)
        {
            if (weekDay == WeekDayModel.Undefined)
                return Resources.WeekDayCaption_Short_Never;

            List<string> days = new List<string>(7);

            if (weekDay.HasFlag(WeekDayModel.Monday))
                days.Add(Resources.WeekDayCaption_Short_Monday);
            if (weekDay.HasFlag(WeekDayModel.Tuesday))
                days.Add(Resources.WeekDayCaption_Short_Tuesday);
            if (weekDay.HasFlag(WeekDayModel.Wednesday))
                days.Add(Resources.WeekDayCaption_Short_Wednesday);
            if (weekDay.HasFlag(WeekDayModel.Thursday))
                days.Add(Resources.WeekDayCaption_Short_Thursday);
            if (weekDay.HasFlag(WeekDayModel.Friday))
                days.Add(Resources.WeekDayCaption_Short_Friday);
            if (weekDay.HasFlag(WeekDayModel.Saturday))
                days.Add(Resources.WeekDayCaption_Short_Saturday);
            if (weekDay.HasFlag(WeekDayModel.Sunday))
                days.Add(Resources.WeekDayCaption_Short_Sunday);

            return string.Join(",", days);
        }
    }
}
