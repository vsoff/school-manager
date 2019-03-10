using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao.Entities
{
    public class Trainer : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [NotMapped]
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}
