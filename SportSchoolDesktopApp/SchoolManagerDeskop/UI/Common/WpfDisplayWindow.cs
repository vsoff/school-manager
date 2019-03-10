using SchoolManagerDeskop.Common.DisplayRegisters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolManagerDeskop.UI.Common
{
    /// <summary>
    /// Обёртка класса Window для реестра окон IDisplayRegistry.
    /// </summary>
    public class WpfDisplayWindow<TWin> : IDisplayWindow where TWin : Window, new()
    {
        /// <summary>
        /// Экземпляр окна.
        /// </summary>
        private readonly TWin _window;

        public WpfDisplayWindow()
        {
            _window = new TWin();
        }

        /// <inheritdoc />
        public IViewModel ViewModel
        {
            get => (IViewModel)_window.DataContext;
            set => _window.DataContext = value;
        }

        /// <inheritdoc />
        public void Show()
        {
            _window.Show();
        }

        /// <inheritdoc />
        public void ShowDialog()
        {
            _window.ShowDialog();
        }

        /// <inheritdoc />
        public void Close()
        {
            _window.Close();
        }
    }
}
