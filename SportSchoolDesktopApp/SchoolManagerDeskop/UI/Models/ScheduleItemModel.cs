using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Models
{
    public class ScheduleItemModel
    {
        public int Hall { get; set; }
        public int GroupId { get; set; }
        public TimeSpan Time { get; set; }
        public string GroupName { get; set; }
        public int StudentsCount { get; set; }
        public ScheduleColor ItemColor { get; set; }
    }
}
