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
    public partial class StudentEditForm : Form
    {
        private int CurrentObjectId;

        public StudentEditForm(int Id)
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
                    label_FromName.Text = "Новый ученик";
                    button_SaveAdd.Text = "Добавить";
                    button_SaveAdd.Click += AddData;
                    break;
                default:
                    label_FromName.Text = "Редактирование ученика";
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
                Students CurrentObject = db.Students.Find(Id);
                textBox1.Text = CurrentObject.StudentId.ToString();
                textBox2.Text = CurrentObject.LastName;
                textBox3.Text = CurrentObject.FirstName;
                textBox4.Text = CurrentObject.MiddleName;
                if (CurrentObject.Birdth.HasValue)
                {
                    string[] data = CurrentObject.Birdth.Value.ToShortDateString().Split('.');
                    textBox9.Text = data[0];
                    comboBox2.SelectedIndex = int.Parse(data[1]);
                    textBox5.Text = data[2];
                }
                if (CurrentObject.Phone != "")
                {
                    PhoneNumber pn = new PhoneNumber(CurrentObject.Phone);
                    textBox6.Text = pn.Operator;
                    textBox7.Text = pn.Part1;
                    textBox8.Text = pn.Part2;
                }
            }
        }

        private bool CheckAllFields()
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Не указана фамилия ученика.", "Поле не заполнено!");
                return false;
            }
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Не указано имя ученика.", "Поле не заполнено!");
                return false;
            }
            // Проверка правильности даты рождения
            if (textBox5.Text.Length != 0 || textBox9.Text.Length != 0 || comboBox2.SelectedIndex != -1)
            {
                DateTime dt;
                if (!DateTime.TryParse($"{textBox9.Text}.{comboBox2.SelectedIndex}.{textBox5.Text}", out dt))
                {
                    MessageBox.Show("Поле даты рождения заполнено неверно.", "Поле заполнено неправильно!");
                    return false;
                }
            }
            // Проверка правильности телефонного номера
            if (!PhoneNumber.IsCorrect(textBox6.Text, textBox7.Text, textBox8.Text))
            {
                MessageBox.Show("Поле телефонного номера заполнено неверно.", "Поле заполнено неправильно!");
                return false;
            }
            // Всё прошло проверку
            return true;
        }

        private void AddData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            Students newStudent = new Students
            {
                LastName = textBox2.Text,
                FirstName = textBox3.Text,
                MiddleName = textBox4.Text,
                Birdth = textBox9.Text.Length == 0 ? null : (DateTime?)(DateTime.Parse($"{textBox9.Text}.{comboBox2.SelectedIndex}.{textBox5.Text}")),
                Phone = textBox6.Text.Length == 0 ? "" : (new PhoneNumber(textBox6.Text, textBox7.Text, textBox8.Text)).ToString()
            };
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    db.Students.Add(newStudent);
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Ученик не был добавлен.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }

        private void UpdateData(object sender, EventArgs e)
        {
            if (!CheckAllFields()) return;
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Students CurrentObject = db.Students.Find(CurrentObjectId);
                    CurrentObject.LastName = textBox2.Text;
                    CurrentObject.FirstName = textBox3.Text;
                    CurrentObject.MiddleName = textBox4.Text;
                    CurrentObject.Birdth = textBox9.Text.Length == 0 ? null : (DateTime?)(DateTime.Parse($"{textBox9.Text}.{comboBox2.SelectedIndex}.{textBox5.Text}"));
                    CurrentObject.Phone = textBox6.Text.Length == 0 ? "" : (new PhoneNumber(textBox6.Text, textBox7.Text, textBox8.Text)).ToString();
                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Изменения ученика не были сохранены.\nВозникло исключение: " + ex.Message, "Ошибка!");
            }
        }
    }
}
