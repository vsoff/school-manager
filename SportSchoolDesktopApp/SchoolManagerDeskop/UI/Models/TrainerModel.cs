using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Models
{
    public class TrainerModel : ValidatingModel, IDisplayableModel
    {
        private long _id;
        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ItemCaption => $"[{Id}] {FullName}";
    }
}
