using SportSchoolDesktopApp.Classes;
using SportSchoolDesktopApp.Forms.ClassForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportSchoolDesktopApp.Forms
{
    public partial class SearchForm : Form
    {
        public const int STUDENTS = 1,
            TRAINERS = 2,
            SCHEDULE = 3,
            GROUPS = 4;


        private int FormType;
        private int[] FindedIds;
        private int CurrentSelectedId;

        public SearchForm(int Type)
        {
            InitializeComponent();
            SetFormType(Type);
            this.CurrentSelectedId = -1;
            RefreshResults(false);
        }

        private void SetFormType(int NewType)
        {
            FormType = NewType;

            switch (FormType)
            {
                case STUDENTS:
                    label_FormName.Text = "Ученики";
                    break;
                case TRAINERS:
                    label_FormName.Text = "Тренеры";
                    break;
                case SCHEDULE:
                    label_FormName.Text = "Занятия";
                    break;
                case GROUPS:
                    label_FormName.Text = "Группы";
                    break;
                default:
                    MessageBox.Show("Не существует такого вида форм!");
                    throw new Exception("Не существует такого вида форм!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddOrEdit(int id)
        {
            switch (FormType)
            {
                case STUDENTS:
                    StudentEditForm form1 = new StudentEditForm(id);
                    form1.ShowDialog();
                    break;
                case TRAINERS:
                    TrainerEditForm form2 = new TrainerEditForm(id);
                    form2.ShowDialog();
                    break;
                case SCHEDULE:
                    ScheduleEditForm form3 = new ScheduleEditForm(id);
                    form3.ShowDialog();
                    break;
                case GROUPS:
                    GroupsEditForm form4 = new GroupsEditForm(id);
                    form4.ShowDialog();
                    break;
            }
            RefreshResults(false);
        }

        private void button_Add_Click(object sender, EventArgs e) { AddOrEdit(-1); }

        private void button_Edit_Click(object sender, EventArgs e) { AddOrEdit(CurrentSelectedId); }

        private void listBox_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Result.SelectedIndex == -1)
            {
                button_Edit.Enabled = false;
                return;
            }
            button_Edit.Enabled = true;
            CurrentSelectedId = FindedIds[listBox_Result.SelectedIndex];
        }

        private void RefreshResults(bool IsFind)
        {
            // Подготавливаемся к обновлению результатов
            button_Edit.Enabled = false;
            int findId = -1;
            string find = textBox_Find.Text;
            if (find == string.Empty)
                IsFind = false;
            else
                int.TryParse(find, out findId);
            CurrentSelectedId = -1;
            listBox_Result.Items.Clear();
            // Если это был не поиск то чистим результаты поиска
            textBox_Find.Text = string.Empty;
            // Обрабатываем согласно выбранной форме
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                switch (this.FormType)
                {
                    case STUDENTS:
                        List<Students> students;
                        if (IsFind)
                            students = db.Students.Where(x => x.StudentId == findId || x.FirstName.Contains(find) || x.MiddleName.Contains(find) || x.LastName.Contains(find)).ToList();
                        else
                            students = db.Students.Select(x => x).ToList();
                        FindedIds = new int[students.Count];
                        FindedIds = students.Select(x => x.StudentId).ToArray();
                        foreach (var item in students)
                            listBox_Result.Items.Add($"[ИД {item.StudentId}] {item.LastName} {item.MiddleName} {item.FirstName}");
                        break;
                    case TRAINERS:
                        List<Trainers> trainers;
                        if (IsFind)
                            trainers = db.Trainers.Where(x => x.TrainerId == findId || x.FirstName.Contains(find) || x.MiddleName.Contains(find) || x.LastName.Contains(find)).ToList();
                        else
                            trainers = db.Trainers.Select(x => x).ToList();
                        FindedIds = new int[trainers.Count];
                        FindedIds = trainers.Select(x => x.TrainerId).ToArray();
                        foreach (var item in trainers)
                            listBox_Result.Items.Add($"[ИД {item.TrainerId}] {item.LastName} {item.MiddleName} {item.FirstName}");
                        break;
                    case SCHEDULE:
                        List<Schedule> schedule;
                        if (IsFind)
                            schedule = db.Schedule.Where(x => x.Id == findId || x.Groups.Name.Contains(find) || x.Groups.Trainers.LastName.Contains(find)).ToList();
                        else
                            schedule = db.Schedule.Select(x => x).ToList();
                        FindedIds = new int[schedule.Count];
                        FindedIds = schedule.Select(x => x.Id).ToArray();
                        foreach (var item in schedule)
                            listBox_Result.Items.Add($"[ИД {item.Id}] {item.Groups.Name} (Зал №{item.Hall}, {GetNameDayOfWeek(item.Days)})");
                        break;
                    case GROUPS:
                        List<Groups> groups;
                        if (IsFind)
                            groups = db.Groups.Where(x => x.GroupId == findId || x.Name.Contains(find) || x.Trainers.LastName.Contains(find)).ToList();
                        else
                            groups = db.Groups.Select(x => x).ToList();
                        FindedIds = new int[groups.Count];
                        FindedIds = groups.Select(x => x.GroupId).ToArray();
                        foreach (var item in groups)
                            listBox_Result.Items.Add($"[ИД {item.GroupId}] {item.Name} (Тренер {item.Trainers.LastName})");
                        break;
                }
            }
        }

        public string GetNameDayOfWeek(string days)
        {
            List<string> allDays = new List<string>();
            if (days.Length == 0) throw new Exception("Не указано ни одного дня для занятия!");
            string[] dayz = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
            for (int i = 0; i < dayz.Length; i++)
                if (days.Contains((i + 1).ToString())) allDays.Add(dayz[i]);
            return String.Join(",", allDays);
        }

        private void button_Find_Click(object sender, EventArgs e) { RefreshResults(true); }
    }
}
