using SchoolManagerDeskop.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolManagerDeskop.UI.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DaysOfWeekControl.xaml
    /// </summary>
    public partial class DaysOfWeekControl : UserControl
    {
        public DaysOfWeekControl()
        {
            InitializeComponent();
        }

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            DaysOfWeekControl control = obj as DaysOfWeekControl;
            var newTime = (WeekDayModel)e.NewValue;

            control.Monday = newTime.HasFlag(WeekDayModel.Monday);
            control.Tuesday = newTime.HasFlag(WeekDayModel.Tuesday);
            control.Wednesday = newTime.HasFlag(WeekDayModel.Wednesday);
            control.Thursday = newTime.HasFlag(WeekDayModel.Thursday);
            control.Friday = newTime.HasFlag(WeekDayModel.Friday);
            control.Saturday = newTime.HasFlag(WeekDayModel.Saturday);
            control.Sunday = newTime.HasFlag(WeekDayModel.Sunday);
        }

        private static void OnDayOfWeekChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            DaysOfWeekControl control = obj as DaysOfWeekControl;

            WeekDayModel weekDayModel = WeekDayModel.Undefined;
            if (control.Monday) weekDayModel |= WeekDayModel.Monday;
            if (control.Tuesday) weekDayModel |= WeekDayModel.Tuesday;
            if (control.Wednesday) weekDayModel |= WeekDayModel.Wednesday;
            if (control.Thursday) weekDayModel |= WeekDayModel.Thursday;
            if (control.Friday) weekDayModel |= WeekDayModel.Friday;
            if (control.Saturday) weekDayModel |= WeekDayModel.Saturday;
            if (control.Sunday) weekDayModel |= WeekDayModel.Sunday;

            control.Value = weekDayModel;
        }

        #region Properties

        public WeekDayModel Value
        {
            get { return (WeekDayModel)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(WeekDayModel), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(WeekDayModel.Undefined, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged)));

        public bool Monday
        {
            get { return (bool)GetValue(MondayProperty); }
            set { SetValue(MondayProperty, value); }
        }
        public static readonly DependencyProperty MondayProperty =
        DependencyProperty.Register(nameof(Monday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        public bool Tuesday
        {
            get { return (bool)GetValue(TuesdayProperty); }
            set { SetValue(TuesdayProperty, value); }
        }
        public static readonly DependencyProperty TuesdayProperty =
        DependencyProperty.Register(nameof(Tuesday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        public bool Wednesday
        {
            get { return (bool)GetValue(WednesdayProperty); }
            set { SetValue(WednesdayProperty, value); }
        }
        public static readonly DependencyProperty WednesdayProperty =
        DependencyProperty.Register(nameof(Wednesday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        public bool Thursday
        {
            get { return (bool)GetValue(ThursdayProperty); }
            set { SetValue(ThursdayProperty, value); }
        }
        public static readonly DependencyProperty ThursdayProperty =
        DependencyProperty.Register(nameof(Thursday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        public bool Friday
        {
            get { return (bool)GetValue(FridayProperty); }
            set { SetValue(FridayProperty, value); }
        }
        public static readonly DependencyProperty FridayProperty =
        DependencyProperty.Register(nameof(Friday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        public bool Saturday
        {
            get { return (bool)GetValue(SaturdayProperty); }
            set { SetValue(SaturdayProperty, value); }
        }
        public static readonly DependencyProperty SaturdayProperty =
        DependencyProperty.Register(nameof(Saturday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        public bool Sunday
        {
            get { return (bool)GetValue(SundayProperty); }
            set { SetValue(SundayProperty, value); }
        }
        public static readonly DependencyProperty SundayProperty =
        DependencyProperty.Register(nameof(Sunday), typeof(bool), typeof(DaysOfWeekControl),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDayOfWeekChanged)));

        #endregion

        private void ItemChecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
