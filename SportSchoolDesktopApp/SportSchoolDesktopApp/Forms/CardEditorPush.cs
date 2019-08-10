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
    public partial class CardEditorPush : Form
    {
        private readonly ISmartReaderListener _smartReader;

        private readonly SynchronizationContext synchronizationContext = SynchronizationContext.Current;

        private readonly int NewValue;

        public CardEditorPush(int data)
        {
            InitializeComponent();

            NewValue = data;
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

            _smartReader.WriteValue(NewValue);

            synchronizationContext.Post(o => Close(), e.Value.Value);
        }

        private void CardEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            _smartReader.Dispose();
        }
    }
}