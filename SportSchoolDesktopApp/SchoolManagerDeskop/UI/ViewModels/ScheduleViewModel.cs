using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using SchoolManagerDeskop.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        public ObservableCollection<ScheduleItemModel> ScheduleItems { get; set; }

        public ScheduleViewModel()
        {
            ScheduleItems = new ObservableCollection<ScheduleItemModel>
            {
                new ScheduleItemModel { Time = TimeSpan.FromHours(1), Hall = 1, GroupName = "Группа 1", StudentsCount = -5, ItemColor = ScheduleColor.Gray},
                new ScheduleItemModel { Time = TimeSpan.FromHours(2), Hall = 2, GroupName = "Группа 2", StudentsCount = 55, ItemColor = ScheduleColor.Green},
                new ScheduleItemModel { Time = TimeSpan.FromHours(3), Hall = 3, GroupName = "Группа 4", StudentsCount = 10, ItemColor = ScheduleColor.Red},
                new ScheduleItemModel { Time = TimeSpan.FromHours(4), Hall = 4, GroupName = "Группа 7", StudentsCount = 20, ItemColor = ScheduleColor.Yellow},
            };

            OnCommand = new RelayCommand(o => DoStuff(o));
            RegisterCommand = new RelayCommand(o => DoStuff(o));
        }

        public ICommand RegisterCommand { get; }
        public ICommand OnCommand { get; }

        private void DoStuff(object obj)
        {
            Debug.WriteLine($"Element clicked. Object: {obj ?? "NULL"}");
        }
    }
}
