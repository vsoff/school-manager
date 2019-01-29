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
    public partial class GroupsEditForm : Form
    {
        private int CurrentObjectId;
        private int CurrentTrainerId;

        public GroupsEditForm(int Id)
        {
            InitializeComponent();
            CurrentTrainerId = -1;
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
                    label_FromName.Text = "Новая группа";
                    button_SaveAdd.Text = "Добавить";
                    button_SaveAdd.Click += AddData;
                    break;
                default:
                    label_FromName.Text = "Редактирование группы";
                    button_SaveAdd.Text = "Сохранить";
                    button_SaveAdd.Click += UpdateData;
                    LoadData(Id);
                    break;
            }
        }

        private void LoadData(int Id)
        {
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                this.CurrentObjectId = Id;
                Groups CurrentObject = db.Groups.Find(Id);
                textBox1.Text = CurrentObject.GroupId.ToString();
                textBox2.Text = CurrentObject.Name;
                textBox3.Text = CurrentObject.Description;
                textBox4.Text = $"(ИД {CurrentObject.Trainers.TrainerId}) {CurrentObject.Trainers.LastName}";
                CurrentTrainerId = CurrentObject.Trainers.TrainerId;
            }
        }

        private bool CheckAllFields()
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Не указано имя группы.", "Поле не заполнено!");
                return false;
            }
            if (CurrentTrainerId == -1)
            {
                MessageBox.Show("У группы должен быть тренер.", "Поле не заполнено!");
                return false;
            }

            return true;
        }

        private void AddData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            Groups newGroup = new Groups
            {
                Name = textBox2.Text,
                Description = textBox3.Text,
                TrainerId = CurrentTrainerId
            };
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    db.Groups.Add(newGroup);
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Группа не была добавлена.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }

        private void UpdateData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Groups CurrentObject = db.Groups.Find(CurrentObjectId);
                    CurrentObject.Name = textBox2.Text;
                    CurrentObject.Description = textBox3.Text;
                    CurrentObject.TrainerId = CurrentTrainerId;
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Изменения группы не были сохранены.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectListForm selectTrainerForm = new ObjectListForm(SearchForm.TRAINERS);
            selectTrainerForm.ShowDialog();
            if (selectTrainerForm.CheckedId == -1) return;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Trainers trainer = db.Trainers.Find(selectTrainerForm.CheckedId);
                textBox4.Text = $"(ИД {trainer.TrainerId}) {trainer.LastName}";
                CurrentTrainerId = trainer.TrainerId;
            }
        }
    }
}
