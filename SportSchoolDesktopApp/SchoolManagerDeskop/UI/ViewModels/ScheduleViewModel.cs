using SchoolManagerDeskop.UI.Base;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class ScheduleViewModel : PropertyChangedNotifier
    {
        //private ScheduleItemModel selectedPhone;
        public ObservableCollection<ScheduleItemModel> ScheduleItems { get; set; }

        public ScheduleViewModel()
        {
            ScheduleItems = new ObservableCollection<ScheduleItemModel>
            {
                new ScheduleItemModel { Time = TimeSpan.FromHours(1), Hall = 1, GroupName = "Группа 1", StudentsCount = -5, ItemColor = ScheduleColor.Gray},
                new ScheduleItemModel { Time = TimeSpan.FromHours(1), Hall = 1, GroupName = "Группа 1", StudentsCount = -2, ItemColor = ScheduleColor.Gray},
                new ScheduleItemModel { Time = TimeSpan.FromHours(1), Hall = 1, GroupName = "Группа 1", StudentsCount = 0, ItemColor = ScheduleColor.Green},
                new ScheduleItemModel { Time = TimeSpan.FromHours(2), Hall = 2, GroupName = "Группа 2", StudentsCount = 10, ItemColor = ScheduleColor.Red},
                new ScheduleItemModel { Time = TimeSpan.FromHours(2), Hall = 2, GroupName = "Группа 3", StudentsCount = 10, ItemColor = ScheduleColor.Red},
                new ScheduleItemModel { Time = TimeSpan.FromHours(2), Hall = 2, GroupName = "Группа 4", StudentsCount = 10, ItemColor = ScheduleColor.Red},
                new ScheduleItemModel { Time = TimeSpan.FromHours(3), Hall = 1, GroupName = "Группа 5", StudentsCount = 20, ItemColor = ScheduleColor.Yellow},
                new ScheduleItemModel { Time = TimeSpan.FromHours(3), Hall = 1, GroupName = "Группа 6", StudentsCount = 20, ItemColor = ScheduleColor.Yellow},
                new ScheduleItemModel { Time = TimeSpan.FromHours(3), Hall = 1, GroupName = "Группа 7", StudentsCount = 20, ItemColor = ScheduleColor.Yellow},
            };
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyPropertyChanged(nameof(Time));
            }
        }

        private string _groupName;
        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                NotifyPropertyChanged(nameof(GroupName));
            }
        }

        private string _hall;
        public string Hall
        {
            get { return _hall; }
            set
            {
                _hall = value;
                NotifyPropertyChanged(nameof(Hall));
            }
        }

        private int _studentsCount;
        public int StudentsCount
        {
            get { return _studentsCount; }
            set
            {
                _studentsCount = value;
                NotifyPropertyChanged(nameof(StudentsCount));
            }
        }
    }
}
