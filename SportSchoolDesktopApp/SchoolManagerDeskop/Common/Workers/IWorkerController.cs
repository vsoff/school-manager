using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Workers
{
    public interface IWorkerController
    {
        IWorker StartWorker(Action action, TimeSpan interval, bool startImmediately = true);
    }
}
