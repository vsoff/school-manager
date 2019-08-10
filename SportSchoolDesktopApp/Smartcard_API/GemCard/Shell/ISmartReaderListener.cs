using System;

namespace GemCard.Shell
{
    public interface ISmartReaderListener : IDisposable
    {
        event EventHandler<CardInsertedEventArgs> CardInserted;
        event EventHandler<EventArgs> CardRemoved;
        bool WriteValue(int value);
        void ChangeReader(string reader);
    }
}