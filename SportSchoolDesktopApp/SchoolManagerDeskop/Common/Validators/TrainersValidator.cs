using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Validators
{
    public class TrainersValidator : IEntityValidator<TrainerModel>
    {
        public bool Validate(TrainerModel entity, out string[] warnings)
        {
            warnings = new string[0];
            return true;
        }
    }
}
