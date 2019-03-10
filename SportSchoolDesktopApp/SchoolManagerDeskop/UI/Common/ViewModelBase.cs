using SchoolManagerDeskop.UI.Common.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagerDeskop.UI.Common
{
    public interface IViewModel
    {
        /// <summary>
        /// Метод, вызывающийся перед открытием ViewModel.
        /// </summary>
        void OnOpen();

        /// <summary>
        /// Метод, вызывающийся после закрытия ViewModel.
        /// </summary>
        void OnClose();
    }

    public abstract class ViewModelBase : NotifyPropertyChanged, IViewModel
    {
        /// <inheritdoc />
        public virtual void OnOpen() { }

        /// <inheritdoc />
        public virtual void OnClose() { }
    }

    public abstract class WindowViewModelBase : ViewModelBase
    {
        public ICommand WindowOpenCommand => new RelayCommand(_ => OnOpen());
        public ICommand WindowCloseCommand => new RelayCommand(_ => OnClose());
    }
}
