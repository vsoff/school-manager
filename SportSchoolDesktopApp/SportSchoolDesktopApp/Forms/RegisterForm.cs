using SportSchoolDesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestSmartcard;

namespace SportSchoolDesktopApp.Forms
{
    public partial class RegisterForm : Form
    {
        private const int
            NONSELECTED = 0,
            NOSUBINPERIOD = 1,
            WRONGGROUP = 2,
            UNLIMITED = 3,
            RIGHTGROUP = 4,
            HOURSLEFT = 5,
            SOLATE = 6;

        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        private int CurrentSessionId { get; }
        private int CurrentStudentId { get; set; }
        private Subscriptions CurrentSubscription { get; set; }
        private Sessions CurrentSession { get; set; }
        SmartReaderController SmartReader;

        public RegisterForm(int currentSessionId)
        {
            InitializeComponent();
            CurrentSessionId = currentSessionId;
            FillAll();

            SmartReader = new SmartReaderController(SmartReaderType.Reader, UpdateUI);
        }

        private void FillAll()
        {
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                CurrentSession = db.Sessions.Find(CurrentSessionId);
                groupBox_Session.Text = $"Занятие (Ид {CurrentSessionId})";
                label_FromName.Text = $"Форма регистрации на занятие «{CurrentSession.Groups.Name}»";
                Trainers train = CurrentSession.Groups.Trainers;
                label_SessionTrainer.Text = $"{train.FirstName} {train.MiddleName} {train.LastName}";
                label_SessionGroup.Text = CurrentSession.Groups.Name;
                label_SessionTime.Text = $"{CurrentSession.Date.ToShortDateString()} {CurrentSession.Time}";
            }
            RefreshSISList();
        }

