using SchoolManagerDeskop.Common;
using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.Common.Services;
using SchoolManagerDeskop.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GemCard.Shell;
using Unity;

namespace SchoolManagerDeskop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IUnityContainer _unityContainer;

        public App()
        {
            _unityContainer = new UnityContainer();
            ApplicationModule.Register(_unityContainer);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Вывод главного окна.
            _unityContainer.Resolve<IDisplayService>().ShowWindow<MainWindowViewModel>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            // Убиваем листенер перед выходом.
            _unityContainer.Resolve<ISmartReaderListener>().Dispose();
        }

        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            var application = new App();
            //application.InitializeComponent();
            application.Run();
        }
    }
}