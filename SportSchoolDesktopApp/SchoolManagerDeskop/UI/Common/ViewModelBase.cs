using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Common
{
    public interface IViewModel
    {
    }

    public abstract class ViewModelBase : NotifyPropertyChanged, IViewModel
    {
    }

    public interface IDialogViewModel<TArg, TResult> : IViewModel
    {
        TArg DialogArg { get; set; }
        TResult DialogResult { get; }
    }
}
