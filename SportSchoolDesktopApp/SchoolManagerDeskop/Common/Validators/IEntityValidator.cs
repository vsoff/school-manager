using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Validators
{
    public interface IEntityValidator<T>
    {
        bool Validate(T entity, out string[] warnings);
    }
}
