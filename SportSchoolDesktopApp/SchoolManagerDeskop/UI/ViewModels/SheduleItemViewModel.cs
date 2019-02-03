using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class SheduleItemViewModel
    {
        public ScheduleItemModel ScheduleModel { get; set; }

        public SheduleItemViewModel(ScheduleItemModel scheduleModel)
        {
            ScheduleModel = scheduleModel;
        }
    }
}
