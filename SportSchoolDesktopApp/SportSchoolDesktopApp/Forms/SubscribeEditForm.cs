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
    public partial class SubscribeEditForm : Form
    {
        private int CurrentSubscribeId = -1;
        private int CurrentStudentId = -1;
        private int CurrentGroupId = -1;
        private int[] Years;

        public SubscribeEditForm(int CurrentStudentId, int CurrentSubscribeId)
        {
            InitializeComponent();
            Years = new int[] { DateTime.Now.Year, DateTime.Now.Year + 1 };
            this.CurrentStudentId = CurrentStudentId;
            this.CurrentSubscribeId = CurrentSubscribeId;
            PrepareForm();
            LoadData(CurrentSubscribeId);
        }

        private void LoadData(int Id)
        {
            if (Id == -1) return;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Subscriptions sub = db.Subscriptions.Find(Id);
                SetCurrentGroup(sub.GroupId);
                if (sub.IsUnlimited)
                    radioButton_TypeUnlim.Checked = true;
                else
                    radioButton_TypeLim.Checked = true;
                numeric_HoursCur.Value = sub.SubHoursLeft;
                numeric_HoursMax.Value = (int)sub.SubHoursMax;
                box_StartDateDay.Text = sub.DateStart.Day.ToString();
                box_StartDateMonth.SelectedIndex = sub.DateStart.Month;
                box_StartDateYear.SelectedIndex = Array.FindIndex(Years, x => x == sub.DateStart.Year);
            }
        }

        private void PrepareForm()
        {
            box_StartDateYear.Items.Clear();
            box_StartDateYear.Items.AddRange(new object[] { Years[0], Years[1] });
        }

        private string GetMonthString(int i)
        {
            string end;
            int last = i % 10;
            if (i % 100 >= 11 && i % 100 <= 20) end = "ев";
            else if (last == 1) end = "";
            else if (last > 1 && last < 5) end = "а";
            else end = "ев";
            return $"{i} Месяц{end}";
        }

        private void SetCurrentGroup(int groupId)
        {
            try
            {
                CurrentGroupId = groupId;
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Groups group = db.Groups.Find(CurrentGroupId);
                    box_Group.Text = $"[Ид {group.GroupId}] {group.Name} ({group.Trainers.LastName})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выборе группы. Exception: " + ex);
            }
        }

        private void button_ChooseGroup_Click(object sender, EventArgs e)
        {
            ObjectListForm olf = new ObjectListForm(SearchForm.GROUPS);
            olf.ShowDialog();
            if (olf.CheckedId == -1) return;
            SetCurrentGroup(olf.CheckedId);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_SaveAdd_Click(object sender, EventArgs e)
        {
            if (!CheckFields()) return;
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    DateTime startDate = new DateTime(Years[box_StartDateYear.SelectedIndex], box_StartDateMonth.SelectedIndex, int.Parse(box_StartDateDay.Text));
                    DateTime formDate = new DateTime(Years[box_StartDateYear.SelectedIndex], box_StartDateMonth.SelectedIndex, int.Parse(box_StartDateDay.Text));

                    Subscriptions sub = db.Subscriptions.First(x => x.SubscriptionId == CurrentSubscribeId);

                    sub.StudentId = CurrentStudentId;
                    sub.GroupId = CurrentGroupId;
                    sub.BuyTime = DateTime.Now;
                    sub.IsUnlimited = radioButton_TypeUnlim.Checked;
                    sub.SubHoursMax = (int?)numeric_HoursMax.Value;
                    sub.SubHoursLeft = (int)numeric_HoursCur.Value;
                    sub.DateStart = startDate.AddDays(0);
                    sub.DateEnd = formDate.AddMonths(1).AddDays(-1);

                    db.SaveChanges();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении данных. Exception: " + ex);
            }
        }

        private bool CheckFields()
        {
            if (CurrentGroupId == -1)
            {
                MessageBox.Show("Не выбрана группа!");
                return false;
            }
            if (numeric_HoursCur.Value > numeric_HoursMax.Value)
            {
                MessageBox.Show("Количество оставшихся часов должно быть больше, чем максимальное!");
                return false;
            }
            if (!(numeric_HoursCur.Value >= 0 && numeric_HoursCur.Value < 1000))
            {
                MessageBox.Show("Количество часов должно быть от 0 до 999!");
                return false;
            }
            if (!(numeric_HoursMax.Value >= 0 && numeric_HoursMax.Value < 1000))
            {
                MessageBox.Show("Количество часов должно быть от 0 до 999!");
                return false;
            }
            try
            {
                DateTime date = new DateTime(Years[box_StartDateYear.SelectedIndex], box_StartDateMonth.SelectedIndex, int.Parse(box_StartDateDay.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильно введена дата!");
                return false;
            }

            return true;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Subscriptions sub = db.Subscriptions.First(x => x.SubscriptionId == CurrentSubscribeId);

                    db.Subscriptions.Remove(sub);
                    db.SaveChanges();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при удалении записи. Exception: " + ex);
            }
        }
    }
}
