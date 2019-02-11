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
        void AddWindowType<TViewModel, TWin, TResult, TParams>();
        void DeleteWindowType<Win>();
        TResult ShowDialog<TArgs, TResult>(IViewModel viewModel, TArgs dialogArgs);
    }

    public class DialogsDisplayRegistry : IDialogsDisplayRegistry
    {
        public void AddWindowType<TViewModel, TWin, TResult, TParams>()
        {
            throw new NotImplementedException();
        }

        public void DeleteWindowType<Win>()
        {
            throw new NotImplementedException();
        }

        public TResult ShowDialog<TArgs, TResult>(IViewModel viewModel, TArgs dialogArgs)
        {
            throw new NotImplementedException();
        }
    }
}
