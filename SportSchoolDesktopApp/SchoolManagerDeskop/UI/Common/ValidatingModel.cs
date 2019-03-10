using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Common
{
    public delegate void ValidateModelHandler();
    public abstract class ValidatingModel : INotifyPropertyChanged, IDisplayableModel, ICloneable
    {
        public abstract string ItemCaption { get; }
        public virtual object Clone() => throw new NotImplementedException();

        public event ValidateModelHandler ModelChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ModelChanged?.Invoke();
        }
    }
}
