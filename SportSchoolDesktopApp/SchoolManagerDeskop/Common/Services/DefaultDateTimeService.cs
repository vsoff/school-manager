using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Services
{
    /// <summary>
    /// Сервис работы со временем.
    /// </summary>
    public interface IDateTimeService
    {
        /// <summary>
        /// Возвращает текущее время.
        /// </summary>
        DateTime GetCurrentTime();

        /// <summary>
        /// Возвращает текущее время в UTC.
        /// </summary>
        DateTime GetCurrentTimeUtc();
    }

    public class DefaultDateTimeService : IDateTimeService
    {
        public DateTime GetCurrentTime() => DateTime.Now;

        public DateTime GetCurrentTimeUtc() => DateTime.UtcNow;
    }
}
