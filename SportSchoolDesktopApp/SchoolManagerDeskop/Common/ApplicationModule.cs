using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Mappers;
using SchoolManagerDeskop.Common.Validators;
using SchoolManagerDeskop.Core.Dao;
using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.Core.Repositories;
using SchoolManagerDeskop.Core.Repositories.Pagination;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Models;
using SchoolManagerDeskop.UI.ViewModels;
using SchoolManagerDeskop.UI.ViewModels.EditWindows;
using SchoolManagerDeskop.UI.Windows;
using SchoolManagerDeskop.UI.Windows.EditWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            container.RegisterType<IPaginationSearchableRepository<Student>, StudentsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IRepository<Student>, StudentsRepository>(new SingletonLifetimeManager());
            container.RegisterType<IStudentsRepository, StudentsRepository>(new SingletonLifetimeManager());

            // Остальное
            container.RegisterType<IEntityValidator<StudentModel>, StudentsValidator>(new SingletonLifetimeManager());
            container.RegisterType<IEntityMapper<Student, StudentModel>, StudentsMapper>(new SingletonLifetimeManager());

            RegisterViewModels(container);
            ConfigureDisplayRegisters(container);
        }

        private static void RegisterViewModels(IUnityContainer container)
        {
            // Регистрация View.
            container.RegisterType<MainWindow>(new TransientLifetimeManager());
            container.RegisterType<StudentsEditWindow>(new TransientLifetimeManager());

            // Регистрация ViewModel.
            container.RegisterType<MainWindowViewModel>(new SingletonLifetimeManager());
            //container.RegisterType<StudentsEditWindowViewModel>(new SingletonLifetimeManager());
            container.RegisterType<ItemsListEditWindowViewModel<Student, StudentModel>>(new SingletonLifetimeManager());
        }

        private static void ConfigureDisplayRegisters(IUnityContainer container)
        {
            var windowsRegistry = container.Resolve<IWindowsDisplayRegistry>();
            windowsRegistry.AddWindowType<MainWindowViewModel, WpfDisplayWindow<MainWindow>>();
            windowsRegistry.AddWindowType<ItemsListEditWindowViewModel<Student, StudentModel>, WpfDisplayWindow<StudentsEditWindow>>();
        }
    }
}
