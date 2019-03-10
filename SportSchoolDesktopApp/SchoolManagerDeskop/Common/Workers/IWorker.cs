using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Workers
{
    public interface IWorker : IDisposable
    {
        void Start(TimeSpan interval, bool startImmediately = true);
        void Stop();
    }
}
