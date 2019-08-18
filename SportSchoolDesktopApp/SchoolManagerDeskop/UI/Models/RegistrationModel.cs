using System;
using SchoolManagerDeskop.UI.Common;

namespace SchoolManagerDeskop.UI.Models
{
    public class RegistrationModel : NotifyPropertyChanged
    {
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

        private string _subscriptionActivityText;
        public string SubscriptionActivityText
        {
            get { return _subscriptionActivityText; }
            set
            {
                _subscriptionActivityText = value;
                OnPropertyChanged(nameof(SubscriptionActivityText));
            }
        }

        private string _subscribeButtonText;
        public string SubscribeButtonText
        {
            get { return _subscribeButtonText; }
            set
            {
                _subscribeButtonText = value;
                OnPropertyChanged(nameof(SubscribeButtonText));
            }
        }

        private string _cancelButtonText;
        public string CancelButtonText
        {
            get { return _cancelButtonText; }
            set
            {
                _cancelButtonText = value;
                OnPropertyChanged(nameof(CancelButtonText));
            }
        }

        private bool _isSubscribeButtonActive;
        public bool IsSubscribeButtonActive
        {
            get { return _isSubscribeButtonActive; }
            set
            {
                _isSubscribeButtonActive = value;
                OnPropertyChanged(nameof(IsSubscribeButtonActive));
            }
        }

        private bool _isMessageWithWarning;
        public bool IsMessageWithoutWarning
        {
            get { return _isMessageWithWarning; }
            set
            {
                _isMessageWithWarning = value;
                OnPropertyChanged(nameof(IsMessageWithoutWarning));
            }
        }
    }
}