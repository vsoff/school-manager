using System;
using System.Collections.Generic;
using System.Text;

namespace GemCard.Shell
{
    public class CardInsertedEventArgs : EventArgs
    {
        public int? Value { get; set; }
    }
}