        private void button_Action_Click(object sender, EventArgs e)
        {
            if (CurrentStudentId == -1 || CurrentSessionId == -1) return;
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    // Получаем объект абонемента
                    Subscriptions sub = db.Subscriptions.Find(CurrentSubscription.SubscriptionId);
                    CurrentSubscription = sub;
                    // Регистрация и удаление с сессии
                    StudentsInSessions presence = db.StudentsInSessions.Where(x => x.StudentId == CurrentStudentId && x.SessionId == CurrentSessionId).FirstOrDefault();
                    if (presence == null)
                    {
                        if (sub.SubHoursLeft == 0)
                        {
                            MessageBox.Show("У ученика закончились часы посещения");
                            return;
                        }
                        db.StudentsInSessions.Add(new StudentsInSessions
                        {
                            SessionId = CurrentSessionId,
                            StudentId = CurrentStudentId
                        }
                        );
                        sub.SubHoursLeft--;
                        button_Action.Text = LABEL_UNREG;
                    }
                    else
                    {
                        db.StudentsInSessions.Remove(presence);
                        sub.SubHoursLeft++;
                        button_Action.Text = LABEL_REG;
                    }
                    db.SaveChanges();

                    UpdateVisitsInfo(sub.SubHoursLeft, sub.SubHoursMax);
                }
                RefreshSISList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при регистрации ученика на занятие.\n\nError: " + ex);
            }
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SmartReader.DestroyObject();
        }

        private const string LABEL_REG = "Зарегистрировать ученика",
            LABEL_UNREG = "Убрать отметку регистрации";

        private void RefreshSISList()
        {
            listBox_Students.Items.Clear();
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                var students = db.StudentsInSessions.Where(x => x.SessionId == CurrentSessionId).Join(db.Students, // второй набор
                    p => p.StudentId, // свойство-селектор объекта из первого набора
                    c => c.StudentId, // свойство-селектор объекта из второго набора
                    (p, c) => new // результат
                    {
                        c.StudentId,
                        c.LastName,
                        c.FirstName,
                        c.MiddleName,
                    }).ToList();
                //List<Students> students = db.Students.SqlQuery($"SELECT * FROM Students WHERE StudentId IN (SELECT * FROM StudentsInSessions WHERE SessionId = {CurrentSessionId})").ToList();

                foreach (var s in students)
                    listBox_Students.Items.Add($"[Ид {s.StudentId}] {s.LastName} {s.FirstName} {s.MiddleName}");
            }
        }

        public void UpdateUI(int value)
        {
            if (value == -1)
            {
                MessageBox.Show("Ошибка контакта с картой. Попробуйте снова.");
                return;
            }

            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                SetCurrentStudent((int)o);
            }), value);
        }

        private void SetCurrentStudent(int studentId)
        {
            try
            {
                CurrentStudentId = studentId;
                CurrentSubscription = null;
                if (CurrentStudentId == 0)
                {
                    label_StudentFullName.Text = string.Empty;
                    label_StudentId.Text = string.Empty;
                    label_StudentSubShort.Text = string.Empty;
                    button_Action.Enabled = false;
                    MessageBox.Show("Эта карта не привязана ни к одному ученику.");
                    return;
                }
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Students student = db.Students.Find(CurrentStudentId);
                    label_StudentId.Text = student.StudentId.ToString();
                    label_StudentFullName.Text = $"{student.FirstName} {student.MiddleName} {student.LastName}";
                    // Узнаём состояние регистрации ученика на данную пару
                    DateTime curTime = DateTime.Now;
                    List<Subscriptions> subs = db.Subscriptions.Where(
                        x => x.StudentId == CurrentStudentId //&& x.GroupId == CurrentSession.GroupId
                        && x.DateStart <= curTime && x.DateEnd >= curTime
                    ).ToList();

                    // Проверяем валидацию ученика
                    Subscriptions localCurrentSub = null;
                    bool isSubscribeWorks;
                    string response;
                    ValidateStudentAction(db, subs, out localCurrentSub, out isSubscribeWorks, out response);
                    CurrentSubscription = localCurrentSub;


                    if (isSubscribeWorks)
                    {
                        // Проверка на то, отмечен ли уже ученик
                        bool isIn = db.StudentsInSessions.Where(x => x.StudentId == CurrentStudentId && x.SessionId == CurrentSessionId).FirstOrDefault() != null;
                        if (isIn)
                            button_Action.Text = LABEL_UNREG;
                        else
                            button_Action.Text = LABEL_REG;
                        button_Action.Enabled = true;
                        // Вывод причины
                        label_StudentSubShort.ForeColor = Color.Green;
                        label_StudentSubShort.Text = $"Регистрация возможна.\n({response})";
                    }
                    else
                    {
                        button_Action.Text = LABEL_REG;
                        button_Action.Enabled = false;
                        // Вывод причины
                        label_StudentSubShort.ForeColor = Color.Red;
                        label_StudentSubShort.Text = $"Регистрация невозможна!\n\nПричина:\n{response}";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выборе ученика. Exception: " + ex);
            }
        }
        // [{visitsLeft}/{visitsMax}]
        private void UpdateVisitsInfo(int? visitsLeft, int? visitsMax)
        {
            if (visitsLeft == 0 && (visitsMax == 0 || visitsMax == null))
                label_VisitsInfo.Text = "";
            else
                label_VisitsInfo.Text = $"{visitsLeft} из {visitsMax}";
        }

        private void ValidateStudentAction(SportEntities db, List<Subscriptions> subs, out Subscriptions CurrentSubscription, out bool isSubscribeWorks, out string response)
        {
            DateTime curTime = DateTime.Now;
            CurrentSubscription = null;

            int? visitsMax = 0, visitsLeft = 0;

            int subscribeStatus = RegisterForm.NONSELECTED;
            // Есть ли вообще подписки?
            if (subs.Count == 0)
                subscribeStatus = RegisterForm.NOSUBINPERIOD;
            // Ученик опоздал?
            else if (CurrentSession.Date == DateTime.Now.Date && CurrentSession.Time < DateTime.Now.AddMinutes(-SportProgramSettings.StudentCanLateMin).TimeOfDay)
                subscribeStatus = RegisterForm.SOLATE;
            // Карта безлимитная?
            else if (subs.Where(x => x.IsUnlimited && x.SubHoursLeft > 0).FirstOrDefault() != null)
            {
                CurrentSubscription = subs.Where(x => x.IsUnlimited && x.SubHoursLeft > 0).FirstOrDefault();
                visitsLeft = CurrentSubscription.SubHoursLeft;
                visitsMax = CurrentSubscription.SubHoursMax;
                subscribeStatus = RegisterForm.UNLIMITED;
            }
            // Группа правильная?
            else if (subs.Where(x => x.GroupId == CurrentSession.GroupId).FirstOrDefault() == null)
                subscribeStatus = RegisterForm.WRONGGROUP;
            // Не кончилось ли кол-во посещений? (и не подписан)
            else if (subs.Where(x => x.GroupId == CurrentSession.GroupId && x.SubHoursLeft > 0).FirstOrDefault() == null
                && db.StudentsInSessions.Where(x => x.SessionId == CurrentSession.SessionId && x.StudentId == CurrentStudentId).FirstOrDefault() == null)
                subscribeStatus = RegisterForm.HOURSLEFT;
            // Значит группа правильная
            else
            {
                CurrentSubscription = subs.Where(x => x.GroupId == CurrentSession.GroupId && x.SubHoursLeft > 0).First();
                visitsLeft = CurrentSubscription.SubHoursLeft;
                visitsMax = CurrentSubscription.SubHoursMax;
                subscribeStatus = RegisterForm.RIGHTGROUP;
            }

            isSubscribeWorks = false;
            response = "";

            switch (subscribeStatus)
            {
                case RegisterForm.NOSUBINPERIOD:
                    isSubscribeWorks = false;
                    response = "У ученика нету действующих абонементов на данный период.";
                    break;
                case RegisterForm.UNLIMITED:
                    isSubscribeWorks = true;
                    response = "Безлимитный абонемент";
                    break;
                case RegisterForm.WRONGGROUP:
                    isSubscribeWorks = false;
                    response = "У ученика нету абонемента на эту группу.";
                    break;
                case RegisterForm.RIGHTGROUP:
                    isSubscribeWorks = true;
                    response = "Лимитированный абонемент";
                    break;
                case RegisterForm.HOURSLEFT:
                    isSubscribeWorks = false;
                    response = "У ученика кончилось количество посещений.";
                    break;
                case RegisterForm.SOLATE:
                    isSubscribeWorks = false;
                    response = "Регистрация на занятие уже закрыта.";
                    break;
                default: throw new Exception("Несуществующий тип подписки.");
            }

            UpdateVisitsInfo(visitsLeft, visitsMax);
        }

        private void button_ChooseStudent_Click(object sender, EventArgs e)
        {
            ObjectListForm olf = new ObjectListForm(SearchForm.STUDENTS);
            olf.ShowDialog();
            if (olf.CheckedId == -1) return;
            SetCurrentStudent(olf.CheckedId);
        }
    }
}
