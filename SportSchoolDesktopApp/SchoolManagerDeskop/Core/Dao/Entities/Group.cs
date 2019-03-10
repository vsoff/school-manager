using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao.Entities
{
    public class Group : Entity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public long TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
