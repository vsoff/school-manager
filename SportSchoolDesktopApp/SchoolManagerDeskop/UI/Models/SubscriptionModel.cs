using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Models
{
    public class SubscriptionModel : ValidatingModel, IDisplayableModel
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

        private long _groupId;
        public long GroupId
        {
            get { return _groupId; }
            set
            {
                _groupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        private long _studentId;
        public long StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }

        private bool _isUnlimited;
        public bool IsUnlimited
        {
            get { return _isUnlimited; }
            set
            {
                _isUnlimited = value;
                OnPropertyChanged(nameof(IsUnlimited));
                OnPropertyChanged(nameof(SubscriptionTypeCaption));
            }
        }

        private DateTime? _buyTime;
        public DateTime? BuyTime
        {
            get { return _buyTime; }
            set
            {
                _buyTime = value;
                OnPropertyChanged(nameof(BuyTime));
            }
        }

        private DateTime? _dateStart;
        public DateTime? DateStart
        {
            get { return _dateStart; }
            set
            {
                _dateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }

        private DateTime? _dateEnd;
        public DateTime? DateEnd
        {
            get { return _dateEnd; }
            set
            {
                _dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }

        private int? _subHoursMax;
        public int? SubHoursMax
        {
            get { return _subHoursMax; }
            set
            {
                _subHoursMax = value;
                OnPropertyChanged(nameof(SubHoursMax));
            }
        }

        private int _subHoursLeft;
        public int SubHoursLeft
        {
            get { return _subHoursLeft; }
            set
            {
                _subHoursLeft = value;
                OnPropertyChanged(nameof(SubHoursLeft));
            }
        }

        private string _groupCaption;
        public string GroupCaption
        {
            get { return _groupCaption; }
            set
            {
                _groupCaption = value;
                OnPropertyChanged(nameof(GroupCaption));
            }
        }

        private string _trainerCaption;
        public string TrainerCaption
        {
            get { return _trainerCaption; }
            set
            {
                _trainerCaption = value;
                OnPropertyChanged(nameof(TrainerCaption));
            }
        }

        public string SubscriptionTypeCaption => IsUnlimited ? "Безлимитная" : "Лимитированная";
        public override string ItemCaption => $"[{Id}] c {DateStart?.ToShortDateString()} по {DateEnd?.ToShortDateString()} ({GroupCaption})";
    }
}
