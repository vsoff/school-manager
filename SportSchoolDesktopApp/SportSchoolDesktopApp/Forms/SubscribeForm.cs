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
using GemCard.Shell;

namespace SportSchoolDesktopApp.Forms
{
    public partial class SubscribeForm : Form
    {
        private int CurrentStudentId = -1;
        private int CurrentSubscribeId = -1;

        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        // Постраничная навигация по сабам
        private int SubsPageLast = 0;
        private int SubsPageCurrent = 0;
        private int SubsPagePartition = 11;
        private readonly ISmartReaderListener _smartReader;
        List<Subscriptions> PageSubscriptions = new List<Subscriptions>();

        public SubscribeForm()
        {
            InitializeComponent();

            _smartReader = new SmartReaderListener();
            _smartReader.CardInserted += CardInserted;
        }

        private void CardInserted(object sender, CardInsertedEventArgs e)
        {
            if (!e.Value.HasValue)
            {
                MessageBox.Show("Ошибка контакта с картой. Попробуйте снова.");
                return;
            }

            synchronizationContext.Post(o => SetCurrentStudent((int) o), e.Value.Value);
        }

        private void PageNavigationUpdate(int pageIndex, int itemsCount)
        {
            SubsPageCurrent = pageIndex;
            SubsPageLast = (int) Math.Ceiling(((double) itemsCount / SubsPagePartition));
            SubsPageLast = SubsPageLast == 0 ? 1 : SubsPageLast;
            label_SubPages.Text = $"{pageIndex + 1} / {SubsPageLast}";
            // Блочим кнопки
            if (pageIndex >= SubsPageLast - 1)
            {
                button_SubLast.Enabled = false;
                button_SubNext.Enabled = false;
            }
            else
            {
                button_SubLast.Enabled = true;
                button_SubNext.Enabled = true;
            }

            if (pageIndex <= 0)
            {
                button_SubFirst.Enabled = false;
                button_SubPrev.Enabled = false;
            }
            else
            {
                button_SubFirst.Enabled = true;
                button_SubPrev.Enabled = true;
            }
        }

