
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Common.Commands;
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
        public ScheduleViewModel ScheduleViewModel { get; }

        public MainWindowViewModel()
        {
            ScheduleViewModel = new ScheduleViewModel();

            OnCommand = new RelayCommand(_ => MessageBox.Show("Test element clicked."));
            StudentsEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования учеников."));
            TrainersEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования тренеров."));
            ScheduleEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования расписания."));
            GroupsEditCommand = new RelayCommand(_ => MessageBox.Show("Окно редактирования групп."));
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
