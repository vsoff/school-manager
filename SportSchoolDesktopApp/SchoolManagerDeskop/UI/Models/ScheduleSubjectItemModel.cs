using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Models
{
    public class ScheduleSubjectItemModel : NotifyPropertyChanged
    {
        public ScheduleSubjectModel Item { get; set; }

        private int _studentsCount;
        public int StudentsCount
        {
            get { return _studentsCount; }
            set
            {
                _studentsCount = value;
                OnPropertyChanged(nameof(StudentsCount));
            }
        }

        private ScheduleSubjectColor _itemColor;
        public ScheduleSubjectColor ItemColor
        {
            get { return _itemColor; }
            set
            {
                _itemColor = value;
                OnPropertyChanged(nameof(ItemColor));
            }
        }
    }
}
