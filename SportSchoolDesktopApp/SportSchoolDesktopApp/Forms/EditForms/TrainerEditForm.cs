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
    public partial class TrainerEditForm : Form
    {
        private int CurrentObjectId;

        public TrainerEditForm(int Id)
        {
            InitializeComponent();
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
                    label_FromName.Text = "Новый тренер";
                    button_SaveAdd.Text = "Добавить";
                    button_SaveAdd.Click += AddData;
                    break;
                default:
                    label_FromName.Text = "Редактирование тренера";
                    button_SaveAdd.Text = "Сохранить";
                    button_SaveAdd.Click += UpdateData;
                    LoadData(Id);
                    break;
            }
        }

        private void LoadData(int Id)
        {
            this.CurrentObjectId = Id;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Trainers CurrentObject = db.Trainers.Find(Id);
                textBox1.Text = CurrentObject.TrainerId.ToString();
                textBox2.Text = CurrentObject.LastName;
                textBox3.Text = CurrentObject.FirstName;
                textBox4.Text = CurrentObject.MiddleName;
            }
        }

        private bool CheckAllFields()
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Не указана фамилия тренера.", "Поле не заполнено!");
                return false;
            }
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Не указано имя тренера.", "Поле не заполнено!");
                return false;
            }

            return true;
        }

        private void AddData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            Trainers newTrainer = new Trainers
            {
                LastName = textBox2.Text,
                FirstName = textBox3.Text,
                MiddleName = textBox4.Text
            };
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    db.Trainers.Add(newTrainer);
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Тренер не был добавлен.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }

        private void UpdateData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Trainers CurrentObject = db.Trainers.Find(CurrentObjectId);
                    CurrentObject.LastName = textBox2.Text;
                    CurrentObject.FirstName = textBox3.Text;
                    CurrentObject.MiddleName = textBox4.Text;
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Изменения тренера не были сохранены.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }
    }
}
