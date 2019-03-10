using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Common
{
    public interface IDialogViewModel<TArg, TResult> : IViewModel
    {
        TArg DialogArg { get; set; }
        TResult DialogResult { get; }
    }
}
