using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Enums;
using SchoolManagerDeskop.Core.Repositories;
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
    public delegate void WeekDayChangedEventHandler(WeekDayModel weekDay);

    /// <summary>
    /// Предоставляет метод, обрабатывающий событие, возникающее при выборе занятия из списка.
    /// </summary>
    /// <param name="selectedScheduleItem">Объект занятия из списка.</param>
    public delegate void ScheduleItemSelectedEventHandler(ScheduleSubjectItemModel selectedScheduleItem);

    /// <summary>
    /// ViewModel расписания.
    /// </summary>
    public class ScheduleViewModel : ViewModelBase
    {
        private readonly IModelMapper<ScheduleSubject, ScheduleSubjectItemModel> _scheduleItemsMapper;
        private readonly IModelMapper<WeekDayCore, WeekDayModel> _weekDaysMapper;
        private readonly IScheduleRepository _scheduleRepository;

        /// <summary>
        /// Выбранный день недели.
        /// </summary>
        private WeekDayModel _selectedWeekDay;

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
        public ObservableCollection<ScheduleSubjectItemModel> ScheduleItems { get; set; }

        public ScheduleViewModel(
            IModelMapper<ScheduleSubject, ScheduleSubjectItemModel> scheduleItemsMapper,
            IModelMapper<WeekDayCore, WeekDayModel> weekDaysMapper,
            IScheduleRepository scheduleRepository)
        {
            _scheduleItemsMapper = scheduleItemsMapper ?? throw new ArgumentNullException(nameof(scheduleItemsMapper));
            _scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
            _weekDaysMapper = weekDaysMapper ?? throw new ArgumentNullException(nameof(weekDaysMapper));

            ScheduleItems = new ObservableCollection<ScheduleSubjectItemModel>();

            _selectedWeekDay = WeekDayModel.Undefined;
            WeekDaySelectCommand = new RelayCommand(o => WeekDaySelect((WeekDayModel)o));
            ScheduleItemClickedCommand = new RelayCommand(o =>
            {
                if ((ScheduleSubjectItemModel)o != null)
                {
                    var selectedScheduleItem = (ScheduleSubjectItemModel)o;
                    MessageBox.Show($"Окно регистрации на занятие `{selectedScheduleItem.Item.GroupCaption}`(Id: {selectedScheduleItem.Item.GroupId}) в {selectedScheduleItem.Item.StartTime}.");
                }
            });
        }

        /// <summary>
        /// Меняет текущий день недели.
        /// </summary>
        /// <param name="weekDay">День недели.</param>
        private void WeekDaySelect(WeekDayModel weekDay)
        {
            if (weekDay != _selectedWeekDay)
            {
                _selectedWeekDay = weekDay;

                // Обновляем расписание.
                ScheduleSubject[] schedueItems = _scheduleRepository.GetSchedulePerWeekDay(_weekDaysMapper.ToCore(weekDay));
                ScheduleSubjectItemModel[] items = schedueItems.Select(x => _scheduleItemsMapper.ToModel(x)).OrderBy(x => x.Item.StartTime).ToArray();
                SetScheduleItems(items);
            }
        }

        /// <summary>
        /// Устанавливает новый список занятий.
        /// </summary>
        /// <param name="scheduleItems">Список занятий.</param>
        private void SetScheduleItems(ScheduleSubjectItemModel[] scheduleItems)
        {
            // Устанавливаем новое расписание.
            ScheduleItems.Clear();
            foreach (var item in scheduleItems)
                ScheduleItems.Add(item);

            // Обновляем цвета расписания.
            UpdateScheduleColors();
        }

        /// <summary>
        /// Обновляет цвета в расписании.
        /// </summary>
        /// <remarks>Дополнительно должен происходить раз в N секунд.</remarks>
        private void UpdateScheduleColors()
        {
            foreach (var item in ScheduleItems)
            {
                item.ItemColor = ScheduleSubjectColor.Green;
            }
        }

        /// <summary>
        /// Выбранное занятие.
        /// </summary>
        public ScheduleSubjectItemModel SelectedScheduleItem
        {
            get { return _selectedScheduleItem; }
            set
            {
                _selectedScheduleItem = value;
                OnPropertyChanged(nameof(SelectedScheduleItem));
            }
        }
        private ScheduleSubjectItemModel _selectedScheduleItem;
    }
}
