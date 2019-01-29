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
    public partial class SubscribeBuyForm : Form
    {
        public bool IsNewAdded { get; private set; } = false;

        private int CurrentStudentId = -1;
        private int CurrentGroupId = -1;
        private int[] Years;

        public SubscribeBuyForm(int CurrentStudentId, int PresetSubscribeId)
        {
            InitializeComponent();
            Years = new int[] { DateTime.Now.Year, DateTime.Now.Year + 1 };
            this.CurrentStudentId = CurrentStudentId;
            PrepareForm();
            SubscribtionToForm(PresetSubscribeId);
        }

        private void SubscribtionToForm(int PresetSubscribeId)
        {
            if (PresetSubscribeId == -1) return;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Subscriptions sub = db.Subscriptions.Find(PresetSubscribeId);
                SetCurrentGroup(sub.GroupId);
                if (sub.IsUnlimited)
                    radioButton_TypeUnlim.Checked = true;
                else
                    radioButton_TypeLim.Checked = true;
                numeric_Hours.Value = (int)sub.SubHoursMax;
                box_Duration.SelectedIndex = 0;
                //box_StartDateDay.Text = sub.DateStart.Day.ToString();
                //box_StartDateMonth.SelectedIndex = sub.DateStart.Month;
                //box_StartDateYear.SelectedIndex = Array.FindIndex(Years, x => x == sub.DateStart.Year);
                var curDate = DateTime.Now;
                box_StartDateDay.Text = curDate.Day.ToString();
                box_StartDateMonth.SelectedIndex = curDate.Month;
                box_StartDateYear.SelectedIndex = Array.FindIndex(Years, x => x == curDate.Year);
            }
        }

        private void PrepareForm()
        {
            box_Duration.Items.Clear();
            foreach (var a in SportProgramSettings.Subscribe_DurationList)
                box_Duration.Items.Add(GetMonthString(a));
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
                    List<Subscriptions> subs = new List<Subscriptions>();
                    for (int i = 0; i < SportProgramSettings.Subscribe_DurationList[box_Duration.SelectedIndex]; i++)
                    {
                        Subscriptions sub = new Subscriptions
                        {
                            StudentId = CurrentStudentId,
                            GroupId = CurrentGroupId,
                            BuyTime = DateTime.Now,
                            IsUnlimited = radioButton_TypeUnlim.Checked,
                            SubHoursMax = (int?)numeric_Hours.Value,
                            SubHoursLeft = (int)numeric_Hours.Value,
                            DateStart = startDate.AddDays(0),
                            DateEnd = formDate.AddMonths(i + 1).AddDays(-1)
                        };
                        subs.Add(sub);
                        startDate = sub.DateEnd.AddDays(1);
                    }
                    db.Subscriptions.AddRange(subs);
                    db.SaveChanges();

                    IsNewAdded = true;
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
            if (!(numeric_Hours.Value > 0 && numeric_Hours.Value < 1000))
            {
                MessageBox.Show("Количество часов должно быть от 1 до 999!");
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
    }
}
