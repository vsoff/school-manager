using SchoolManagerDeskop.UI.Common;
using SchoolManagerDeskop.UI.Enums;
using SchoolManagerDeskop.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Models
{
    public class ScheduleSubjectModel : ValidatingModel, IDisplayableModel
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

        private WeekDayModel _weekDays;
        public WeekDayModel WeekDays
        {
            get { return _weekDays; }
            set
            {
                _weekDays = value;
                OnPropertyChanged(nameof(WeekDays));
                OnPropertyChanged(nameof(WeekDaysCaption));
            }
        }

        private TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private bool _isPeriodic;
        public bool IsPeriodic
        {
            get { return _isPeriodic; }
            set
            {
                _isPeriodic = value;
                OnPropertyChanged(nameof(IsPeriodic));
            }
        }

        private int _hall;
        public int Hall
        {
            get { return _hall; }
            set
            {
                _hall = value;
                OnPropertyChanged(nameof(Hall));
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

        public string WeekDaysCaption => WeekDayHelper.GetWeekDayCaption(_weekDays);

        public override string ItemCaption => $"[{Id}] {GroupCaption} [{WeekDaysCaption}]";
    }
}
