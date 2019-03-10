using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Workers
{
    public class DefaultWorkerController : IWorkerController
    {
        public IWorker StartWorker(Action action, TimeSpan interval, bool startImmediately = true)
        {
            IWorker worker = new DefaultWorker(action);
            worker.Start(interval, startImmediately);
            return worker;
        }
    }
}
