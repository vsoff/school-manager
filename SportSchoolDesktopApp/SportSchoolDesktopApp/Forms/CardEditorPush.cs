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
    public partial class CardEditorPush : Form
    {
        SmartReaderController SmartReader;

        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        public CardEditorPush(int data)
        {
            InitializeComponent();

            SmartReader = new SmartReaderController(SmartReaderType.Writer, UpdateUI);
            SmartReader.WData = data;
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
                //labelRead.Text = ((int)o).ToString();
                this.Close();
            }), value);

        }

        private void CardEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            SmartReader.DestroyObject();
        }
    }
}
