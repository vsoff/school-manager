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
using TestSmartcard;

namespace SportSchoolDesktopApp.Forms
{
    public partial class CardEditor : Form
    {
        SmartReaderController SmartReader;

        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        public CardEditor()
        {
            InitializeComponent();

            SmartReader = new SmartReaderController(SmartReaderType.Reader, UpdateUI);
        }

        public void UpdateUI(int value)
        {
            if (value == -1)
            {
                MessageBox.Show("Ошибка контакта с картой. Попробуйте снова.");
                return;
            }

            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                int id = (int)o;
                if (id == 0)
                {
                    labelRead.Text = "<Пустая карта>";
                    return;
                }
                using (var db = new SportEntities(SportProgramSettings.ConnectionString))
                {
                    Students student = db.Students.Find(id);
                    labelRead.Text = $"(Ид {student.StudentId}) {student.FirstName} {student.MiddleName} {student.LastName}";
                }
            }), value);

        }

        private void CardEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            SmartReader.DestroyObject();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObjectListForm selectStudentForm = new ObjectListForm(SearchForm.STUDENTS);
            selectStudentForm.ShowDialog();
            if (selectStudentForm.CheckedId == -1) return;
            using (var db = new SportEntities(SportProgramSettings.ConnectionString))
            {
                Students student = db.Students.Find(selectStudentForm.CheckedId);
                labelStudent.Text = $"(Ид {student.StudentId}) {student.FirstName} {student.MiddleName} {student.LastName}";
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