        private void RefreshSubscriptionList(int pageIndex)
        {
            ShowSubscription(-1);
            // Проверка на то, что студент выбран
            if (CurrentStudentId == -1) return;
            // Получение списка и вывод его
            try
            {
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    // Получаем ученика
                    Students student = db.Students.Find(CurrentStudentId);
                    // Обновляем инфу о постраничной навигации
                    int itemsCount = student.Subscriptions.Count();
                    PageNavigationUpdate(pageIndex, itemsCount);
                    // Работаем с подписками (вывод и все дела)
                    PageSubscriptions = student.Subscriptions.OrderByDescending(x => x.DateStart)
                        .Skip(SubsPagePartition * pageIndex).Take(SubsPagePartition).ToList();
                    listBox_Subscriptions.Items.Clear();
                    foreach (var s in PageSubscriptions)
                    {
                        listBox_Subscriptions.Items.Add(
                            $"С {s.DateStart.ToShortDateString()} по {s.DateEnd.ToShortDateString()}. {s.Groups.Name}({s.Groups.Trainers.LastName})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выводе подписок ученика. Exception: " + ex);
            }
        }

        private void button_Buy_Click(object sender, EventArgs e)
        {
            if (CurrentStudentId == -1 || CurrentStudentId == 0)
            {
                MessageBox.Show("Не выбран студент.");
                return;
            }

            SubscribeBuyForm sbf = new SubscribeBuyForm(CurrentStudentId, CurrentSubscribeId);
            sbf.ShowDialog();

            if (sbf.IsNewAdded)
                RefreshSubscriptionList(0);
        }

        private void button_ChooseStudent_Click(object sender, EventArgs e)
        {
            ObjectListForm olf = new ObjectListForm(SearchForm.STUDENTS);
            olf.ShowDialog();
            if (olf.CheckedId == -1) return;
            SetCurrentStudent(olf.CheckedId);
        }

        private void SetCurrentStudent(int studentId)
        {
            if (studentId == -1)
            {
                MessageBox.Show("Ошибка чтения карты, попробуйте еще раз.");
                return;
            }

            if (studentId == 0)
            {
                CurrentStudentId = studentId;
                CurrentSubscribeId = -1;
                label_StudentFullName.Text = string.Empty;
                label_StudentId.Text = string.Empty;

                SubsPageLast = 0;
                SubsPageCurrent = 0;
                PageNavigationUpdate(0, 0);

                PageSubscriptions.Clear();
                listBox_Subscriptions.Items.Clear();
                ShowSubscription(-1);


                MessageBox.Show("Эта карта не привязана ни к одному ученику.");
                return;
            }

            try
            {
                CurrentStudentId = studentId;
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Students student = db.Students.Find(CurrentStudentId);
                    if (student == null)
                    {
                        MessageBox.Show($"Нет ученика с ИД {CurrentStudentId}");
                        return;
                    }

                    label_StudentId.Text = student.StudentId.ToString();
                    label_StudentFullName.Text = $"{student.FirstName} {student.MiddleName} {student.LastName}";
                }

                RefreshSubscriptionList(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при выборе ученика. Exception: " + ex);
            }
        }

        private void button_SubFirst_Click(object sender, EventArgs e)
        {
            RefreshSubscriptionList(0);
        }

        private void button_SubPrev_Click(object sender, EventArgs e)
        {
            RefreshSubscriptionList(SubsPageCurrent - 1);
        }

        private void button_SubNext_Click(object sender, EventArgs e)
        {
            RefreshSubscriptionList(SubsPageCurrent + 1);
        }

        private void button_SubLast_Click(object sender, EventArgs e)
        {
            RefreshSubscriptionList(SubsPageLast - 1);
        }

        private void listBox_Subscriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSubscription(listBox_Subscriptions.SelectedIndex);
        }

        private void ShowSubscription(int index)
        {
            if (index == -1)
            {
                CurrentSubscribeId = -1;
                labelAbonent_Id.Text = string.Empty;
                labelAbonent_Group.Text = string.Empty;
                labelAbonent_BuyTime.Text = string.Empty;
                labelAbonent_CardType.Text = string.Empty;
                labelAbonent_Time.Text = string.Empty;
                labelAbonent_Hours.Text = string.Empty;
                button_Edit.Enabled = false;
                return;
            }

            var sub = PageSubscriptions[index];
            CurrentSubscribeId = sub.SubscriptionId;
            labelAbonent_Id.Text = sub.SubscriptionId.ToString();
            labelAbonent_Group.Text = $"[Ид {sub.Groups.GroupId}] {sub.Groups.Name} ({sub.Groups.Trainers.LastName})";
            labelAbonent_BuyTime.Text = sub.BuyTime.ToString();
            labelAbonent_CardType.Text = sub.IsUnlimited ? "Безлимитная" : "Лимитированная";
            labelAbonent_Time.Text = $" С {sub.DateStart}\nПо {sub.DateEnd}";
            labelAbonent_Hours.Text = $"{sub.SubHoursLeft} / {sub.SubHoursMax}";
            button_Edit.Enabled = true;
        }

        private void SubscribeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _smartReader.Dispose();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (CurrentStudentId == -1 || CurrentStudentId == 0)
            {
                MessageBox.Show("Не выбран студент.");
                return;
            }

            if (CurrentSubscribeId == -1 || CurrentSubscribeId == 0)
            {
                MessageBox.Show("Не выбрана подписка.");
                return;
            }

            SubscribeEditForm sef = new SubscribeEditForm(CurrentStudentId, CurrentSubscribeId);
            sef.ShowDialog();

            RefreshSubscriptionList(0);
        }
    }
}