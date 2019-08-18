using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.Common.Validators;
using SchoolManagerDeskop.Common.Workers;
using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Enums;
using SchoolManagerDeskop.Core.Repositories;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Models;
using SchoolManagerDeskop.UI.ViewModels;
using SchoolManagerDeskop.UI.ViewModels.EditWindows;
using SchoolManagerDeskop.UI.Windows;
using SchoolManagerDeskop.UI.Windows.Dialogs;
using SchoolManagerDeskop.UI.Windows.EditWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemCard.Shell;
using Unity;
using Unity.Lifetime;

namespace SchoolManagerDeskop.Common
{
    public static class ApplicationModule
    {
        public static void Register(IUnityContainer container)
        {
            container.AddExtension(new Diagnostic());

            // Регистрация регистров.
            container.RegisterType<IWindowsDisplayRegistry, WindowsDisplayRegistry>(new SingletonLifetimeManager());
            container.RegisterType<IDialogsDisplayRegistry, DialogsDisplayRegistry>(new SingletonLifetimeManager());

            // Регистрация провайдеров.
            container.RegisterType<ISportEntitiesContextProvider, SportEntitiesContextProvider>(new SingletonLifetimeManager());

            // Регистрация репозиториев.
            RegisterRepositories(container);

            // Валидаторы.
            container.RegisterType<IEntityValidator<GroupModel>, GroupsValidator>(new SingletonLifetimeManager());
            container.RegisterType<IEntityValidator<StudentModel>, StudentsValidator>(new SingletonLifetimeManager());
            container.RegisterType<IEntityValidator<TrainerModel>, TrainersValidator>(new SingletonLifetimeManager());
            container.RegisterType<IEntityValidator<SubscriptionModel>, SubscriptionsValidator>(new SingletonLifetimeManager());
            container.RegisterType<IEntityValidator<ScheduleSubjectModel>, ScheduleSubjectsValidator>(new SingletonLifetimeManager());

            // Мапперы.
            container.RegisterType<IModelMapper<Group, GroupModel>, GroupsMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<Student, StudentModel>, StudentsMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<Trainer, TrainerModel>, TrainersMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<Subscription, SubscriptionModel>, SubscriptionsMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<ScheduleSubject, ScheduleSubjectModel>, ScheduleSubjectsMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<ScheduleSubject, ScheduleSubjectItemModel>, ScheduleSubjectItemsMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<WeekDayCore, WeekDayModel>, WeekDaysMapper>(new SingletonLifetimeManager());
            container.RegisterType<IModelMapper<DayOfWeek, WeekDayModel>, DayOfWeekMapper>(new SingletonLifetimeManager());

            // Сервисы
            container.RegisterType<IStudentRegistrationService, StudentRegistrationService>(new SingletonLifetimeManager());
            container.RegisterType<IDateTimeService, DefaultDateTimeService>(new SingletonLifetimeManager());
            container.RegisterType<IDisplayService, DisplayService>(new SingletonLifetimeManager());

            // Другое.
            container.RegisterType<IWorkerController, DefaultWorkerController>(new SingletonLifetimeManager());
            container.RegisterType<ISmartReaderListener, SmartReaderListener>(new SingletonLifetimeManager());

            RegisterViewModels(container);
            ConfigureDisplayRegisters(container);
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IPaginationSearchableRepository<Group>, GroupsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IPaginationSearchableRepository<Student>, StudentsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IPaginationSearchableRepository<Trainer>, TrainersRepository>(new SingletonLifetimeManager());
            container.RegisterType<IPaginationSearchableRepository<Subscription>, SubscriptionsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IPaginationSearchableRepository<ScheduleSubject>, ScheduleRepository>(new SingletonLifetimeManager());

            container.RegisterType<IRepository<Group>, GroupsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IRepository<Student>, StudentsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IRepository<Trainer>, TrainersRepository>(new SingletonLifetimeManager());
            container.RegisterType<IRepository<Subscription>, SubscriptionsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IRepository<ScheduleSubject>, ScheduleRepository>(new SingletonLifetimeManager());
            container.RegisterType<IRepository<StudentInSession>, StudentsInSessionsRepository>(new SingletonLifetimeManager());

            container.RegisterType<IGroupsRepository, GroupsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IStudentsRepository, StudentsRepository>(new SingletonLifetimeManager());
            container.RegisterType<ITrainersRepository, TrainersRepository>(new SingletonLifetimeManager());
            container.RegisterType<IScheduleRepository, ScheduleRepository>(new SingletonLifetimeManager());
            container.RegisterType<ISessionsRepository, SessionsRepository>(new SingletonLifetimeManager());
            container.RegisterType<ISubscriptionsRepository, SubscriptionsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IStudentsInSessionsRepository, StudentsInSessionsRepository>(new SingletonLifetimeManager());
        }

