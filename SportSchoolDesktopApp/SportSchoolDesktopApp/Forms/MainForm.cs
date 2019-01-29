using SportSchoolDesktopApp.Classes;
using SportSchoolDesktopApp.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SportSchoolDesktopApp
{
    public partial class MainForm : Form
    {
        private bool IsNeedCloseApp = false;

        public MainForm()
        {
            InitializeComponent();
            if (!SportProgramSettings.Initialization())
            {
                MessageBox.Show("Инициализация прошла НЕУСПЕШНО. Приложение будет выключено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsNeedCloseApp = true;
                return;
            }
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                bool IsBaseExists = db.Database.Exists();
                if (!IsBaseExists)
                {
                    MessageBox.Show("Проблемы с базой данных, нет подключения, либо самой базы данных. Приложение будет выключено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    IsNeedCloseApp = true;
                    return;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (IsNeedCloseApp) Application.Exit();
        }

        //private void testSendEmail()
        //{
        //    // http://smsc.ru/api/http/send/email/ sms sending
        //    using (var web = new WebClient())
        //    {
        //        var pars = new NameValueCollection
        //                {
        //                    { "login", "login" },
        //                    { "psw", "password" },
        //                    { "phones", "email" },
        //                    { "mes", "message" },
        //                    { "subj", "subject" },
        //                    { "sender", "ara@ara.ru" },
        //                    { "mail", "1" }
        //                };
        //        web.UploadValues(@"http://smsc.ru/sys/send.php", pars);
        //    }
        //}

        private void buttonStudents_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(SearchForm.STUDENTS);
            sf.ShowDialog();
        }

        private void buttonTrainers_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(SearchForm.TRAINERS);
            sf.ShowDialog();
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(SearchForm.SCHEDULE);
            sf.ShowDialog();
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm(SearchForm.GROUPS);
            sf.ShowDialog();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm();
            rf.ShowDialog();
        }

        private void buttonSubscription_Click(object sender, EventArgs e)
        {
            SubscribeForm sf = new SubscribeForm();
            sf.ShowDialog();
        }

        private void comboBox_WeekDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            coloringWDay = comboBox_WeekDay.SelectedIndex;
            RefreshSchedule(comboBox_WeekDay.SelectedIndex + 1);
        }
        List<LocalSchedule> CurrentSchedule;
        private void RefreshScheduleCounters()
        {
            for (int i = 0; i < CurrentSchedule.Count; i++)
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Sessions session = db.Sessions.Find(CurrentSchedule[i].SessionId);
                    grid_Schedule.Rows[i].Cells[3].Value = session.StudentsInSessions.Count;
                }
            }
        }
        private void RefreshSchedule(int weekDay)
        {
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                var schedule = db.Schedule.Where(x => x.Days.Contains(weekDay.ToString())).OrderBy(x => x.TimeStart).ToList();
                CurrentSchedule = new List<LocalSchedule>();
                foreach (var item in schedule)
                {
                    int sessionId = CalcSessionId(item.TimeStart, item.GroupId);
                    if (sessionId == -1)
                    {
                        MessageBox.Show("Приложение будет закрыто");
                        Environment.Exit(Environment.ExitCode);
                    }
                    CurrentSchedule.Add(new LocalSchedule
                    {
                        GroupId = item.GroupId,
                        TimeStart = item.TimeStart,
                        Caption = item.Groups.Name + " (" + item.Groups.Trainers.LastName + ")",
                        Hall = item.Hall,
                        SessionId = sessionId,
                        Count = 0
                    });
                }

                grid_Schedule.Rows.Clear();
                foreach (var item in CurrentSchedule)
                {
                    grid_Schedule.Rows.Add(item.GetTimeStart(), item.Caption, item.Hall, item.Count, "Открыть...");
                }
                ActualizeShedule();
            }
            grid_Schedule.ClearSelection();
        }

        private int coloringWDay = -1;
        private void ActualizeShedule()
        {
            if (CurrentSchedule == null || coloringWDay == -1) return;
            DateTime dt = DateTime.Now;
            int CurTime = dt.Hour * 60 + dt.Minute;
            int currentWDay = ((int)dt.DayOfWeek + 6) % 7;
            if (coloringWDay == currentWDay)
            {
                for (int i = 0; i < CurrentSchedule.Count; i++)
                {
                    Color color;
                    if (CurTime >= CurrentSchedule[i].TimeStart && CurTime < CurrentSchedule[i].TimeStart + SportProgramSettings.SessionDurationMin)
                        color = Color.Yellow;
                    else if (CurTime < CurrentSchedule[i].TimeStart)
                        color = Color.LightGreen;
                    else color = Color.Red;
                    grid_Schedule.Rows[i].Cells[1].Style.BackColor = color;
                }
            }
            else
            {
                for (int i = 0; i < CurrentSchedule.Count; i++)
                    grid_Schedule.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
            }
            RefreshScheduleCounters();
        }

        private DateTime GetScheduleDate()
        {
            DateTime dt = DateTime.Now.Date;
            int currentDay = dt.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)dt.DayOfWeek;
            int choosenDay = (comboBox_WeekDay.SelectedIndex + 1);
            int delta = choosenDay - currentDay;
            if (delta > 0)
                dt = dt.AddDays(delta);
            else if (delta < 0)
                dt = dt.AddDays(7 + delta);
            return dt;
        }

        private void grid_Schedule_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Чистим селект (beauty)
            grid_Schedule.ClearSelection();
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            // Если мы кликнули на открытие формы регистрации
            if (e.ColumnIndex == 4 && e.Button == MouseButtons.Left)
            {
                //int currentSessionId = GetCurrentSessionId(e.RowIndex);
                // Инициализиуем окно регистрации по полученной сессии и отображаем его
                RegisterForm rf = new RegisterForm(CurrentSchedule[e.RowIndex].SessionId);
                rf.ShowDialog();
                // Делаем рефреш после возможных изменений
                ActualizeShedule();
            }
        }

        private int CalcSessionId(int TimeStart, int GroupId)
        {
            // Создаём объекты времени для поиска сессии
            DateTime dt = GetScheduleDate();
            TimeSpan ts = new TimeSpan(
                (int)((double)(TimeStart) / 60),
                (TimeStart) % 60,
                0);
            // Ищем текущую сессию. Если она не найдена, то создаём свою
            int currentSessionId;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                // Ищем сессию
                var grId = GroupId;
                Sessions currentSession = db.Sessions.Where(x => x.Date == dt && x.Time == ts && x.GroupId == grId).FirstOrDefault();
                // Не найдена? Значит создаём новую
                if (currentSession == null)
                {
                    Sessions newSession = new Sessions
                    {
                        Date = dt,
                        Time = ts,
                        GroupId = GroupId
                    };
                    // Добавляем в бд
                    db.Sessions.Add(newSession);
                    db.SaveChanges();
                    // Ищем её в БД
                    currentSession = db.Sessions.Where(x => x.Date == dt && x.Time == ts && x.GroupId == grId).FirstOrDefault();
                    // Снова не найдена? Тогда произошла ошибка
                    if (currentSession == null)
                    {
                        MessageBox.Show("Критическая ошибка. Сессия не была добавлена после того, как была предпринята попытка ее добавить.");
                        return -1;
                    }
                }
                currentSessionId = currentSession.SessionId;
            }
            return currentSessionId;
        }
        /*
        private int GetCurrentSessionId(int index)
        {
            // Создаём объекты времени для поиска сессии
            DateTime dt = GetScheduleDate();
            TimeSpan ts = new TimeSpan(
                (int)((double)(CurrentSchedule[index].TimeStart) / 60),
                (CurrentSchedule[index].TimeStart) % 60,
                0);
            // Ищем текущую сессию. Если она не найдена, то создаём свою
            int currentSessionId;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                // Ищем сессию
                var grId = CurrentSchedule[index].GroupId;
                Sessions currentSession = db.Sessions.Where(x => x.Date == dt && x.Time == ts && x.GroupId == grId).FirstOrDefault();
                // Не найдена? Значит создаём новую
                if (currentSession == null)
                {
                    Sessions newSession = new Sessions
                    {
                        Date = dt,
                        Time = ts,
                        GroupId = CurrentSchedule[index].GroupId
                    };
                    // Добавляем в бд
                    db.Sessions.Add(newSession);
                    db.SaveChanges();
                    // Ищем её в БД
                    currentSession = db.Sessions.Where(x => x.Date == dt && x.Time == ts && x.GroupId == grId).FirstOrDefault();
                    // Снова не найдена? Тогда произошла ошибка
                    if (currentSession == null)
                    {
                        MessageBox.Show("Критическая ошибка. Сессия не была добавлена после того, как была предпринята попытка ее добавить.");
                        return -1;
                    }
                }
                currentSessionId = currentSession.SessionId;
            }
            return currentSessionId;
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            ActualizeShedule();
            //label1.Text = DateTime.Now.ToString();
        }

        private void cardEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CardEditor ce = new CardEditor();
            ce.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshSchedule(comboBox_WeekDay.SelectedIndex + 1);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime updateAppTime = DateTime.Parse("2018.12.14");
            string text = $"Дата сборки: {updateAppTime.Date.ToLongDateString()}\nВерсия программы: {Assembly.GetExecutingAssembly().GetName().Version}";
            MessageBox.Show(text, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
