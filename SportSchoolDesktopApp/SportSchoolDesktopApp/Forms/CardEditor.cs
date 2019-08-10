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
    public partial class CardEditor : Form
    {
        private readonly ISmartReaderListener _smartReader;

        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        public CardEditor()
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

            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                int id = (int) o;
                if (id == 0)
                {
                    labelRead.Text = "<Пустая карта>";
                    return;
                }

                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Students student = db.Students.Find(id);
                    labelRead.Text = student == null
                        ? $"Ученика с ID == {id} не существует"
                        : $"(Ид {student.StudentId}) {student.FirstName} {student.MiddleName} {student.LastName}";
                }
            }), e.Value.Value);
        }

        private void CardEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _smartReader.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectListForm selectStudentForm = new ObjectListForm(SearchForm.STUDENTS);
            selectStudentForm.ShowDialog();
            if (selectStudentForm.CheckedId == -1) return;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Students student = db.Students.Find(selectStudentForm.CheckedId);
                labelStudent.Text =
                    $"(Ид {student.StudentId}) {student.FirstName} {student.MiddleName} {student.LastName}";
                CurrentStudentId = selectStudentForm.CheckedId;
            }
        }

        private int CurrentStudentId = -1;

        private void button2_Click(object sender, EventArgs e)
        {
            CardEditorPush cep = new CardEditorPush(CurrentStudentId);
            cep.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CardEditorPush cep = new CardEditorPush(0);
            cep.ShowDialog();
        }
    }
}