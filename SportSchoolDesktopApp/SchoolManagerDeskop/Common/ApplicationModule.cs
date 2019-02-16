using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Models;
using SchoolManagerDeskop.UI.ViewModels;
using SchoolManagerDeskop.UI.Windows;
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
            container.RegisterType<IWindowsDisplayRegistry, WindowsDisplayRegistry>(new SingletonLifetimeManager());
            container.RegisterType<IDialogsDisplayRegistry, DialogsDisplayRegistry>(new SingletonLifetimeManager());

            RegisterViewModels(container);
            ConfigureDisplayRegisters(container);
        }

        private static void RegisterViewModels(IUnityContainer container)
        {
            container.RegisterType<MainWindow>(new TransientLifetimeManager());
            container.RegisterType<ItemsListEditWindow>(new TransientLifetimeManager());

            container.RegisterInstance(new MainWindowViewModel(
                container.Resolve<IWindowsDisplayRegistry>()
            ));
            container.RegisterInstance(new ItemsListEditWindowViewModel<StudentModel>(
            //container.Resolve<IWindowsDisplayRegistry>()
            ));
        }

        private static void ConfigureDisplayRegisters(IUnityContainer container)
        {
            var windowsRegistry = container.Resolve<IWindowsDisplayRegistry>();
            windowsRegistry.AddWindowType<MainWindowViewModel, WpfDisplayWindow<MainWindow>>();
            windowsRegistry.AddWindowType<ItemsListEditWindowViewModel<StudentModel>, WpfDisplayWindow<ItemsListEditWindow>>();

            //ItemsListEditWindowViewModel<StudentModel>
            //windowsRegistry.ShowWindow();
        }
    }
}
