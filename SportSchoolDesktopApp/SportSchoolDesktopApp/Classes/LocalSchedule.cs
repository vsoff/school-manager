using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSchoolDesktopApp.Classes
{
    public class LocalSchedule
    {
        public int GroupId { get; set; }
        public int SessionId { get; set; }
        public int TimeStart { get; set; }
        public string Caption { get; set; }
        public int Hall { get; set; }
        public int Count { get; set; }

        public string GetTimeStart()
        {
            int min = TimeStart % 60;
            return (int)((double)TimeStart / 60) + ":" + (min < 10 ? "0" + min : min.ToString());
        }

        //grid_Schedule.Rows.Add(item.TimeStart, item.Groups.Name + " (" + item.Groups.Trainers.LastName + ")", item.Hall, "", "зарегать");
    }
}
