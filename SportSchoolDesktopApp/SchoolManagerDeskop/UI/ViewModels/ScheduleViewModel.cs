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
    /// <summary>
    /// Предоставляет метод, обрабатывающий событие, возникающее при изменении выбранного дня недели.
    /// </summary>
    /// <param name="weekDay">День недели.</param>
    public delegate void WeekDayChangedEventHandler(WeekDay weekDay);

    /// <summary>
    /// Предоставляет метод, обрабатывающий событие, возникающее при выборе занятия из списка.
    /// </summary>
    /// <param name="selectedScheduleItem">Объект занятия из списка.</param>
    public delegate void ScheduleItemSelectedEventHandler(ScheduleItemModel selectedScheduleItem);

    /// <summary>
    /// ViewModel расписания.
    /// </summary>
    public class ScheduleViewModel : ViewModelBase
    {
        /// <summary>
        /// Выбранный день недели.
        /// </summary>
        private WeekDay _selectedWeekDay;

        /// <summary>
        /// Событие возникающее при выборе дня недели.
        /// </summary>
        public event WeekDayChangedEventHandler SelectedWeekDayChanged;

        /// <summary>
        /// Событие возникающее при выборе занятия из списка.
        /// </summary>
        public event ScheduleItemSelectedEventHandler ScheduleItemSelected;

        /// <summary>
        /// Команда вызываемая при выборе дня недели.
        /// </summary>
        public ICommand WeekDaySelectCommand { get; }

        /// <summary>
        /// Команда вызываемая при двойном клике на занятии в расписании.
        /// </summary>
        public ICommand ScheduleItemClickedCommand { get; }

        /// <summary>
        /// Коллекция занятий.
        /// </summary>
        public ObservableCollection<ScheduleItemModel> ScheduleItems { get; set; }

        public ScheduleViewModel()
        {
            ScheduleItems = new ObservableCollection<ScheduleItemModel>();

            _selectedWeekDay = WeekDay.Undefined;
            WeekDaySelectCommand = new RelayCommand(o => WeekDaySelect((WeekDay)o));
            ScheduleItemClickedCommand = new RelayCommand(o => ScheduleItemSelected?.Invoke((ScheduleItemModel)o));
        }

        /// <summary>
        /// Меняет текущий день недели.
        /// </summary>
        /// <param name="weekDay">День недели.</param>
        private void WeekDaySelect(WeekDay weekDay)
        {
            if (weekDay != _selectedWeekDay)
            {
                _selectedWeekDay = weekDay;
                SelectedWeekDayChanged?.Invoke(weekDay);
            }
        }

        /// <summary>
        /// Устанавливает новый список занятий.
        /// </summary>
        /// <param name="scheduleItems">Список занятий.</param>
        public void SetScheduleItems(ScheduleItemModel[] scheduleItems)
        {
            ScheduleItems.Clear();
            foreach (var item in scheduleItems)
                ScheduleItems.Add(item);
        }

        /// <summary>
        /// Выбранное занятие.
        /// </summary>
        public ScheduleItemModel SelectedScheduleItem
        {
            get { return _selectedScheduleItem; }
            set
            {
                _selectedScheduleItem = value;
                OnPropertyChanged(nameof(SelectedScheduleItem));
            }
        }
        private ScheduleItemModel _selectedScheduleItem;
    }
}
