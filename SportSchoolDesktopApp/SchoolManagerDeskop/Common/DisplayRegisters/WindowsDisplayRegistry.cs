using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.DisplayRegisters
{
    public interface IWindowsDisplayRegistry : IDiplayRegistry
    {
        /// <summary>
        /// Добавляет регистрацию связи окна и ViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">Тип ViewModel.</typeparam>
        /// <typeparam name="TWin">Тип окна.</typeparam>
        void AddWindowType<TViewModel, TWin>() where TWin : IDisplayWindow, new() where TViewModel : IViewModel;

        /// <summary>
        /// Удаляет регистрацию ViewModel.
        /// </summary>
        /// <typeparam name="TViewModel">Тип ViewModel.</typeparam>
        void DeleteWindowType<TViewModel>() where TViewModel : IViewModel;

        /// <summary>
        /// Открывает окно для переданного объекта ViewModel.
        /// </summary>
        /// <param name="viewModel">ViewModel окна.</param>
        /// <param name="isDialog">Указывает нужно ли открыть окно как диалог.</param>
        void ShowWindow(IViewModel viewModel, bool isDialog = false);

        /// <summary>
        /// Закрывает окно для переданного объекта ViewModel.
        /// </summary>
        /// <param name="viewModel">ViewModel окна.</param>
        void CloseWindow(IViewModel viewModel);
    }

    public class WindowsDisplayRegistry : IWindowsDisplayRegistry
    {
        /// <summary>
        /// Карта открытых окон.
        /// </summary>
        private readonly Dictionary<IViewModel, IDisplayWindow> _openedWindowsMap;

        /// <summary>
        /// Карта зарегистрированных окон.
        /// </summary>
        private readonly Dictionary<Type, Type> _registeredWindowsMap;

        public WindowsDisplayRegistry()
        {
            _registeredWindowsMap = new Dictionary<Type, Type>();
            _openedWindowsMap = new Dictionary<IViewModel, IDisplayWindow>();
        }

        /// <inheritdoc />
        public void AddWindowType<TViewModel, TWin>() where TWin : IDisplayWindow, new() where TViewModel : IViewModel
        {
            Type vmType = typeof(TViewModel);

            if (vmType.IsInterface)
                throw new ArgumentException("Реестр не работает с интерфейсами");

            if (_registeredWindowsMap.ContainsKey(vmType))
                throw new InvalidOperationException($"Тип {vmType.FullName} уже находится в реестре");

            _registeredWindowsMap[vmType] = typeof(TWin);
        }

        /// <inheritdoc />
        public void DeleteWindowType<TViewModel>() where TViewModel : IViewModel
        {
            Type vmType = typeof(TViewModel);

            if (vmType.IsInterface)
                throw new ArgumentException("Реестр не работает с интерфейсами");

            if (!_registeredWindowsMap.ContainsKey(vmType))
                throw new InvalidOperationException($"Тип {vmType.FullName} не зарегистрирован в реестре");

            _registeredWindowsMap.Remove(vmType);
        }

        /// <inheritdoc />
        public void ShowWindow(IViewModel viewModel, bool isDialog = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (_openedWindowsMap.ContainsKey(viewModel))
                throw new InvalidOperationException("Окно для этой ViewModel уже открыто");

            IDisplayWindow window = CreateWindowInstance(viewModel);
            _openedWindowsMap[viewModel] = window;

            if (isDialog)
                window.ShowDialog();
            else
                window.Show();
        }

        /// <inheritdoc />
        public void CloseWindow(IViewModel viewModel)
        {
            IDisplayWindow window;
            if (!_openedWindowsMap.TryGetValue(viewModel, out window))
                throw new InvalidOperationException("Окно для этой ViewModel ещё не открыто");

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
