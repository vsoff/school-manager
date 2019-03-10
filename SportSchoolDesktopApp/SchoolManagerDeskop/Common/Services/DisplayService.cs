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
        TResult ShowDialog<TViewModel, TArg, TResult>(TArg arg = default(TArg)) where TViewModel : IDialogViewModel<TArg, TResult>;
    }

    public class DisplayService : IDisplayService
    {
        private readonly IDialogsDisplayRegistry _dialogsDisplayRegistry;
        private readonly IWindowsDisplayRegistry _windowsDisplayRegistry;
        private readonly IUnityContainer _unityContainer;

        public DisplayService(
             IDialogsDisplayRegistry dialogsDisplayRegistry,
             IWindowsDisplayRegistry windowsDisplayRegistry,
             IUnityContainer unityContainer)
        {
            _dialogsDisplayRegistry = dialogsDisplayRegistry ?? throw new ArgumentNullException(nameof(dialogsDisplayRegistry));
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
            _windowsDisplayRegistry.CloseWindow(viewModel);
        }

        public TResult ShowDialog<TViewModel, TArg, TResult>(TArg arg = default(TArg)) where TViewModel : IDialogViewModel<TArg, TResult>
        {
            TViewModel viewModel = _unityContainer.Resolve<TViewModel>();
            return _dialogsDisplayRegistry.ShowDialog(viewModel, arg);
        }
    }
}
