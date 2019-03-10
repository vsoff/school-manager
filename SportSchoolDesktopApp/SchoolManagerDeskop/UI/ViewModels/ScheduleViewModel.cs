using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Workers;
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
    /// ViewModel расписания.
    /// </summary>
    public class ScheduleViewModel : ViewModelBase
    {
        /// <summary>
        /// Интервал обновления цветов расписания.
        /// </summary>
        private readonly TimeSpan _updateColorInterval = TimeSpan.FromSeconds(3);
        private IWorker _updateColorWorker;

        private readonly IModelMapper<ScheduleSubject, ScheduleSubjectItemModel> _scheduleItemsMapper;
        private readonly IModelMapper<WeekDayCore, WeekDayModel> _weekDaysMapper;
        private readonly IModelMapper<DayOfWeek, WeekDayModel> _dayOfWeekMapper;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IWorkerController _workerController;

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
            IModelMapper<DayOfWeek, WeekDayModel> dayOfWeekMapper,
            IScheduleRepository scheduleRepository,
            IWorkerController workerManager)
        {
            _scheduleItemsMapper = scheduleItemsMapper ?? throw new ArgumentNullException(nameof(scheduleItemsMapper));
            _scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
            _dayOfWeekMapper = dayOfWeekMapper ?? throw new ArgumentNullException(nameof(dayOfWeekMapper));
            _weekDaysMapper = weekDaysMapper ?? throw new ArgumentNullException(nameof(weekDaysMapper));
            _workerController = workerManager ?? throw new ArgumentNullException(nameof(workerManager));

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

        /// <inheritdoc />
        public override void OnOpen()
        {
            WeekDayModel weekDay = _dayOfWeekMapper.ToModel(DateTime.Now.DayOfWeek);
            WeekDaySelect(weekDay);
            _updateColorWorker = _workerController.StartWorker(UpdateScheduleColors, _updateColorInterval, false);
        }

        /// <inheritdoc />
        public override void OnClose()
        {
            _updateColorWorker?.Dispose();
        }

        /// <summary>
        /// Меняет текущий день недели.
        /// </summary>
        /// <param name="weekDay">День недели.</param>
        private void WeekDaySelect(WeekDayModel weekDay)
        {
            if (weekDay == WeekDayModel.Undefined)
                return;

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
            DateTime now = DateTime.Now;
            WeekDayModel currentWeekDay = _dayOfWeekMapper.ToModel(now.DayOfWeek);
            foreach (var item in ScheduleItems)
            {
                if (_selectedWeekDay != currentWeekDay)
                {
                    item.ItemColor = ScheduleSubjectColor.Gray;
                    continue;
                }
                if (now.TimeOfDay < item.Item.StartTime)
                    item.ItemColor = ScheduleSubjectColor.Green;
                else if (now.TimeOfDay >= item.Item.StartTime && now.TimeOfDay < item.Item.StartTime + TimeSpan.FromHours(1))
                    item.ItemColor = ScheduleSubjectColor.Yellow;
                else
                    item.ItemColor = ScheduleSubjectColor.Red;
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
