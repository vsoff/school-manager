
using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using SchoolManagerDeskop.UI.ViewModels.EditWindows;
using SchoolManagerDeskop.UI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IWindowsDisplayRegistry _windowsDisplayRegistry;
        private readonly ItemsListEditWindowViewModel<Student, StudentModel> _itemsListEditWindowViewModel;
        public ScheduleViewModel ScheduleViewModel { get; }

        public MainWindowViewModel(IWindowsDisplayRegistry windowsDisplayRegistry,
            ItemsListEditWindowViewModel<Student, StudentModel> itemsListEditWindowViewModel)
        {
            _windowsDisplayRegistry = windowsDisplayRegistry ?? throw new ArgumentNullException(nameof(windowsDisplayRegistry));
            _itemsListEditWindowViewModel = itemsListEditWindowViewModel ?? throw new ArgumentNullException(nameof(itemsListEditWindowViewModel));

            ScheduleViewModel = new ScheduleViewModel();
            ScheduleViewModel.SelectedWeekDayChanged += SelectedWeekDayChanged;
            ScheduleViewModel.ScheduleItemSelected += ScheduleItemSelected;
            ScheduleViewModel.SetScheduleItems(new ScheduleItemModel[]
            {
                new ScheduleItemModel { Time = TimeSpan.FromHours(1), Hall = 1, GroupName = "Группа 1", StudentsCount = -5, ItemColor = ScheduleColor.Gray},
                new ScheduleItemModel { Time = TimeSpan.FromHours(2), Hall = 2, GroupName = "Группа 2", StudentsCount = 55, ItemColor = ScheduleColor.Green},
                new ScheduleItemModel { Time = TimeSpan.FromHours(3), Hall = 3, GroupName = "Группа 4", StudentsCount = 10, ItemColor = ScheduleColor.Red},
                new ScheduleItemModel { Time = TimeSpan.FromHours(4), Hall = 4, GroupName = "Группа 7", StudentsCount = 20, ItemColor = ScheduleColor.Yellow},
            });

            OnCommand = new RelayCommand(_ => MessageBox.Show("Test element clicked."));
            StudentsEditCommand = new RelayCommand(_ => _windowsDisplayRegistry.ShowWindow(_itemsListEditWindowViewModel, true));
            TrainersEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования тренеров."));
            ScheduleEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования расписания."));
            GroupsEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования групп."));
            OpenReportsCommand = new RelayCommand(_ => MessageBox.Show("Окно отчётов."));
            OpenSubscriptionsCommand = new RelayCommand(_ => MessageBox.Show("Окно абонементов."));
        }

        private void ScheduleItemSelected(ScheduleItemModel selectedScheduleItem)
        {
            MessageBox.Show($"Окно регистрации на занятие `{selectedScheduleItem.GroupName}` в {selectedScheduleItem.Time}.");
        }

        private void SelectedWeekDayChanged(WeekDay weekDay)
        {
            MessageBox.Show($"Выбран день недели: {weekDay}");
        }

        public ICommand OnCommand { get; }
        public ICommand StudentsEditCommand { get; }
        public ICommand TrainersEditCommand { get; }
        public ICommand ScheduleEditCommand { get; }
        public ICommand GroupsEditCommand { get; }
        public ICommand OpenReportsCommand { get; }
        public ICommand OpenSubscriptionsCommand { get; }
    }
}
