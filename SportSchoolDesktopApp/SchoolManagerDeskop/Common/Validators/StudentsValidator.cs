using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Validators
{
    public class StudentsValidator : IEntityValidator<StudentModel>
    {
        public bool Validate(StudentModel entity, out string[] warnings)
        {
            List<string> warningsList = new List<string>();

            if (string.IsNullOrEmpty(entity.FirstName))
                warningsList.Add("имя должно быть заполнено");

            if (string.IsNullOrEmpty(entity.LastName))
                warningsList.Add("фамилия должна быть заполнена");

            if (string.IsNullOrEmpty(entity.Phone))
                warningsList.Add("телефон должен быть заполнен");

            if (entity?.Birdth == null)
                warningsList.Add("не указана дата рождения");

            warnings = warningsList.ToArray();
            return warningsList.Count == 0;
        }
    }
}
