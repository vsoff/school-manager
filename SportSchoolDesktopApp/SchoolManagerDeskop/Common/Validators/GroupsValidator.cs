using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Validators
{
    public class GroupsValidator : IEntityValidator<GroupModel>
    {
        public bool Validate(GroupModel entity, out string[] warnings)
        {
            warnings = new string[0];
            return true;
        }
    }
}
