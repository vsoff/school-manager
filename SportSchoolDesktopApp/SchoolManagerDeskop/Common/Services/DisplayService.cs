using SchoolManagerDeskop.Common.DisplayRegisters;
using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SchoolManagerDeskop.Common.Services
{
    public interface IDisplayService
    {
        TViewModel ShowWindow<TViewModel>() where TViewModel : IViewModel;
        void ShowDialog<TViewModel>() where TViewModel : IViewModel;
        void CloseWindow<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel;
    }

    public class DisplayService : IDisplayService
    {
        private readonly IWindowsDisplayRegistry _windowsDisplayRegistry;
        private readonly IUnityContainer _unityContainer;

        public DisplayService(
             IWindowsDisplayRegistry windowsDisplayRegistry,
             IUnityContainer unityContainer)
        {
            _windowsDisplayRegistry = windowsDisplayRegistry ?? throw new ArgumentNullException(nameof(windowsDisplayRegistry));
            _unityContainer = unityContainer ?? throw new ArgumentNullException(nameof(unityContainer));
        }

        public TViewModel ShowWindow<TViewModel>() where TViewModel : IViewModel
        {
            TViewModel viewModel = _unityContainer.Resolve<TViewModel>();
            _windowsDisplayRegistry.ShowWindow(viewModel);
            return viewModel;
        }

        public void ShowDialog<TViewModel>() where TViewModel : IViewModel
        {
            TViewModel viewModel = _unityContainer.Resolve<TViewModel>();
            _windowsDisplayRegistry.ShowDialog(viewModel);
        }

        public void CloseWindow<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            _windowsDisplayRegistry.ShowDialog(viewModel);
        }
    }
}
