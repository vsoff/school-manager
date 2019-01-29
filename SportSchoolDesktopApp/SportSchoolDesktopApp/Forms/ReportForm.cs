using SportSchoolDesktopApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportSchoolDesktopApp.Forms
{
    public partial class ReportForm : Form
    {
        private bool IsTrainer { get; set; }
        private int CurrentTargetId { get; set; }

        public ReportForm()
        {
            InitializeComponent();
            dtStart.Value = DateTime.Now.Date;
            dtEnd.Value = DateTime.Now.Date;
            IsTrainer = true;
            CurrentTargetId = -1;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioTrainer_CheckedChanged(object sender, EventArgs e)
        {
            IsTrainer = radioTrainer.Checked;
            CurrentTargetId = -1;
            textBoxCurrentTarget.Text = string.Empty;
            textBoxReport.Text = string.Empty;

            if (IsTrainer)
            {
                labelWhoIs.Text = "Тренер:";
                buttonCreateReportDetailed.Enabled = true;
            }
            else
            {
                labelWhoIs.Text = "Ученик:";
                buttonCreateReportDetailed.Enabled = false;
            }
        }

        private void buttonChooseTarget_Click(object sender, EventArgs e)
        {
            ObjectListForm olf;
            if (IsTrainer)
            {
                olf = new ObjectListForm(SearchForm.TRAINERS);
                olf.ShowDialog();
                if (olf.CheckedId == -1) return;
            }
            else
            {
                olf = new ObjectListForm(SearchForm.STUDENTS);
                olf.ShowDialog();
                if (olf.CheckedId == -1) return;
            }

            CurrentTargetId = olf.CheckedId;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                if (IsTrainer)
                {
                    Trainers t = db.Trainers.Find(olf.CheckedId);
                    textBoxCurrentTarget.Text = $"(ИД {t.TrainerId}) {t.LastName} {t.FirstName} {t.MiddleName}";
                }
                else
                {
                    Students t = db.Students.Find(olf.CheckedId);
                    textBoxCurrentTarget.Text = $"(ИД {t.StudentId}) {t.LastName} {t.FirstName} {t.MiddleName}";
                }
            }
        }

        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
            if (CurrentTargetId == -1)
            {
                textBoxReport.Text = "";
                MessageBox.Show("Не выбран " + (IsTrainer ? "тренер" : "ученик") + ".");
                return;
            }
            DataReporter dr = new DataReporter();
            string reportText = string.Empty;
            if (IsTrainer)
            {
                try
                {
                    reportText = dr.GetTrainerReport(CurrentTargetId, dtStart.Value, dtEnd.Value, false);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при формировании отчёта.");
                    return;
                }
            }
            else
            {
                try
                {
                    reportText = dr.GetStudentReport(CurrentTargetId, dtStart.Value, dtEnd.Value);
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при формировании отчёта.");
                    return;
                }
            }
            textBoxReport.Text = reportText;
            tabControl1.SelectTab(1);
        }

        private void buttonCreateReportDetailed_Click(object sender, EventArgs e)
        {
            if (CurrentTargetId == -1)
            {
                textBoxReport.Text = "";
                MessageBox.Show("Не выбран " + (IsTrainer ? "тренер" : "ученик") + ".");
                return;
            }

            DataReporter dr = new DataReporter();
            string reportText = string.Empty;
            try
            {
                reportText = dr.GetTrainerReport(CurrentTargetId, dtStart.Value, dtEnd.Value, true);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при формировании отчёта.");
                return;
            }
            textBoxReport.Text = reportText;
            tabControl1.SelectTab(1);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSaveReport.Enabled = tabControl1.SelectedTab == tabPage2;
        }

        private void buttonSaveReport_Click(object sender, EventArgs e)
        {
            if (textBoxReport.Text == string.Empty)
                MessageBox.Show("Нету отчёта для сохранения.");
            DataReporter dr = new DataReporter();
            if (!dr.SaveReport(textBoxReport.Text, IsTrainer ? "trainer" : "student"))
                MessageBox.Show("Произошла ошибка при сохранении отчёта.");
            else
                this.Close();
        }
    }
}
