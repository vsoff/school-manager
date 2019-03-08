using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.DisplayRegisters
{
    public interface IDialogsDisplayRegistry : IDiplayRegistry
    {
        void AddWindowType<TViewModel, TWin, TArg, TResult>()
            where TWin : IDisplayWindow,
            new() where TViewModel : IDialogViewModel<TArg, TResult>;
        void DeleteWindowType<TViewModel, TArg, TResult>()
            where TViewModel : IDialogViewModel<TArg, TResult>;
        TResult ShowDialog<TArg, TResult>(IDialogViewModel<TArg, TResult> viewModel, TArg dialogArgs = default(TArg));

        /// <summary>
        /// Закрывает окно для переданного объекта ViewModel.
        /// </summary>
        /// <param name="viewModel">ViewModel окна.</param>
        void CloseDialog(IViewModel viewModel);
    }

    public class DialogsDisplayRegistry : IDialogsDisplayRegistry
    {
        /// <summary>
        /// Карта открытых окон.
        /// </summary>
        private readonly Dictionary<IViewModel, IDisplayWindow> _openedWindowsMap;

        /// <summary>
        /// Карта зарегистрированных диалоговых окон.
        /// </summary>
        private readonly Dictionary<Type, Type> _registeredWindowsMap;

        public DialogsDisplayRegistry()
        {
            _registeredWindowsMap = new Dictionary<Type, Type>();
            _openedWindowsMap = new Dictionary<IViewModel, IDisplayWindow>();
        }

        public void AddWindowType<TViewModel, TWin, TArg, TResult>()
            where TWin : IDisplayWindow,
            new() where TViewModel : IDialogViewModel<TArg, TResult>
        {
            Type vmType = typeof(TViewModel);

            if (vmType.IsInterface)
                throw new ArgumentException("Реестр не работает с интерфейсами");

            if (_registeredWindowsMap.ContainsKey(vmType))
                throw new InvalidOperationException($"Тип {vmType.FullName} уже находится в реестре");

            _registeredWindowsMap[vmType] = typeof(TWin);
        }

        public void DeleteWindowType<TViewModel, TArg, TResult>()
            where TViewModel : IDialogViewModel<TArg, TResult>
        {
            Type vmType = typeof(TViewModel);

            if (vmType.IsInterface)
                throw new ArgumentException("Реестр не работает с интерфейсами");

            if (!_registeredWindowsMap.ContainsKey(vmType))
                throw new InvalidOperationException($"Тип {vmType.FullName} не зарегистрирован в реестре");

            _registeredWindowsMap.Remove(vmType);
        }

        public TResult ShowDialog<TArg, TResult>(IDialogViewModel<TArg, TResult> viewModel, TArg dialogArg = default(TArg))
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            IDisplayWindow window = CreateWindowInstance(viewModel);
            _openedWindowsMap[viewModel] = window;

            // Передаём аргумент во viewModel.
            viewModel.DialogArg = dialogArg;

            // Выводим диалоговое окно.
            window.ShowDialog();
            if (_openedWindowsMap.ContainsKey(viewModel))
                _openedWindowsMap.Remove(viewModel);

            // Возвращаем результат.
            return viewModel.DialogResult;
        }

        /// <inheritdoc />
        public void CloseDialog(IViewModel viewModel)
        {
            IDisplayWindow window;
            if (!_openedWindowsMap.TryGetValue(viewModel, out window))
                throw new InvalidOperationException("Диалоговое окно для этой ViewModel ещё не открыто");

            window.Close();
            _openedWindowsMap.Remove(viewModel);
        }

        /// <summary>
        /// Создаёт инстанс окна.
        /// </summary>
        /// <param name="viewModel">ViewModel окна.</param>
        /// <returns>Окно.</returns>
        private IDisplayWindow CreateWindowInstance(IViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            Type viewModelType = viewModel.GetType();
            Type displayWindowType = null;

            while (viewModelType != null && !_registeredWindowsMap.TryGetValue(viewModelType, out displayWindowType))
                viewModelType = viewModelType.BaseType;

            if (displayWindowType == null)
                throw new ArgumentException($"В реестре не зарегистировано окно для ViewModel типа {viewModel.GetType().FullName}");

            var window = (IDisplayWindow)Activator.CreateInstance(displayWindowType);
            window.ViewModel = viewModel;

            return window;
        }
    }
}
