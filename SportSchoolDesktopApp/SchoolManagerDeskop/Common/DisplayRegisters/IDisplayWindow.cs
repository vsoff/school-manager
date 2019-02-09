using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.DisplayRegisters
{
    public interface IDisplayWindow
    {
        /// <summary>
        /// ViewModel окна.
        /// </summary>
        /// <remarks>Покрывает DataContext в классе Window.</remarks>
        ViewModelBase ViewModel { get; set; }

        /// <summary>
        /// Открывает окно.
        /// </summary>
        void Show();

        /// <summary>
        /// Закрывает окно.
        /// </summary>
        void Close();
    }
}
