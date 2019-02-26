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
                warningsList.Add("имя не должно быть пустым");
            else if (entity.FirstName.Length < 2 || entity.FirstName.Length > 6)
                warningsList.Add("имя не должно быть короче 2 или длиннее 6 символов");

            if (string.IsNullOrEmpty(entity.Phone))
                warningsList.Add("телефон должен быть заполнен");

            if (entity?.Birdth == null)
                warningsList.Add("дата рождения должна быть заполнена");

            warnings = warningsList.ToArray();
            return warningsList.Count == 0;
        }
    }
}
