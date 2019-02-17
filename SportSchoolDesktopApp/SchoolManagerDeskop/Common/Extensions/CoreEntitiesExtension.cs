using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Extensions
{
    public static class CoreEntitiesExtension
    {
        public static StudentModel ToModel(this Student student)
        {
            return new StudentModel
            {
                Phone = student.Phone,
                Id = student.Id,
                Birdth = student.Birdth,
                LastName = student.LastName,
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
            };
        }
    }
}
