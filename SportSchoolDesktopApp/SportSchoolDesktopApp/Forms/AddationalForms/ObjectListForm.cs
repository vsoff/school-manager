using SportSchoolDesktopApp.Classes;
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
    public partial class ObjectListForm : Form
    {
        private int FormType;
        public int CheckedId { get; private set; }

        public ObjectListForm(int Type)
        {
            InitializeComponent();
            SetFormType(Type);
            this.CheckedId = -1;
            RefreshResults(false);
        }

        private void SetFormType(int NewType)
        {
            FormType = NewType;

            switch (FormType)
            {
                case SearchForm.TRAINERS:
                    label_FormName.Text = "Выберите тренера";
                    break;
                case SearchForm.GROUPS:
                    label_FormName.Text = "Выберите группу";
                    break;
                case SearchForm.STUDENTS:
                    label_FormName.Text = "Выберите ученика";
                    break;
                default:
                    MessageBox.Show("Не существует такого вида форм!");
                    throw new Exception("Не существует такого вида форм!");
            }
        }

        private int[] FindedIds;

        private void RefreshResults(bool IsFind)
        {
            // Подготавливаемся к обновлению результатов
            button_Choose.Enabled = false;
            int findId = -1;
            string find = textBox_Find.Text;
            if (find == string.Empty)
                IsFind = false;
            else
                int.TryParse(find, out findId);
            CheckedId = -1;
            listBox_Result.Items.Clear();
            // Если это был не поиск то чистим результаты поиска
            textBox_Find.Text = string.Empty;
            // Обрабатываем согласно выбранной форме
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                switch (this.FormType)
                {
                    case SearchForm.TRAINERS:
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
                    case SearchForm.STUDENTS:
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
                    case SearchForm.GROUPS:
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

        private void button_Choose_Click(object sender, EventArgs e)
        {
            if (listBox_Result.SelectedIndex == -1)
            {
                this.CheckedId = -1;
                MessageBox.Show("Ничего не выбрано!");
                return;
            }
            this.CheckedId = FindedIds[listBox_Result.SelectedIndex];
            this.Close();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            RefreshResults(true);
        }

        private void listBox_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_Choose.Enabled = true;
        }
    }
}
