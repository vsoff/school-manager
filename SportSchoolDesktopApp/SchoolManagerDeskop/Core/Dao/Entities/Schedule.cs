using SchoolManagerDeskop.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao.Entities
{
    public class Schedule : Entity
    {
        [Required]
        public WeekDayCore WeekDays { get; set; }

        public int StartTimeMinutes { get; set; }

        public bool IsPeriodic { get; set; }

        public int Hall { get; set; }

        public long GroupId { get; set; }

        public virtual Group Group { get; set; }

        [NotMapped]
        public TimeSpan StartTime
        {
            get { return TimeSpan.FromMinutes(StartTimeMinutes); }
            set { StartTimeMinutes = (int)(value.TotalMinutes % TimeSpan.FromDays(1).TotalMinutes); }
        }
    }
}
