using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao.Entities
{
    public class Session : Entity
    {
        public TimeSpan Time { get; set; }

        public DateTime Date { get; set; }

        public long GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
