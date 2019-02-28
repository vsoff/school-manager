using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao.Entities
{
    public class StudentsInSessions : Entity
    {
        public long StudentId { get; set; }

        public long SessionId { get; set; }

        public virtual Session Session { get; set; }

        public virtual Student Student { get; set; }
    }
}
