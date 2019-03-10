using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Workers
{
    public class DefaultWorker : IWorker
    {
        private readonly Action _action;
        private readonly Timer _timer;

        public DefaultWorker(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));

            TimerCallback tm = new TimerCallback(DoWork);
            _timer = new Timer(tm, null, Timeout.Infinite, Timeout.Infinite);
        }

        private void DoWork(object o)
        {
            _action.Invoke();
        }

        public void Start(TimeSpan interval, bool startImmediately = true)
        {
            _timer.Change(startImmediately ? TimeSpan.Zero : interval, interval);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
        }
    }
}
