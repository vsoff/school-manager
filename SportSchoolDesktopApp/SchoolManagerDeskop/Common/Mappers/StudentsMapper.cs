using SchoolManagerDeskop.Core.Dao.Entities;
using SchoolManagerDeskop.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Common.Mappers
{
    public class StudentsMapper : IEntityMapper<Student, StudentModel>
    {
        public Student ToCore(StudentModel model)
        {
            return new Student
            {
                Id = model.Id,
                Phone = model.Phone,
                Birdth = model.Birdth,
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
            };
        }

        public StudentModel ToModel(Student entity)
        {
            return new StudentModel
            {
                Id = entity.Id,
                Phone = entity.Phone,
                Birdth = entity.Birdth,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
            };
        }
    }
}
