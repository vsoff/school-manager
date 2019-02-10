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
    public delegate void WeekDayChangedEventHandler(WeekDay weekDay);
    public delegate void ScheduleItemSelectedEventHandler(ScheduleItemModel selectedScheduleItem);

    public class ScheduleViewModel : ViewModelBase
    {
        private WeekDay _currentWeekDay;

        public event WeekDayChangedEventHandler SelectedWeekDayChanged;
        public event ScheduleItemSelectedEventHandler ScheduleItemSelected;

        public ICommand WeekDaySelectCommand { get; }

        public ObservableCollection<ScheduleItemModel> ScheduleItems { get; set; }

        public ScheduleViewModel()
        {
            ScheduleItems = new ObservableCollection<ScheduleItemModel>();

            _currentWeekDay = WeekDay.Undefined;
            WeekDaySelectCommand = new RelayCommand(o =>
            {
                var weekDay = (WeekDay)o;
                if (weekDay != _currentWeekDay)
                {
                    _currentWeekDay = weekDay;
                    SelectedWeekDayChanged?.Invoke(weekDay);
                }
            });
        }

        public void SetScheduleItems(ScheduleItemModel[] scheduleItems)
        {
            foreach (var item in scheduleItems)
                ScheduleItems.Add(item);
        }

        private ScheduleItemModel _selectedScheduleItem;
        public ScheduleItemModel SelectedScheduleItem
        {
            get { return _selectedScheduleItem; }
            set
            {
                _selectedScheduleItem = value;
                ScheduleItemSelected?.Invoke(value);
                OnPropertyChanged(nameof(SelectedScheduleItem));
            }
        }
    }
}
