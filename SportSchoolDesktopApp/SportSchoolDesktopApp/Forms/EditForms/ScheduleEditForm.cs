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

namespace SportSchoolDesktopApp.Forms.ClassForms
{
    public partial class ScheduleEditForm : Form
    {
        private int CurrentObjectId;
        private int CurrentGroupId;
        private CheckBox[] CheckersArray;

        public ScheduleEditForm(int Id)
        {
            InitializeComponent();
            CheckersArray = new CheckBox[]
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5,
                checkBox6,
                checkBox7,
            };
            CurrentGroupId = -1;
            ReformatForm(Id);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Изменяющиеся методы

        private void ReformatForm(int Id)
        {
            switch (Id)
            {
                case -1:
                    label_FromName.Text = "Новое занятие";
                    button_SaveAdd.Text = "Добавить";
                    button_SaveAdd.Click += AddData;
                    break;
                default:
                    label_FromName.Text = "Редактирование занятия";
                    button_SaveAdd.Text = "Сохранить";
                    button_SaveAdd.Click += UpdateData;
                    button_Delete.Enabled = true;
                    LoadData(Id);
                    break;
            }
        }

        private void CheckNeededCheckers(string val)
        {
            for (int i = 0; i < 7; i++)
                if (val.Contains((i + 1).ToString())) CheckersArray[i].Checked = true;
        }

        private string GetCheckersString()
        {
            string val = "";
            for (int i = 0; i < 7; i++)
                if (CheckersArray[i].Checked) val += (i + 1);
            return val;
        }

        private void LoadData(int Id)
        {
            this.CurrentObjectId = Id;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Schedule CurrentObject = db.Schedule.Find(Id);
                textBox1.Text = CurrentObject.Id.ToString();
                textBox2.Text = $"[ИД {CurrentObject.GroupId}] {CurrentObject.Groups.Name} (Тренер {CurrentObject.Groups.Trainers.LastName})";
                CurrentGroupId = CurrentObject.GroupId;
                CheckNeededCheckers(CurrentObject.Days);
                textBox3.Text = ((int)((double)CurrentObject.TimeStart / 60)).ToString();
                if (textBox3.Text.Length == 1) textBox3.Text = "0" + textBox3.Text;
                textBox4.Text = (CurrentObject.TimeStart % 60).ToString();
                if (textBox4.Text.Length == 1) textBox4.Text = "0" + textBox4.Text;
                textBox5.Text = CurrentObject.Hall.ToString();
                if (CurrentObject.IsPeriodic)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
        }

        private bool CheckAllFields()
        {
            if (CurrentGroupId == -1)
            {
                MessageBox.Show("Не выбрана группа.", "Поле не заполнено!");
                return false;
            }
            if (GetCheckersString().Length == 0)
            {
                MessageBox.Show("Не указаны дни недели.", "Поле не заполнено!");
                return false;
            }

            return true;
        }

        private void AddData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;

            // Добавление занятий

            Schedule newSchedule = new Schedule
            {
                GroupId = CurrentGroupId,
                Days = GetCheckersString(),
                TimeStart = int.Parse(textBox3.Text) * 60 + int.Parse(textBox4.Text),
                Hall = int.Parse(textBox5.Text),
                IsPeriodic = radioButton1.Enabled
            };
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    db.Schedule.Add(newSchedule);
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Занятие не было добавлено.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }

        }

        private void UpdateData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Schedule CurrentObject = db.Schedule.Find(CurrentObjectId);
                    CurrentObject.GroupId = CurrentGroupId;
                    CurrentObject.Days = GetCheckersString();
                    CurrentObject.TimeStart = int.Parse(textBox3.Text) * 60 + int.Parse(textBox4.Text);
                    CurrentObject.Hall = int.Parse(textBox5.Text);
                    CurrentObject.IsPeriodic = radioButton1.Enabled;
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Изменения занятия не были сохранены.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }

        private void onlyNumsChecker(object sender, EventArgs e, int min, int max)
        {
            TextBox tb = (TextBox)sender;
            int num;
            bool isNum = int.TryParse(tb.Text, out num);
            if (!isNum)
            {
                tb.Text = min.ToString();
                if (tb.Text.Length == 1 && tb.MaxLength == 2) tb.Text = "0" + tb.Text;
            }
            else
            {
                if (num < min) tb.Text = min.ToString();
                if (tb.Text.Length == 1 && tb.MaxLength == 2) tb.Text = "0" + tb.Text;
                if (num > max) tb.Text = max.ToString();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            onlyNumsChecker(sender, e, 1, 9999999);
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            onlyNumsChecker(sender, e, 0, 59);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            onlyNumsChecker(sender, e, 0, 23);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectListForm selectGroupForm = new ObjectListForm(SearchForm.GROUPS);
            selectGroupForm.ShowDialog();
            if (selectGroupForm.CheckedId == -1) return;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Groups group = db.Groups.Find(selectGroupForm.CheckedId);
                textBox2.Text = $"(ИД {group.GroupId}) {group.Name}";
                CurrentGroupId = group.GroupId;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Schedule CurrentObject = db.Schedule.Find(CurrentObjectId);
                    db.Schedule.Remove(CurrentObject);
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Не удалось удалить занятие.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }
    }
}
