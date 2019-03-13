
using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
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
    public class MainWindowViewModel : WindowViewModelBase
    {
        private readonly IDisplayService _displayService;
        public ScheduleViewModel ScheduleViewModel { get; private set; }

        public MainWindowViewModel(IDisplayService displayService,
            ScheduleViewModel scheduleViewModel)
        {
            _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
            ScheduleViewModel = scheduleViewModel ?? throw new ArgumentNullException(nameof(scheduleViewModel));

            GroupsEditCommand = new RelayCommand(_ => _displayService.ShowDialog<ItemsListEditWindowViewModel<Group, GroupModel>>());
            StudentsEditCommand = new RelayCommand(_ => _displayService.ShowDialog<ItemsListEditWindowViewModel<Student, StudentModel>>());
            TrainersEditCommand = new RelayCommand(_ => _displayService.ShowDialog<ItemsListEditWindowViewModel<Trainer, TrainerModel>>());
            ScheduleEditCommand = new RelayCommand(_ => _displayService.ShowDialog<ItemsListEditWindowViewModel<ScheduleSubject, ScheduleSubjectModel>>());

            OpenReportsCommand = new RelayCommand(_ => MessageBox.Show("Окно отчётов."));
            OpenSubscriptionsCommand = new RelayCommand(_ => _displayService.ShowDialog<SubscriptionWindowViewModel>());
        }

        public override void OnOpen()
        {
            ScheduleViewModel.OnOpen();
        }

        public override void OnClose()
        {
            ScheduleViewModel.OnClose();
        }

        public ICommand StudentsEditCommand { get; }
        public ICommand TrainersEditCommand { get; }
        public ICommand ScheduleEditCommand { get; }
        public ICommand GroupsEditCommand { get; }
        public ICommand OpenReportsCommand { get; }
        public ICommand OpenSubscriptionsCommand { get; }
    }
}
