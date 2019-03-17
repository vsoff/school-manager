using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao.Entities
{
    public class Subscription : Entity
    {
        public long StudentId { get; set; }

        public long? GroupId { get; set; }

        public DateTime BuyTime { get; set; }

        public bool IsUnlimited { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int? SubHoursMax { get; set; }

        public int SubHoursLeft { get; set; }

        public virtual Group Group { get; set; }

        public virtual Student Student { get; set; }
    }
}