        private static void RegisterViewModels(IUnityContainer container)
        {
            // Регистрация View.
            container.RegisterType<MainWindow>(new TransientLifetimeManager());
            container.RegisterType<GroupsEditWindow>(new TransientLifetimeManager());
            container.RegisterType<StudentsEditWindow>(new TransientLifetimeManager());
            container.RegisterType<TrainersEditWindow>(new TransientLifetimeManager());
            container.RegisterType<ScheduleEditWindow>(new TransientLifetimeManager());
            container.RegisterType<RegistrationWindow>(new TransientLifetimeManager());
            container.RegisterType<SubscriptionsWindow>(new TransientLifetimeManager());

            // Регистрация простых ViewModel.
            container.RegisterType<ScheduleViewModel>(new SingletonLifetimeManager());

            // Регистрация ViewModel для окон.
            container.RegisterType<MainWindowViewModel>(new SingletonLifetimeManager());
            container.RegisterType<RegistrationWindowViewModel>(new TransientLifetimeManager());
            container.RegisterType<SubscriptionsWindowViewModel>(new TransientLifetimeManager());
            container.RegisterType<ItemsListEditWindowViewModel<Group, GroupModel>, GroupsListEditWindowViewModel>(new SingletonLifetimeManager());
            container.RegisterType<ItemsListEditWindowViewModel<Student, StudentModel>>(new SingletonLifetimeManager());
            container.RegisterType<ItemsListEditWindowViewModel<Trainer, TrainerModel>>(new SingletonLifetimeManager());
            container.RegisterType<ItemsListEditWindowViewModel<ScheduleSubject, ScheduleSubjectModel>, ScheduleListEditWindowViewModel>(new SingletonLifetimeManager());

            // Регистрация ViewModels для диалогов.
            container.RegisterType<SelectEntityDialogViewModel<Group, GroupModel>>(new TransientLifetimeManager());
            container.RegisterType<SelectEntityDialogViewModel<Trainer, TrainerModel>>(new TransientLifetimeManager());
        }

        private static void ConfigureDisplayRegisters(IUnityContainer container)
        {
            // Заносим записи в реестр о связях окон с ViewModel.
            var windowsRegistry = container.Resolve<IWindowsDisplayRegistry>();
            windowsRegistry.AddWindowType<MainWindowViewModel, WpfDisplayWindow<MainWindow>>();
            windowsRegistry.AddWindowType<SubscriptionsWindowViewModel, WpfDisplayWindow<SubscriptionsWindow>>();
            windowsRegistry.AddWindowType<ItemsListEditWindowViewModel<Group, GroupModel>, WpfDisplayWindow<GroupsEditWindow>>();
            windowsRegistry.AddWindowType<ItemsListEditWindowViewModel<Student, StudentModel>, WpfDisplayWindow<StudentsEditWindow>>();
            windowsRegistry.AddWindowType<ItemsListEditWindowViewModel<Trainer, TrainerModel>, WpfDisplayWindow<TrainersEditWindow>>();
            windowsRegistry.AddWindowType<ItemsListEditWindowViewModel<ScheduleSubject, ScheduleSubjectModel>, WpfDisplayWindow<ScheduleEditWindow>>();

            // Заносим записи в реестр о связях диалоговых окон с ViewModel, типом аргумента и типом результата.
            var dialogsRegistry = container.Resolve<IDialogsDisplayRegistry>();
            dialogsRegistry.AddWindowType<RegistrationWindowViewModel, WpfDisplayWindow<RegistrationWindow>, ScheduleSubjectModel, object>();
            dialogsRegistry.AddWindowType<SelectEntityDialogViewModel<Group, GroupModel>, WpfDisplayWindow<SelectEntityDialog>, object, GroupModel>();
            dialogsRegistry.AddWindowType<SelectEntityDialogViewModel<Student, StudentModel>, WpfDisplayWindow<SelectEntityDialog>, object, StudentModel>();
            dialogsRegistry.AddWindowType<SelectEntityDialogViewModel<Trainer, TrainerModel>, WpfDisplayWindow<SelectEntityDialog>, object, TrainerModel>();
            dialogsRegistry.AddWindowType<SelectEntityDialogViewModel<ScheduleSubject, ScheduleSubjectModel>, WpfDisplayWindow<SelectEntityDialog>, object, ScheduleSubjectModel>();
        }
    }
}