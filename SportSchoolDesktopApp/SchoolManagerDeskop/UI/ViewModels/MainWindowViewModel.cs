
using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Enums;
using SchoolManagerDeskop.Core.Repositories;
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
        private readonly ItemsListEditWindowViewModel<Group, GroupModel> _groupsEditWindowViewModel;
        private readonly ItemsListEditWindowViewModel<Student, StudentModel> _studentsEditWindowViewModel;
        private readonly ItemsListEditWindowViewModel<Trainer, TrainerModel> _trainersEditWindowViewModel;
        private readonly ItemsListEditWindowViewModel<ScheduleSubject, ScheduleSubjectModel> _scheduleEditWindowViewModel;
        public ScheduleViewModel ScheduleViewModel { get; private set; }

        public MainWindowViewModel(IWindowsDisplayRegistry windowsDisplayRegistry,
            ItemsListEditWindowViewModel<Group, GroupModel> groupsEditWindowViewModel,
            ItemsListEditWindowViewModel<Student, StudentModel> studentsEditWindowViewModel,
            ItemsListEditWindowViewModel<Trainer, TrainerModel> trainersEditWindowViewModel,
            ItemsListEditWindowViewModel<ScheduleSubject, ScheduleSubjectModel> scheduleEditWindowViewModel,
            ScheduleViewModel scheduleViewModel)
        {
            _windowsDisplayRegistry = windowsDisplayRegistry ?? throw new ArgumentNullException(nameof(windowsDisplayRegistry));
            _groupsEditWindowViewModel = groupsEditWindowViewModel ?? throw new ArgumentNullException(nameof(groupsEditWindowViewModel));
            _studentsEditWindowViewModel = studentsEditWindowViewModel ?? throw new ArgumentNullException(nameof(studentsEditWindowViewModel));
            _trainersEditWindowViewModel = trainersEditWindowViewModel ?? throw new ArgumentNullException(nameof(trainersEditWindowViewModel));
            _scheduleEditWindowViewModel = scheduleEditWindowViewModel ?? throw new ArgumentNullException(nameof(scheduleEditWindowViewModel));
            ScheduleViewModel = scheduleViewModel ?? throw new ArgumentNullException(nameof(scheduleViewModel));

            OnCommand = new RelayCommand(_ => MessageBox.Show("Test element clicked."));
            GroupsEditCommand = new RelayCommand(_ => _windowsDisplayRegistry.ShowWindow(_groupsEditWindowViewModel, true));
            StudentsEditCommand = new RelayCommand(_ => _windowsDisplayRegistry.ShowWindow(_studentsEditWindowViewModel, true));
            TrainersEditCommand = new RelayCommand(_ => _windowsDisplayRegistry.ShowWindow(_trainersEditWindowViewModel, true));
            ScheduleEditCommand = new RelayCommand(_ => _windowsDisplayRegistry.ShowWindow(_scheduleEditWindowViewModel, true));
            OpenReportsCommand = new RelayCommand(_ => MessageBox.Show("Окно отчётов."));
            OpenSubscriptionsCommand = new RelayCommand(_ => MessageBox.Show("Окно абонементов."));
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
